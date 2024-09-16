using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace kalendarz
{
    internal class FileManager
    {
        static FileManager(){
            string path = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "data.txt");
            string[] pathAsArr = path.Split('\\');
            path = string.Join("\\", pathAsArr.Take(pathAsArr.Length - 3));
            Console.WriteLine(path);
            path += "\\data.txt";
            Path=path;
        }
        private static string Path;
        public static void SaveToFile(string content)
        {
            System.IO.File.WriteAllText(Path, content);
        }

        public static string ReadFromFile()
        {
            return System.IO.File.ReadAllText(Path);
        }
    }
}
