using AventStack.ExtentReports.MarkupUtils;

using ExcelDataReader;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace HybridCSharpFramework
{
    [TestFixture]
    [Parallelizable]
    public class GetDataFromExcel
    {
        private static DataTable ExcelToDataTable(string filename)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            FileStream stream = File.Open(filename, FileMode.Open, FileAccess.Read);
            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

            DataSet resultSet = excelReader.AsDataSet(new ExcelDataSetConfiguration()
            {
                ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                {
                    UseHeaderRow = true
                }
            });
            DataTableCollection table = resultSet.Tables;
            DataTable resultTable = table["Sheet1"];
            return resultTable;
        }
        public class Datacollection
        {
            public int rowNumber { get; set; }
            public string colName { get; set; }
            public string colValue { get; set; }
        }
        static List<Datacollection> dataCol = new List<Datacollection>();
        static int totalRowCount = 0;
        private string filePath;

        public GetDataFromExcel(string filePath)
        {
            this.filePath = filePath;
        }

        //function to throw us the total count of row
        public static int GetTotalRowCount()
        {
            return totalRowCount;
        }
        public static void PopulateInCollection(string filename)
        {
            DataTable table = ExcelToDataTable(filename);
            totalRowCount = table.Rows.Count;
            //table.Rows.Count=give us the maximum number of rows
            //Datacollection dtTable = new Datacollection:store all the values(columnName nd value)
            for (int row = 1; row <= table.Rows.Count; row++)
            {
                for (int col = 0; col < table.Columns.Count; col++)
                {
                    Datacollection dtTable = new Datacollection()
                    {
                        rowNumber = row,
                        colName = table.Columns[col].ColumnName,
                        colValue = table.Rows[row - 1][col].ToString()
                    };
                    dataCol.Add(dtTable);
                }
            }
        }
        public static string ReadData(int rowNumber, string columnName)
        {
            try
            {
                string data = (from colData in dataCol where colData.colName == columnName && colData.rowNumber == rowNumber select colData.colValue).SingleOrDefault();
                return data.ToString();
            }
            catch (Exception e)
            {
                return null;
            }
        }







    }
}
