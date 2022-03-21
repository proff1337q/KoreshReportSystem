using System;
using System.IO;
using System.Reflection;

namespace ks2.Foundation
{
    /// <summary>
    ///  Класс PathUtils предназначен
    ///  для работы с путями и файлами
    /// </summary>
    public class PathUtils
    {
        /// <summary>
        ///  Путь директории, из которой запустилась программа
        /// </summary>
        public static string AssemblyDirectory => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        /// <summary>
        ///  Метод получения пути до файла в директории, из которой запустилась программа
        /// </summary>
        /// <param name="path">Дополнительный путь</param>
        public static FileInfo GetFileFromAssembly(string path) => new FileInfo(AssemblyDirectory + path);
    }
}
