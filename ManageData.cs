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
            var listPremium = new List<Premium>();
            var watch = new Stopwatch();
            //Watch start
            watch.Start();
            Console.WriteLine($"Start : {DateTime.Now}");

            //Get Data from Motor DB
            var tmpList = _context.Agent.ToList();

            //loop for check data in done list
            tmpList.ForEach(x =>
                        {
                            var motor = _context.Motor.Where(m => m.SaleID.Contains("06272") && m.PolicyType.Trim() == "New Policy").ToList();

                            foreach (var m in motor)
                            {
                                var months = MonthDiff(m.StartDateConvert, m.EndDateConvert);
                                var premium = PremiumCheck(Convert.ToDouble(m.Premium));

                                for (int i = 0; i < months; i++)
                                {
                                    var premiumModel = new Premium
                                    {
                                        Insurer = null,
                                        Product = m.ProductGroupDetail,
                                        Plan = m.ProductDetail,
                                        Agent = m.SaleID,
                                        Branch = m.Branch,
                                        PayerName = null,
                                        PayerID = null,
                                        Telephone = null,
                                        Email = null,
                                        AddressType = null,
                                        Province = null,
                                        District = null,
                                        Subdistrict = null,
                                        StreetAddress = null,
                                        Insuredname = $"{m.InsuredFirstName} {m.InsuredLastName}",
                                        QuotationNo = null,
                                        PolicyNo = null,
                                        PolicyIssueDate = null,
                                        BillingDate = null,
                                        CollectionDate = null,
                                        CoverageDateFrom = null,
                                        CoverageDateTo = null,
                                        PremiumType = null,
                                        PayMode = null,
                                        PaymentStatus = null,
                                        FailReasons = null,
                                        GrossPremium = (premium - (premium * .07)).ToString(),
                                        VAT = (premium * .07).ToString(),
                                        StampDuty = null,
                                        TotalAmount = premium.ToString(),
                                        BankHolderName = null,
                                        BankName = null,
                                        BankNumber = null,
                                    };
                                    listPremium.Add(premiumModel);
                                }

                                var customer = _context.Customer.Where(c => c.PolicyNo == m.PolicyNumber).ToList();

                                foreach (var c in customer)
                                {
                                    var premiumModel = new Premium();
                                    //mapster
                                    customer.Adapt(premiumModel);
                                }
                            }
                        });

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

        public int PremiumCheck(Double premium)
        {
            var ListPremium = new List<int>() { 588, 1088 };
            foreach (var p in ListPremium)
            {
                var mod = premium % p;
                if (mod == 0) return p;
            }

            return 0;
        }
    }
}