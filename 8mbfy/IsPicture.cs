using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _8mbfy
{
    internal class IsPicture
    {
        static public string isPicture(string filePath)
        {
            string fileEx = Path.GetExtension(filePath).ToLower();
            switch (fileEx)
            {
                case ".jpeg":
                case ".jpg":
                case ".png":
                case ".bmp":
                case ".gif":
                    return fileEx;
                    break;
                default:
                    return "";
                    break;
            }
        }

    }
}
