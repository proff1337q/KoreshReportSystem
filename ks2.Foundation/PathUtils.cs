using System;
using System.IO;
using System.Reflection;

namespace ks2.Foundation
{
    /// <summary>
    ///  ����� PathUtils ������������
    ///  ��� ������ � ������ � �������
    /// </summary>
    public class PathUtils
    {
        /// <summary>
        ///  ���� ����������, �� ������� ����������� ���������
        /// </summary>
        public static string AssemblyDirectory => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        /// <summary>
        ///  ����� ��������� ���� �� ����� � ����������, �� ������� ����������� ���������
        /// </summary>
        /// <param name="path">�������������� ����</param>
        public static FileInfo GetFileFromAssembly(string path) => new FileInfo(AssemblyDirectory + path);
    }
}
