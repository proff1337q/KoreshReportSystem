using KoreshReportSystem.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            excelProvider.TestOpenFile();
        }
    }
}
