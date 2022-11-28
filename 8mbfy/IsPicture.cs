using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _8mbfy
{
    internal class IsPicture
    {
        static public bool isPicture(string filePath)
        {
            if (IsDirectory.isDirectory(filePath))
                return false;
            string fileEx = Path.GetExtension(filePath).ToLower();
            switch (fileEx)
            {
                case ".jpeg":
                case ".jpg":
                case ".png":
                case ".bmp":
                case ".gif":
                    return true;
                    break;
                default:
                    return false;
                    break;
            }
        }

    }
}
