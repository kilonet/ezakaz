using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace EZakaz.Server.Core
{
    public class ImageUtils
    {
        private const int THUMB_SIZE = 200;


        public static Image ResizeImage(string imageFileToResize)
        {
            Size size = Size.Empty;
            Image imgToResize = Image.FromFile(imageFileToResize);
            float scaleFactor = (float)Math.Max(imgToResize.Width, imgToResize.Height) / THUMB_SIZE;
            size.Height = (int)(imgToResize.Height / scaleFactor);
            size.Width = (int)(imgToResize.Width / scaleFactor);


            Bitmap b = new Bitmap(THUMB_SIZE, THUMB_SIZE);

            int x = (THUMB_SIZE - size.Width) / 2;
            int y = (THUMB_SIZE - size.Height) / 2;
            Graphics g = Graphics.FromImage(b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.FillRectangle(new SolidBrush(Color.White), 0, 0, THUMB_SIZE, THUMB_SIZE);
            g.DrawImage(imgToResize, x, y, size.Width, size.Height);
            g.Dispose();

            return b;
        }

        public static void SaveImageToFile(Image image, string path)
        {
            // Encoder parameter for image quality
            EncoderParameter qualityParam = new EncoderParameter(Encoder.Quality, 100L);

            // Jpeg image codec
            ImageCodecInfo jpegCodec = getEncoderInfo("image/jpeg");

            if (jpegCodec == null)
                return;

            EncoderParameters encoderParams = new EncoderParameters(1);
            encoderParams.Param[0] = qualityParam;

            image.Save(path, jpegCodec, encoderParams);
        }

        private static ImageCodecInfo getEncoderInfo(string mimeType)
        {
            // Get image codecs for all image formats
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();

            // Find the correct image codec
            for (int i = 0; i < codecs.Length; i++)
                if (codecs[i].MimeType == mimeType)
                    return codecs[i];
            return null;
        }
    }
}
