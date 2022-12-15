using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8mbfy
{
    internal class Pickup
    {
        private static bool isDirectory(string filePath)
        {
            return File.GetAttributes(filePath).HasFlag(FileAttributes.Directory);
        }

        private static List<string> apply(string filePath)
        {
            List<string> fileList = new List<string>();
            Debug.WriteLine((isDirectory(filePath)) + filePath);
            if (isDirectory(filePath))
            {
                string[] files = Directory.GetFiles(filePath, "*", System.IO.SearchOption.AllDirectories);
                for (int i = 0; i < files.Length; i++)
                {
                    fileList.Add(files[i]);
                }
            }
            Console.WriteLine("Count:" + fileList.Count);
            return fileList;
        }

        public static List<String> main(String[] files)
        {
            List<string> fileList = new List<string>(files), addList = new List<string>();
            for (int i = 0; i < fileList.Count; i++)
            {
                Debug.WriteLine(fileList[i]);
                addList.AddRange(apply(fileList[i]));
            }
            fileList.AddRange(addList);
            fileList = fileList.FindAll(e => (IsPicture.isPicture(e) != "" ? true : false));
            return fileList;
        }
    }
}
