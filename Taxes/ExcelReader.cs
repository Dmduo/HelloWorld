using System;
using System.Collections.Generic;
using Taxes.Models;
using Excel = Microsoft.Office.Interop.Excel;

namespace Taxes
{
    class ExcelReader : IReader
    {
        static Excel.Workbook myBook = null;
        static Excel.Application myApp = null;
        static Excel.Worksheet mySheet = null;
        List<Tax> taxlist = new List<Tax>();

        public List<Tax> Open()
        {
            string filePath = @"D:\Taxes.xls";
            myApp = new Excel.Application();
            myApp.Visible = false;
            myBook = myApp.Workbooks.Open(filePath);
            mySheet = (Excel.Worksheet)myBook.Sheets[1];
            var lastRow = mySheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Row;

            ReadExcelTo(lastRow);
            
            return taxlist;

        }

        void ReadExcelTo(int lastRow)
        {
            var documentFirstRow = 2;

            for (int index = documentFirstRow; index <= lastRow; index++)
            {
                Array myValues = (Array)mySheet.get_Range("A" + index.ToString(), "I" + index.ToString()).Cells.Value;
                taxlist.Add(new Tax
                {
                    Country = myValues.GetValue(1, 1).ToString(),
                    IncomeTax = Convert.ToDouble(myValues.GetValue(1, 2).ToString()),
                    IncomeTaxPercentageAfterLimit = Convert.ToDouble(myValues.GetValue(1, 3).ToString()),
                    IncomeTaxLimit = Convert.ToDouble(myValues.GetValue(1, 4).ToString()),
                    UniversalSocialCharge = Convert.ToDouble(myValues.GetValue(1, 5).ToString()),
                    UniversalSocialChargePercentageAfterLimit = Convert.ToDouble(myValues.GetValue(1, 6).ToString()),
                    UniversalSocialChargeLimit = Convert.ToDouble(myValues.GetValue(1, 7).ToString()),
                    Inps = Convert.ToDouble(myValues.GetValue(1, 8).ToString()),
                    Pension = Convert.ToDouble(myValues.GetValue(1, 9).ToString())
                });
            }
            myBook.Close(true);
            myApp.Quit();
        }
    }
}
