using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace _8mbfy
{
    internal class ImageCompressor
    {
        private int targettingFileSize = 1024 * 1024 * 8;
        private AppSettings settings;
        private ImageCodecInfo jpgEncoder;

        public ImageCompressor(AppSettings sett)
        {
            settings = sett;
            targettingFileSize = (int)(settings.targetSize * 1024 * 1024);
            foreach (ImageCodecInfo ici in ImageCodecInfo.GetImageEncoders())
            {
                if (ici.FormatID == ImageFormat.Jpeg.Guid)
                {
                    jpgEncoder = ici;
                    break;
                }
            }
        }

        public KeyValuePair<MemoryStream, string> cnv(string name)
        {
            using (Image image = Image.FromFile(name))
            {
                // PixelFormat プロパティを確認する
                if (isPicture(name) == ".png")
                    if (image.PixelFormat.HasFlag(PixelFormat.Alpha) && !settings.alphaImgCnvJpg)
                    {
                        var png = GetStreamAndFileSize(image, ImageFormat.Png);
                        png.Key.Dispose();
                        return new KeyValuePair<MemoryStream, string>(imageCmp(image, ".png", png.Value), ".png");
                    }
                    else
                    {
                        Debug.WriteLine("PNG->JPG");
                        var jpg = GetStreamAndFileSize(image, ImageFormat.Jpeg);
                        jpg.Key.Dispose();
                        return new KeyValuePair<MemoryStream, string>(imageCmp(image, ".jpg", jpg.Value), ".jpg");
                    }
                else if (isPicture(name) == ".jpg")
                {
                    var jpg = GetStreamAndFileSize(image, ImageFormat.Jpeg);
                    jpg.Key.Dispose();
                    return new KeyValuePair<MemoryStream, string>(imageCmp(image, ".jpg", jpg.Value), ".jpg");
                }
            }
            return new KeyValuePair<MemoryStream, string>(null, null);
        }

        public MemoryStream imageCmp(Image image, String type, int size)
        {
            var imgF = (type == ".png" ? ImageFormat.Png : ImageFormat.Jpeg);

            Debug.WriteLine(size + " " + targettingFileSize);
            if (size < targettingFileSize)
            {
                Debug.WriteLine("リサイズ不要");
                return GetStreamAndFileSize(image, imgF).Key;
            }

            int i = 0;
            while (size >= targettingFileSize)
            {
                Console.WriteLine(i++);
                double per = Math.Min(Math.Sqrt((double)targettingFileSize / (double)size), 0.99);
                int h = Math.Min((int)(image.Height * per), image.Height - 1);
                int w = Math.Min((int)(image.Width * per), image.Width - 1);
                var bit = new Bitmap(w, h);
                Graphics graphics = Graphics.FromImage(bit);
                graphics.InterpolationMode = InterpolationMode.High;
                graphics.DrawImage(image, 0, 0, w, h);
                var x = GetStreamAndFileSize(bit, imgF);
                size = x.Value;
                image = bit;
                if (!(size >= targettingFileSize))
                {
                    return x.Key;
                }
                x.Key.Dispose();
            }
            return new MemoryStream();
        }


        public KeyValuePair<MemoryStream, int> GetStreamAndFileSize(Image img, ImageFormat usingEnc)
        {
            var ms = new System.IO.MemoryStream();
            EncoderParameters encoderParams = new EncoderParameters(1);
            encoderParams.Param[0] = new EncoderParameter(Encoder.Quality, settings.jpgQuality);

            if (usingEnc == ImageFormat.Jpeg)
            {
                img.Save(ms, jpgEncoder, encoderParams);
            }
            else
            {
                img.Save(ms, usingEnc);
            }
            return new KeyValuePair<MemoryStream, int>(ms, (int)ms.Length);

        }

        static public string isPicture(string filePath)
        {
            string fileEx = Path.GetExtension(filePath).ToLower();
            switch (fileEx)
            {
                case ".jpeg":
                case ".jpg":
                    return ".jpg";
                    break;

                case ".png":
                case ".bmp":
                case ".gif":
                    return ".png";
                    break;

                default:
                    return "";
                    break;
            }

        }
    }
}
