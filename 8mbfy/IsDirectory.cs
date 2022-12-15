using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8mbfy
{
    internal class IsDirectory
    {
        static public bool isDirectory(string filePath)
        {
            return File.GetAttributes(filePath).HasFlag(FileAttributes.Directory);
        }
    }
}
