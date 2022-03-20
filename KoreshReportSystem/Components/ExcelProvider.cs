using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using KoreshReportSystem.Common;
using ks2.Foundation;
using OfficeOpenXml;

namespace KoreshReportSystem.Components
{
    public class ExcelProvider
    {
        public ExcelProvider()
        {
            // Используем некоммерческую лицензию
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }

        public void TestOpenFile()
        {
            var file = PathUtils.GetFileFromAssembly("/Resources/ExcelTemplates/Test.xlsx");

            using (var package = new ExcelPackage(file))
            {
                var sheet = package.Workbook.Worksheets.Add(DateTime.Now.Date.ToString());
                sheet.Cells["A1"].Value = DateTime.Now.ToString();

                // Save to file
                package.Save();
            }
        }
    }
}
