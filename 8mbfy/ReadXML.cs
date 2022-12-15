using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _8mbfy
{
    internal class ReadXML
    {
        public static AppSettings main()
        {
            //appsettings.xmlを読み込みパースして、AppSettingsで返す。
            XDocument xdoc = XDocument.Load("appsettings.xml");
            AppSettings appSettings = new AppSettings();
            appSettings.targetSize = float.Parse(xdoc.Root.Element("targetSize").Value);
            appSettings.alphaImgCnvJpg = bool.Parse(xdoc.Root.Element("alphaImgCnvJpg").Value);
            appSettings.jpgQuality = int.Parse(xdoc.Root.Element("jpgQuality").Value);
            appSettings.fixidTop = bool.Parse(xdoc.Root.Element("fixidTop").Value);
            appSettings.autoCopy = bool.Parse(xdoc.Root.Element("autoCopy").Value);
            appSettings.autoDelete = bool.Parse(xdoc.Root.Element("autoDelete").Value);
            appSettings.autoExit = bool.Parse(xdoc.Root.Element("autoExit").Value);
            appSettings.autoStart = bool.Parse(xdoc.Root.Element("autoStart").Value);
            appSettings.skipCopy = bool.Parse(xdoc.Root.Element("skipCopy").Value);
            
            return appSettings;
        }
    }
}
