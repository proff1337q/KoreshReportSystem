using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ks2.Foundation
{
    public static class StringUtils
    {
        /// <summary>
        ///  Метод разделения строки по указанному символу
        /// </summary>
        /// <param name="input">Входная строка</param>
        /// <param name="character">Символ-разделитель</param>
        public static string[] SplitBy(this string input, char character) => input.Split(new char[] { character });

        /// <summary>
        ///  Метод разделения строки по символу TAB
        /// </summary>
        /// <param name="input">Входная строка</param>
        public static string[] SplitByTab(this string input) => input.SplitBy('\t');
    }
}
