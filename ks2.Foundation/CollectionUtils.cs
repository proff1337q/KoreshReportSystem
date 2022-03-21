using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ks2.Foundation
{
    public static class CollectionUtils
    {
        /// <summary>
        ///  Использование: itemArray.ForEach( ( item, n ) => {} );
        /// </summary>
        /// <typeparam name="T">Тип элементов последовательности</typeparam>
        /// <param name="source">последовательность</param>
        /// <param name="action">Действие для каждого элемента последовательности. Принимает текущий элемент последовательности и индекс этого элемента в последовательности</param>
        public static void ForEach<T>(this IEnumerable<T> source, Action<T, int> action)
        {
            int i = 0;
            foreach (var e in source) action(e, i++);
        }
    }
}
