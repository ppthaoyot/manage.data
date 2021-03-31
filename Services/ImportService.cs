using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using EFCore.BulkExtensions;
using ExcelDataReader;
using ReadExcelFiles.Data;
using ReadExcelFiles.Models;

namespace ReadExcelFiles.Services
{
    public class ImportService : IImportService
    {
        private readonly AppDBContext _dBContext;
        public ImportService(AppDBContext dBContext)
        {
            _dBContext = dBContext;
        }
        public void EndorsementInsert()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            IExcelDataReader reader = null;
            string FilePath = "D:/Files/Endorsement Report 20210323 - backup.xlsx";

            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            //Load file into a stream
            FileStream stream = File.Open(FilePath, FileMode.Open, FileAccess.Read);
            int count = 0;
            //Must check file extension to adjust the reader to the excel file type
            if (Path.GetExtension(FilePath).Equals(".xls"))
                reader = ExcelReaderFactory.CreateBinaryReader(stream);
            else if (Path.GetExtension(FilePath).Equals(".xlsx"))
                reader = ExcelReaderFactory.CreateOpenXmlReader(stream);

            if (reader != null)
            {
                //Fill DataSet
                DataSet ds = reader.AsDataSet();

                var endorse = ds.Tables[0].AsEnumerable().Select(dataRow => new Endorsement
                {
                    //RefNumber = dataRow.Field<string>("Name")
                    RefNumber = dataRow.Field<string>(ds.Tables[0].Columns[0].ColumnName),
                    PolicyNumber = dataRow.Field<string>(ds.Tables[0].Columns[1].ColumnName),
                    ProductDetail = dataRow.Field<string>(ds.Tables[0].Columns[2].ColumnName),
                    StartCover = dataRow.Field<string>(ds.Tables[0].Columns[3].ColumnName),
                    EndCover = dataRow.Field<string>(ds.Tables[0].Columns[4].ColumnName),
                    CustName = dataRow.Field<string>(ds.Tables[0].Columns[5].ColumnName),
                    ModelType = dataRow.Field<string>(ds.Tables[0].Columns[6].ColumnName),
                    PlateProvince = dataRow.Field<string>(ds.Tables[0].Columns[7].ColumnName),
                    VehicleChassisNumber = dataRow.Field<string>(ds.Tables[0].Columns[8].ColumnName),
                    VehicleEngineNumber = dataRow.Field<string>(ds.Tables[0].Columns[9].ColumnName),
                    EndosementType = dataRow.Field<string>(ds.Tables[0].Columns[10].ColumnName),
                    ChangeDetails = dataRow.Field<string>(ds.Tables[0].Columns[11].ColumnName),
                    Remark = dataRow.Field<string>(ds.Tables[0].Columns[12].ColumnName),
                    Status = dataRow.Field<string>(ds.Tables[0].Columns[13].ColumnName),
                    AgentID = dataRow.Field<string>(ds.Tables[0].Columns[14].ColumnName),
                    Branch = dataRow.Field<string>(ds.Tables[0].Columns[15].ColumnName),
                    Approver = dataRow.Field<string>(ds.Tables[0].Columns[16].ColumnName)
                }).ToList();

                //remove index 0 (header)
                endorse.RemoveAt(0);
                // count = endorse.Count();
                _dBContext.BulkInsert(endorse);
            }

            watch.Stop();
            double second = watch.ElapsedMilliseconds / 1000;
            Console.WriteLine($"Count = {count} ");
            Console.WriteLine($"{second} sec");
        }
    }
}