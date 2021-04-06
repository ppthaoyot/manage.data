using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EFCore.BulkExtensions;
using ExcelDataReader;
using Mapster;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ReadExcelFiles.Data;
using ReadExcelFiles.Models;
using ReadExcelFiles.Services;


namespace ReadExcelFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            //MotorReportInsert();
            //AgentInsert();
            //CustomerInsert();

            DbContextOptionsBuilder<AppDBContext> optionsBuilder = new DbContextOptionsBuilder<AppDBContext>();
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            AppDBContext _dBContext = new AppDBContext(optionsBuilder.Options);

            new ManageData(_dBContext).ToDBPolicy();
            new ManageData(_dBContext).ToDBPremium();
        }

        // EF Core uses this method at design time to access the DbContext
        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
             .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
             .AddJsonFile($"appsettings.{Environment.MachineName}.json", optional: true)
             .AddEnvironmentVariables()
             .Build();
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                    {
                        webBuilder.UseStartup<Startup>();
                    });
        private static void MotorReportInsert()
        {
            DbContextOptionsBuilder<AppDBContext> optionsBuilder = new DbContextOptionsBuilder<AppDBContext>();
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            AppDBContext _dBContext = new AppDBContext(optionsBuilder.Options);

            var watch = System.Diagnostics.Stopwatch.StartNew();

            IExcelDataReader reader = null;
            string FilePath = "D:/Files/Motor Report 20210323 - Copy.xlsx";

            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            //Load file into a stream
            FileStream stream = File.Open(FilePath, FileMode.Open, FileAccess.Read);
            int count = 0;
            double second = 0;
            double second2 = 0;
            //Must check file extension to adjust the reader to the excel file type
            if (Path.GetExtension(FilePath).Equals(".xls"))
                reader = ExcelReaderFactory.CreateBinaryReader(stream);
            else if (Path.GetExtension(FilePath).Equals(".xlsx"))
                reader = ExcelReaderFactory.CreateOpenXmlReader(stream);

            if (reader != null)
            {
                //Fill DataSet
                DataSet ds = reader.AsDataSet(new ExcelDataSetConfiguration()
                {
                    ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                    {
                        UseHeaderRow = true
                    }
                });

                var motors = ds.Tables[0].AsEnumerable().Select(dataRow => new Motor
                {
                    PolicyType = dataRow.Field<string>(ds.Tables[0].Columns[0].ColumnName),
                    AppId = dataRow.Field<string>(ds.Tables[0].Columns[1].ColumnName),
                    PolicyNumber = dataRow.Field<string>(ds.Tables[0].Columns[2].ColumnName),
                    ProductGroupDetail = dataRow.Field<string>(ds.Tables[0].Columns[3].ColumnName),
                    ProductDetail = dataRow.Field<string>(ds.Tables[0].Columns[4].ColumnName),
                    ProductTypeDetail = dataRow.Field<string>(ds.Tables[0].Columns[5].ColumnName),
                    Premium = dataRow.Field<string>(ds.Tables[0].Columns[6].ColumnName),
                    MotorApplicationClaimTypeDetail = dataRow.Field<string>(ds.Tables[0].Columns[7].ColumnName),
                    PolicyStartDate = dataRow.Field<string>(ds.Tables[0].Columns[8].ColumnName),
                    CoveragePeriodStart = dataRow.Field<string>(ds.Tables[0].Columns[9].ColumnName),
                    CoveragePeriodEnd = dataRow.Field<string>(ds.Tables[0].Columns[10].ColumnName),
                    InsuredTitle = dataRow.Field<string>(ds.Tables[0].Columns[11].ColumnName),
                    InsuredFirstName = dataRow.Field<string>(ds.Tables[0].Columns[12].ColumnName),
                    InsuredLastName = dataRow.Field<string>(ds.Tables[0].Columns[13].ColumnName),
                    InsuredPhone = dataRow.Field<string>(ds.Tables[0].Columns[14].ColumnName),
                    InsuredAddress = dataRow.Field<string>(ds.Tables[0].Columns[15].ColumnName),
                    InsuredStreetNo = dataRow.Field<string>(ds.Tables[0].Columns[16].ColumnName),
                    InsuredSubdistrict = dataRow.Field<string>(ds.Tables[0].Columns[17].ColumnName),
                    InsuredDistrict = dataRow.Field<string>(ds.Tables[0].Columns[18].ColumnName),
                    InsuredProvince = dataRow.Field<string>(ds.Tables[0].Columns[19].ColumnName),
                    InsuredPostalCode = dataRow.Field<string>(ds.Tables[0].Columns[20].ColumnName),
                    InsuredIdentityCard = dataRow.Field<string>(ds.Tables[0].Columns[21].ColumnName),
                    InsuredPassport = dataRow.Field<string>(ds.Tables[0].Columns[22].ColumnName),
                    InsuredWorkAddressProvinceID = dataRow.Field<string>(ds.Tables[0].Columns[23].ColumnName),
                    InsuredWorkAddressDistrictID = dataRow.Field<string>(ds.Tables[0].Columns[24].ColumnName),
                    InsuredWorkAddressSubDistrictID = dataRow.Field<string>(ds.Tables[0].Columns[25].ColumnName),
                    PayerTitle = dataRow.Field<string>(ds.Tables[0].Columns[26].ColumnName),
                    PayerFirstName = dataRow.Field<string>(ds.Tables[0].Columns[27].ColumnName),
                    PayerLastName = dataRow.Field<string>(ds.Tables[0].Columns[28].ColumnName),
                    PayerPhoneNo = dataRow.Field<string>(ds.Tables[0].Columns[29].ColumnName),
                    PayerBuildingName = dataRow.Field<string>(ds.Tables[0].Columns[30].ColumnName),
                    PayerAddress = dataRow.Field<string>(ds.Tables[0].Columns[31].ColumnName),
                    PayerStreetNo = dataRow.Field<string>(ds.Tables[0].Columns[32].ColumnName),
                    PayerSubdistrict = dataRow.Field<string>(ds.Tables[0].Columns[33].ColumnName),
                    PayerDistrict = dataRow.Field<string>(ds.Tables[0].Columns[34].ColumnName),
                    PayerProvince = dataRow.Field<string>(ds.Tables[0].Columns[35].ColumnName),
                    PayerPostalCode = dataRow.Field<string>(ds.Tables[0].Columns[36].ColumnName),
                    PayerBankAccount = dataRow.Field<string>(ds.Tables[0].Columns[37].ColumnName),
                    PayerBankName = dataRow.Field<string>(ds.Tables[0].Columns[38].ColumnName),
                    PayerIdentityCard = dataRow.Field<string>(ds.Tables[0].Columns[39].ColumnName),
                    PayerPassport = dataRow.Field<string>(ds.Tables[0].Columns[40].ColumnName),
                    PayerWorkAddressProvinceID = dataRow.Field<string>(ds.Tables[0].Columns[41].ColumnName),
                    PayerWorkAddressProvinceDetail = dataRow.Field<string>(ds.Tables[0].Columns[42].ColumnName),
                    PayerWorkAddressDistrictID = dataRow.Field<string>(ds.Tables[0].Columns[43].ColumnName),
                    PayerWorkAddressDistrictDetail = dataRow.Field<string>(ds.Tables[0].Columns[44].ColumnName),
                    PayerWorkAddressSubDistrictID = dataRow.Field<string>(ds.Tables[0].Columns[45].ColumnName),
                    PayerWorkAddressSubDistrictDetail = dataRow.Field<string>(ds.Tables[0].Columns[46].ColumnName),
                    MotorApplicationStatusDetail = dataRow.Field<string>(ds.Tables[0].Columns[47].ColumnName),
                    PeriodTypeDetail = dataRow.Field<string>(ds.Tables[0].Columns[48].ColumnName),
                    CountingPaidNumber = dataRow.Field<string>(ds.Tables[0].Columns[49].ColumnName),
                    PayMethodTypeDetail = dataRow.Field<string>(ds.Tables[0].Columns[50].ColumnName),
                    PayerBankDetail = dataRow.Field<string>(ds.Tables[0].Columns[51].ColumnName),
                    PersonBankAccountNo = dataRow.Field<string>(ds.Tables[0].Columns[52].ColumnName),
                    VehicleModelDetail = dataRow.Field<string>(ds.Tables[0].Columns[53].ColumnName),
                    VehicleBrandDetail = dataRow.Field<string>(ds.Tables[0].Columns[54].ColumnName),
                    VehicleRegistrationDetail = dataRow.Field<string>(ds.Tables[0].Columns[55].ColumnName),
                    VehicleRegistrationNumber = dataRow.Field<string>(ds.Tables[0].Columns[56].ColumnName),
                    VehicleRegistrationProvince = dataRow.Field<string>(ds.Tables[0].Columns[57].ColumnName),
                    VehicleYear = dataRow.Field<string>(ds.Tables[0].Columns[58].ColumnName),
                    VehicleChassisNumber = dataRow.Field<string>(ds.Tables[0].Columns[59].ColumnName),
                    SumInsured = dataRow.Field<string>(ds.Tables[0].Columns[60].ColumnName),
                    VehicleSeat = dataRow.Field<string>(ds.Tables[0].Columns[61].ColumnName),
                    VehicleWeight = dataRow.Field<string>(ds.Tables[0].Columns[62].ColumnName),
                    VehicleCC = dataRow.Field<string>(ds.Tables[0].Columns[63].ColumnName),
                    SaleID = dataRow.Field<string>(ds.Tables[0].Columns[64].ColumnName),
                    CarOwnerID = dataRow.Field<string>(ds.Tables[0].Columns[65].ColumnName),
                    Branch = dataRow.Field<string>(ds.Tables[0].Columns[66].ColumnName),
                    CreatedDate = dataRow.Field<string>(ds.Tables[0].Columns[67].ColumnName),
                    PreviousPolicyNumber = dataRow.Field<string>(ds.Tables[0].Columns[68].ColumnName),
                    PolicyIssuedDate = dataRow.Field<string>(ds.Tables[0].Columns[69].ColumnName),
                    PolicyCreatedDate = dataRow.Field<string>(ds.Tables[0].Columns[70].ColumnName),
                    CancelledByEmployeeCode = dataRow.Field<string>(ds.Tables[0].Columns[71].ColumnName),
                    CancelledDate = dataRow.Field<string>(ds.Tables[0].Columns[72].ColumnName),
                    CancelledReason = dataRow.Field<string>(ds.Tables[0].Columns[73].ColumnName),

                    PolicyStartDateConvert = Convert.ToDateTime(dataRow.Field<string>(ds.Tables[0].Columns[8].ColumnName)),
                    StartDateConvert = Convert.ToDateTime(dataRow.Field<string>(ds.Tables[0].Columns[9].ColumnName)),
                    EndDateConvert = Convert.ToDateTime(dataRow.Field<string>(ds.Tables[0].Columns[10].ColumnName)),
                }).ToList();

                var watchBulk = System.Diagnostics.Stopwatch.StartNew();
                _dBContext.BulkInsert(motors);
                watchBulk.Stop();
                second2 = watchBulk.ElapsedMilliseconds / 1000;
                count = motors.Count();
            }

            watch.Stop();
            second = watch.ElapsedMilliseconds / 1000;

            Console.WriteLine($"Count = {count} ");
            Console.WriteLine($"process all {second} sec");
            Console.WriteLine($"process bulk {second2} sec");
        }
        private static void AgentInsert()
        {
            DbContextOptionsBuilder<AppDBContext> optionsBuilder = new DbContextOptionsBuilder<AppDBContext>();
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            AppDBContext _dBContext = new AppDBContext(optionsBuilder.Options);

            var watch = System.Diagnostics.Stopwatch.StartNew();

            IExcelDataReader reader = null;
            string FilePath = "D:/Files/Collection from Agent Report 20210323.xlsx";

            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            //Load file into a stream
            FileStream stream = File.Open(FilePath, FileMode.Open, FileAccess.Read);
            int count = 0;
            double second = 0;
            double second2 = 0;
            //Must check file extension to adjust the reader to the excel file type
            if (Path.GetExtension(FilePath).Equals(".xls"))
                reader = ExcelReaderFactory.CreateBinaryReader(stream);
            else if (Path.GetExtension(FilePath).Equals(".xlsx"))
                reader = ExcelReaderFactory.CreateOpenXmlReader(stream);

            if (reader != null)
            {
                //Fill DataSet
                DataSet ds = reader.AsDataSet(new ExcelDataSetConfiguration()
                {
                    ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                    {
                        UseHeaderRow = true
                    }
                });

                var agent = ds.Tables[0].AsEnumerable().Select(dataRow => new Agent
                {
                    AgentCode = dataRow.Field<string>(ds.Tables[0].Columns[0].ColumnName),
                    AgentName = dataRow.Field<string>(ds.Tables[0].Columns[1].ColumnName),
                    BranchTeam = dataRow.Field<string>(ds.Tables[0].Columns[2].ColumnName),
                    Telephone = dataRow.Field<string>(ds.Tables[0].Columns[3].ColumnName),
                    Email = dataRow.Field<string>(ds.Tables[0].Columns[4].ColumnName),
                    Bank = dataRow.Field<string>(ds.Tables[0].Columns[5].ColumnName),
                    BankAccountNo = dataRow.Field<string>(ds.Tables[0].Columns[6].ColumnName),
                    StatementID = dataRow.Field<string>(ds.Tables[0].Columns[7].ColumnName),
                    StatementFrom = dataRow.Field<string>(ds.Tables[0].Columns[8].ColumnName),
                    StatementTo = dataRow.Field<string>(ds.Tables[0].Columns[9].ColumnName),
                    BillingDate = Convert.ToDateTime(dataRow.Field<string>(ds.Tables[0].Columns[10].ColumnName)),
                    CollectionDate = Convert.ToDateTime(dataRow.Field<string>(ds.Tables[0].Columns[11].ColumnName)),
                    Amount = Convert.ToDouble(dataRow.Field<string>(ds.Tables[0].Columns[12].ColumnName)),
                    PayMode = dataRow.Field<string>(ds.Tables[0].Columns[13].ColumnName),
                    FailureReason = dataRow.Field<string>(ds.Tables[0].Columns[14].ColumnName),

                }).ToList();

                var watchBulk = System.Diagnostics.Stopwatch.StartNew();
                _dBContext.BulkInsert(agent);
                watchBulk.Stop();
                second2 = watchBulk.ElapsedMilliseconds / 1000;
                count = agent.Count();
            }

            watch.Stop();
            second = watch.ElapsedMilliseconds / 1000;

            Console.WriteLine($"Count = {count} ");
            Console.WriteLine($"process all {second} sec");
            Console.WriteLine($"process bulk {second2} sec");
        }
        private static void CustomerInsert()
        {
            DbContextOptionsBuilder<AppDBContext> optionsBuilder = new DbContextOptionsBuilder<AppDBContext>();
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            AppDBContext _dBContext = new AppDBContext(optionsBuilder.Options);

            var watch = System.Diagnostics.Stopwatch.StartNew();

            IExcelDataReader reader = null;
            string FilePath = "D:/Files/Collection from Customer Report 20210323.xlsx";

            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            //Load file into a stream
            FileStream stream = File.Open(FilePath, FileMode.Open, FileAccess.Read);
            int count = 0;
            double second = 0;
            double second2 = 0;
            //Must check file extension to adjust the reader to the excel file type
            if (Path.GetExtension(FilePath).Equals(".xls"))
                reader = ExcelReaderFactory.CreateBinaryReader(stream);
            else if (Path.GetExtension(FilePath).Equals(".xlsx"))
                reader = ExcelReaderFactory.CreateOpenXmlReader(stream);

            if (reader != null)
            {
                //Fill DataSet
                DataSet ds = reader.AsDataSet(new ExcelDataSetConfiguration()
                {
                    ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                    {
                        UseHeaderRow = true
                    }
                });

                var agent = ds.Tables[0].AsEnumerable().Select(dataRow => new Customer
                {
                    Insurer = dataRow.Field<string>(ds.Tables[0].Columns[0].ColumnName),
                    Product = dataRow.Field<string>(ds.Tables[0].Columns[1].ColumnName),
                    Plan = dataRow.Field<string>(ds.Tables[0].Columns[2].ColumnName),
                    Agent = dataRow.Field<string>(ds.Tables[0].Columns[3].ColumnName),
                    Branch = dataRow.Field<string>(ds.Tables[0].Columns[4].ColumnName),
                    PayerName = dataRow.Field<string>(ds.Tables[0].Columns[5].ColumnName),
                    PayerID = dataRow.Field<string>(ds.Tables[0].Columns[6].ColumnName),
                    Telephone = dataRow.Field<string>(ds.Tables[0].Columns[7].ColumnName),
                    Email = dataRow.Field<string>(ds.Tables[0].Columns[8].ColumnName),
                    AddressType = dataRow.Field<string>(ds.Tables[0].Columns[9].ColumnName),
                    Province = dataRow.Field<string>(ds.Tables[0].Columns[10].ColumnName),
                    District = dataRow.Field<string>(ds.Tables[0].Columns[11].ColumnName),
                    Subdistrict = dataRow.Field<string>(ds.Tables[0].Columns[12].ColumnName),
                    StreetAddress = dataRow.Field<string>(ds.Tables[0].Columns[13].ColumnName),
                    Insuredname = dataRow.Field<string>(ds.Tables[0].Columns[14].ColumnName),
                    QuotationNo = dataRow.Field<string>(ds.Tables[0].Columns[15].ColumnName),
                    PolicyNo = dataRow.Field<string>(ds.Tables[0].Columns[16].ColumnName),
                    PolicyIssueDate = dataRow.Field<string>(ds.Tables[0].Columns[17].ColumnName),
                    BillingDate = dataRow.Field<string>(ds.Tables[0].Columns[18].ColumnName),
                    CollectionDate = dataRow.Field<string>(ds.Tables[0].Columns[19].ColumnName),
                    CoverageDateFrom = dataRow.Field<string>(ds.Tables[0].Columns[20].ColumnName),
                    CoverageDateTo = dataRow.Field<string>(ds.Tables[0].Columns[21].ColumnName),
                    PremiumType = dataRow.Field<string>(ds.Tables[0].Columns[22].ColumnName),
                    PayMode = dataRow.Field<string>(ds.Tables[0].Columns[23].ColumnName),
                    PaymentStatus = dataRow.Field<string>(ds.Tables[0].Columns[24].ColumnName),
                    FailReasons = dataRow.Field<string>(ds.Tables[0].Columns[25].ColumnName),
                    GrossPremium = dataRow.Field<string>(ds.Tables[0].Columns[26].ColumnName),
                    VAT = dataRow.Field<string>(ds.Tables[0].Columns[27].ColumnName),
                    StampDuty = dataRow.Field<string>(ds.Tables[0].Columns[28].ColumnName),
                    TotalAmount = dataRow.Field<string>(ds.Tables[0].Columns[29].ColumnName),
                    BankHolderName = dataRow.Field<string>(ds.Tables[0].Columns[30].ColumnName),
                    BankName = dataRow.Field<string>(ds.Tables[0].Columns[31].ColumnName),
                    BankNumber = dataRow.Field<string>(ds.Tables[0].Columns[32].ColumnName),
                }).ToList();

                var watchBulk = System.Diagnostics.Stopwatch.StartNew();
                _dBContext.BulkInsert(agent);
                watchBulk.Stop();
                second2 = watchBulk.ElapsedMilliseconds / 1000;
                count = agent.Count();
            }

            watch.Stop();
            second = watch.ElapsedMilliseconds / 1000;

            Console.WriteLine($"Count = {count} ");
            Console.WriteLine($"process all {second} sec");
            Console.WriteLine($"process bulk {second2} sec");
        }
    }
}
