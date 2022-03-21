using KoreshReportSystem.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ks2.Foundation;
using System.Text.RegularExpressions;

namespace KoreshReportSystem.Components
{
    public static class TextFileParser
    {

        public static IEnumerable<string> ReadLines1251(string filePath)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            return File.ReadAllLines(filePath, Encoding.GetEncoding(1251));
        }

        public static IEnumerable<string[]> PrepareLines(IEnumerable<string> lines)
        {
            return lines.Select(l => l.SplitByTab().Skip(2).ToArray());
        }

        public static DataTable ParseToDataTable(string filePath, HeaderType headerType)
        {
            var dataTable = new DataTable();
            var lines = PrepareLines(ReadLines1251(filePath)).ToList();

            string[] headers = null;

            switch (headerType)
            {
                case HeaderType.OneString:
                    {
                        headers = lines[0];

                        break;
                    }

                case HeaderType.DoubleString:
                    {
                        headers = lines[0].Zip(lines[1], (f, s) => f + " " + s).ToArray();

                        break;
                    }
            }

            // Добавляем столбцы
            dataTable.Columns.AddRange(headers.Select(h => new DataColumn(h)).ToArray());
            // Убираем заголовки
            lines = lines.Skip((int)headerType).ToList();
            // Добавляем строки
            lines.ForEach(l => dataTable.Rows.Add(l));

            return dataTable;
        }
    }
}
