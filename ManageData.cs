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
                            update.CoveragePeriodStart = tmpResult.CoveragePeriodStart;
                            update.CoveragePeriodEnd = tmpResult.CoveragePeriodEnd;
                            update.StartDateConvert = tmpResult.StartDateConvert;
                            update.EndDateConvert = tmpResult.EndDateConvert;
                            update.LatestUpdate = DateTime.Now;
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
            var doneList = new List<string>();
            int count = 0;
            var watch = new Stopwatch();
            //Watch start
            watch.Start();
            Console.WriteLine($"Start : {DateTime.Now}");

            var listYear = new List<int>() { 2019, 2020, 2021 };

            for (int i = 0; i < listYear.Count(); i++)
            {
                for (int j = 1; j <= 12; j++)
                {
                    var listPremium = new List<Premium>();
                    //Get Data from Motor DB
                    var tmpList = _context.Agent.Where(o => o.BillingDate.Month == j && o.BillingDate.Year == listYear[i] && o.Amount != 0).ToList();
                    if (tmpList.Count != 0)
                    {
                        //loop for check data in done list
                        tmpList.ForEach(x =>
                                       {
                                           count++;
                                           //from agent
                                           var motor = _context.Motor.Where(m => m.SaleID.Contains(x.AgentCode) && m.PolicyType.Trim() == "New Policy").ToList(); //TODO :
                                           foreach (var m in motor)
                                           {
                                               //check data in db premium
                                               var premiums = _context.Premium.Where(p => p.Agent.Contains(x.AgentCode) && p.PremiumType.Trim() == "New Policy" && p.PolicyNo == m.PolicyNumber).Count();
                                               if (premiums == 0)
                                               {
                                                   var coveragePeriods = CoveragePeriod(m.StartDateConvert, m.EndDateConvert);
                                                   var premium = PremiumCheck(Convert.ToDouble(m.Premium));

                                                   for (int i = 0; i < coveragePeriods.Count(); i++)
                                                   {
                                                       var premiumModel = new Premium
                                                       {
                                                           Product = m.ProductGroupDetail,
                                                           Plan = m.ProductDetail,
                                                           Agent = m.SaleID,
                                                           Branch = m.Branch,
                                                           Telephone = x.Telephone,
                                                           Email = x.Email,
                                                           Insuredname = $"{m.InsuredFirstName} {m.InsuredLastName}",
                                                           PolicyNo = m.PolicyNumber,
                                                           BillingDate = x.BillingDate,
                                                           CollectionDate = x.CollectionDate,
                                                           CoverageDateFrom = coveragePeriods[i].CoveragePeriodStart,
                                                           CoverageDateTo = coveragePeriods[i].CoveragePeriodEnd,
                                                           PremiumType = m.PolicyType,
                                                           PayMode = x.PayMode,
                                                           PaymentStatus = x.CollectionStatus,
                                                           TotalAmount = premium.ToString("0.00"),
                                                           BankHolderName = x.AgentName,
                                                           BankName = x.Bank,
                                                           BankNumber = x.BankAccountNo,
                                                       };
                                                       listPremium.Add(premiumModel);
                                                   }
                                                   //from customer
                                                   var customer = _context.Customer.Where(c => c.PolicyNo == m.PolicyNumber).ToList();
                                                   foreach (var c in customer)
                                                   {
                                                       var premiumModel = new Premium();
                                                       //mapster
                                                       c.Adapt(premiumModel);
                                                       listPremium.Add(premiumModel);
                                                   }
                                               }
                                               else
                                               {
                                                   //from customer
                                                   var customer = _context.Customer.Where(c => c.PolicyNo == m.PolicyNumber).ToList();
                                                   if (customer.Count() > 0)
                                                   {
                                                       //from premium
                                                       var latestCoverage = _context.Premium.Where(o => o.PolicyNo == m.PolicyNumber).OrderByDescending(o => o.CoverageDateFrom).First();

                                                       foreach (var c in customer)
                                                       {
                                                           var date1 = Convert.ToDateTime(c.CoverageDateFrom);

                                                           if (date1 > latestCoverage.CoverageDateFrom)
                                                           {
                                                               var premiumModel = new Premium();
                                                               //mapster
                                                               c.Adapt(premiumModel);
                                                               listPremium.Add(premiumModel);
                                                           }
                                                       }
                                                   }
                                               }
                                           }
                                           Console.WriteLine($"Count : {count}");
                                       });

                        using (var transaction = _context.Database.BeginTransaction())
                        {
                            //List greater than 0  => bulkInsert
                            if (listPremium.Count > 0)
                            {
                                _context.BulkInsert(listPremium);
                            }
                            transaction.Commit();
                        }
                    }
                }
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
            Console.WriteLine($"Count Total : {count}");
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


        public List<CoveragePeriod> CoveragePeriod(DateTime start, DateTime end)
        {
            int m1;
            int m2;
            int months;
            var listCoveragePeriod = new List<CoveragePeriod>();
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

            months = m1 + m2;

            for (int i = 0; i < months; i++)
            {
                var c = new CoveragePeriod
                {

                    CoveragePeriodStart = start.AddMonths(i),
                    CoveragePeriodEnd = start.AddMonths(i + 1)
                };

                listCoveragePeriod.Add(c);
            }

            return listCoveragePeriod;
        }

        public Double PremiumCheck(Double premium)
        {
            var ListPremium = new List<int>() { 588, 1088 };
            foreach (var p in ListPremium)
            {
                var mod = premium % p;
                if (mod == 0) return p;
            }
            //TODO
            return premium;
        }
    }
}