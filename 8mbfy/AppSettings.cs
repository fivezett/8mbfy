using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8mbfy
{
    internal class AppSettings
    {
        public float targetSize { get; set; }
        public bool alphaImgCnvJpg { get; set; }
        public int jpgQuality { get; set; }
        public bool fixidTop { get; set; }
        public bool autoCopy { get; set; }
        public bool autoDelete { get; set; }
        public bool autoExit { get; set; }
        public bool autoStart { get; set; }
        public bool skipCopy { get; set; }
    }
}
