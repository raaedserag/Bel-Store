using Microsoft.Office.Interop.Excel;

using System;
using System.Runtime.InteropServices;

namespace Belal.Helpers
{
    class ExcelPrinter
    {
        public void print_file()
        {
            Application excel = new Application();
            Workbook wb = excel.Workbooks.Open(Environment.GetEnvironmentVariable("belal_file_location", EnvironmentVariableTarget.User) + "\\test1.xlsx",
                CorruptLoad: true);
            Worksheet sheet = (Worksheet)wb.Worksheets.get_Item(1);

            sheet.PrintOut(
            Type.Missing, Type.Missing, Type.Missing, Type.Missing,
            Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            // Cleanup:
            GC.Collect();
            GC.WaitForPendingFinalizers();

            Marshal.FinalReleaseComObject(sheet);

            wb.Close(false, Type.Missing, Type.Missing);
            Marshal.FinalReleaseComObject(wb);

            excel.Quit();
            Marshal.FinalReleaseComObject(excel);
        }
    }



    
}
