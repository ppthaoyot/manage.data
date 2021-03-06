using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using EFCore.BulkExtensions;
using Mapster;
using ReadExcelFiles.Data;
using ReadExcelFiles.Models;

namespace ReadExcelFiles
{
    public class ManageData
    {
        private readonly AppDBContext _context;

        public ManageData(AppDBContext context)
        {
            _context = context;
        }

        public void ToDBPolicy()
        {
            var start = DateTime.Now;
            //Declaration
            var doneList = new List<string>();
            var updatedList = new List<string>();
            var listDBMotor = new List<DBMotor>();
            var listDBMotorUpdate = new List<DBMotor>();
            var watch = new Stopwatch();
            int count = 0;
            int countInsert = 0;
            int countUpdated = 0;
            //Watch start
            watch.Start();
            Console.WriteLine($"Start : {DateTime.Now}");

            //Get Data from Motor DB
            var tmpList = _context.Motor.ToList();

            //loop for check data in done list
            tmpList.ForEach(x =>
            {
                count++;
                var checkDoneList = doneList.Contains(x.PolicyNumber);
                var checkUpdatedList = updatedList.Contains(x.PolicyNumber);
                if (!checkDoneList && !checkUpdatedList)
                {
                    var tmpResult = tmpList.Where(o => o.PolicyNumber == x.PolicyNumber).OrderByDescending(o => o.EndDateConvert).First();

                    var motorResult = _context.DBMotor.Where(o => o.PolicyNumber == tmpResult.PolicyNumber).FirstOrDefault();
                    if (motorResult == null)
                    {
                        var motor = new DBMotor();
                        //mapster
                        tmpResult.Adapt(motor);
                        //split SaleID / SaleName
                        var sale = tmpResult.SaleID.Split("-");
                        motor.SaleID = sale[0].Trim();
                        motor.SaleName = sale[1].Trim();
                        motor.CoveragePeriodStart = tmpResult.PolicyStartDate;
                        motor.StartDateConvert = tmpResult.PolicyStartDateConvert;
                        motor.Premium = Premium(Convert.ToDouble(tmpResult.Premium)).ToString();
                        //TEST
                        motor.PolicyStartDateConvert2 = tmpResult.PolicyStartDateConvert;
                        motor.CreatedDateConvert = Convert.ToDateTime(tmpResult.CreatedDate);
                        //assign latest update
                        motor.LatestUpdate = DateTime.Now;
                        //Add to list
                        listDBMotor.Add(motor);
                        doneList.Add(tmpResult.PolicyNumber);
                    }
                    else
                    {
                        updatedList.Add(tmpResult.PolicyNumber);
                        if (tmpResult.EndDateConvert > motorResult.EndDateConvert)
                        {
                            var update = motorResult;

                            update.CoveragePeriodEnd = tmpResult.CoveragePeriodEnd;
                            update.EndDateConvert = tmpResult.EndDateConvert;
                            update.LatestUpdate = DateTime.Now;
                            //TEST
                            update.PolicyStartDateConvert2 = tmpResult.PolicyStartDateConvert;
                            //Add to list
                            listDBMotorUpdate.Add(update);
                        }
                    }
                }
                Console.WriteLine($"Count : {count}");
            });

            using (var transaction = _context.Database.BeginTransaction())
            {
                //List greater than 0  => bulkInsert
                if (listDBMotor.Count > 0)
                {
                    //count insert
                    countInsert = listDBMotor.Count();
                    _context.BulkInsert(listDBMotor);
                }
                if (listDBMotorUpdate.Count > 0)
                {
                    //count update
                    countUpdated = listDBMotorUpdate.Count();
                    _context.BulkUpdate(listDBMotorUpdate);
                }
                transaction.Commit();
            }

            watch.Stop();
            var end = DateTime.Now;
            var ts = watch.Elapsed;
            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine($"Start : {start}");
            Console.WriteLine($"End : {end}");
            Console.WriteLine($"RunTime : {elapsedTime}");
            Console.WriteLine($"Count Total : {count} ");
            Console.WriteLine($"Count Done List : {doneList.Count()} ");
            Console.WriteLine($"Count Insert {countInsert} ");
            Console.WriteLine($"Count Update {countUpdated} ");
        }
        public void ToDBPremium()
        {
            var start = DateTime.Now;
            //Declaration
            int total = 0;
            var watch = new Stopwatch();
            //Watch start
            watch.Start();
            Console.WriteLine($"Start : {DateTime.Now}");

            var initial = _context.Premium.Count();
            var now = DateTime.Now;
            var listYears = new List<int>() { 2019, 2020, 2021 };

            Console.WriteLine($"Premium Count : {initial}");

            //data in premium equal 0
            if (initial == 0)
            {
                foreach (var y in listYears)
                {
                    //initial insert  
                    total += DataToPremium(y);
                }
            }
            else
            {
                //insert current year
                total += DataToPremium(now.Year, now.Month);
            }

            watch.Stop();
            var end = DateTime.Now;
            var ts = watch.Elapsed;
            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine($"Start : {start}");
            Console.WriteLine($"End : {end}");
            Console.WriteLine($"RunTime : {elapsedTime}");
            Console.WriteLine($"Total : {total}");

        }
        public int DataToPremium(int year, int? month = null)
        {
            int countTotal = 0;
            var now = DateTime.Now;

            for (int j = 1; j <= (month != null ? 1 : 12); j++)
            {
                int count = 0;
                var listPremium = new List<Premium>();
                //Get Data from Motor DB
                var motor = new List<DBMotor>();
                motor = _context.DBMotor.Where(m => m.CreatedDateConvert.Month == (month != null ? month : j) && m.CreatedDateConvert.Year == year).ToList();


                foreach (var m in motor)
                {
                    //?????????????????????????????? null ????????? ??????????????????????????? insert ???????????????????????? ???????????????????????????????????????????????????????????????????????????
                    if (month != null)
                    {
                        //??????????????????????????????????????????????????????????????????????????????
                        var p = _context.Premium.Where(p => p.PolicyNo.Trim() == m.PolicyNumber && p.PremiumType.Trim() == "New Policy").FirstOrDefault();
                        //??????????????????????????? skip
                        if (p != null) continue;
                    }

                    count++;
                    var premium = Premium(Convert.ToDouble(m.Premium));
                    var agent = _context.Agent.Where(o => o.AgentCode == m.SaleID).FirstOrDefault();
                    int months = ((m.ProductDetail.Trim() == "M3+" || m.ProductGroupDetail.Trim() == "???????????????????????????") ? 1 : (m.ProductDetail.Trim() == "M2+ Special Yearly") ? 12 : 2); //M3+ ??????????????? 1 ????????? ,??????????????? new policy ?????????????????? 2 ?????????
                    var coverageDateFrom = m.PolicyStartDateConvert;
                    for (int i = 0; i < months; i++)
                    {
                        var premiumModel = new Premium
                        {
                            Product = m.ProductGroupDetail,
                            Plan = m.ProductDetail,
                            Agent = $"{m.SaleID} - {m.SaleName}",
                            Branch = m.Branch,
                            Telephone = (agent != null ? agent.Telephone : null),
                            Email = (agent != null ? agent.Email : null),
                            Insuredname = $"{m.InsuredFirstName} {m.InsuredLastName}",
                            PolicyNo = m.PolicyNumber,
                            CoverageDateFrom = ((m.ProductDetail.Trim() == "M3+" || m.ProductGroupDetail.Trim() == "???????????????????????????") ? m.StartDateConvert : coverageDateFrom.AddMonths(i)),
                            CoverageDateTo = ((m.ProductDetail.Trim() == "M3+" || m.ProductGroupDetail.Trim() == "???????????????????????????") ? m.EndDateConvert : coverageDateFrom.AddMonths(i + 1)),
                            PremiumType = "New Policy",
                            TotalAmount = premium.ToString("0.00"),
                            BankHolderName = m.SaleName,
                            BankName = (agent != null ? agent.Bank : null),
                            BankNumber = (agent != null ? agent.BankAccountNo : null),
                        };
                        listPremium.Add(premiumModel);
                    }
                }
                Console.WriteLine($"Count : {count}");

                using (var transaction = _context.Database.BeginTransaction())
                {
                    //List greater than 0  => bulkInsert
                    countTotal += listPremium.Count();
                    if (countTotal > 0)
                    {
                        _context.BulkInsert(listPremium);
                    }
                    transaction.Commit();
                }
            }
            return countTotal;
        }

        public int MonthDiff(DateTime start, DateTime end)
        {
            int m1;
            int m2;
            if (start < end)
            {
                m1 = (end.Month - start.Month);//for years
                m2 = (end.Year - start.Year) * 12; //for months
            }
            else
            {
                m1 = (start.Month - end.Month);//for years
                m2 = (start.Year - end.Year) * 12; //for months
            }

            return m1 + m2;
        }

        public Double Premium(Double premium)
        {
            if (premium == 0) return premium;

            var ListPremium = new List<int>() { 588, 1088, 2088, 6500 };
            foreach (var p in ListPremium)
            {
                var mod = premium % p;
                if (mod == 0) return p;
            }
            return premium;
        }
    }
}