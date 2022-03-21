using KoreshReportSystem.Components;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using KoreshReportSystem.Common;

namespace KoreshReportSystem.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public string Header { get; set; }

        public MainWindowViewModel()
        {
            Header = "KoreshReportSystem";

            var excelProvider = new ExcelProvider();
            // Открытие файла, изменение информации и сохранение файла
            // Assembly/Resources/ExcelTemplates/Test.xlsx
            //excelProvider.TestOpenFile();

            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                var filePath = openFileDialog.FileName;
                var dataTable = TextFileParser.ParseToDataTable(filePath, HeaderType.DoubleString);
            }
        }
    }
}
