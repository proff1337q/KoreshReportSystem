using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using KoreshReportSystem.Common;
using OfficeOpenXml;

namespace KoreshReportSystem.Components
{
    public class ExcelProvider
    {
        public ExcelProvider()
        {
            // Используем некоммерческую лицензию
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            //_testOpenFile();
        }

        private void _testOpenFile()
        {
            var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var file = new FileInfo(assemblyPath + "/Resources/ExcelTemplates/Test.xlsx");
            using (var package = new ExcelPackage(file))
            {
                var sheet = package.Workbook.Worksheets.Add("My Sheet");
                sheet.Cells["A1"].Value = "Hello World!";

                // Save to file
                package.Save();
            }
        }
    }
}
