using System;
using System.Globalization;
using System.IO;
using System.Web;
using System.Xml.Serialization;

namespace EZakaz.Server.Core.Web
{
    public static class WebUtils
    {
        #region Const

        private const string DEFAULT_CONTENT_TYPE = "application/octet-stream";

        #endregion

        #region SendFile methods

        public static void SendFileContent(HttpContext context, Stream streamToSend, string filename)
        {
            SendFileContent(context, streamToSend, filename, DEFAULT_CONTENT_TYPE);
        }

        public static void SendFileContent(HttpContext context, Stream streamToSend, string filename, string contentType)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (streamToSend == null) throw new ArgumentNullException("streamToSend");
            if (filename == null) throw new ArgumentNullException("filename");
            if (contentType == null) throw new ArgumentNullException("contentType");

            AddFileHeaders(context, contentType, filename);

            const int _chunkSize = 1024 * 300; // 300Kb

            int startAt = 0;
            if (context.Request.Headers["Range"] != null)
            {
                context.Response.StatusCode = 206;
                context.Response.StatusDescription = "Partial Content";
                startAt = int.Parse(
                    context.Request.Headers["Range"].Replace("bytes=", "")
                        .Replace("-", ""),
                    NumberStyles.AllowLeadingWhite
                    | NumberStyles.AllowTrailingWhite);
            }

            long _dataToWrite = streamToSend.Length;
            if (startAt > 0)
            {
                context.Response.AddHeader(
                    "Content-Range",
                    string.Format("bytes {0}-{1}/{2}",
                                  startAt,
                                  _dataToWrite - 1,
                                  _dataToWrite));
                _dataToWrite -= startAt;
            }
            else startAt = 0;

            context.Response.AddHeader("Content-Length", _dataToWrite.ToString());
            context.Response.AddHeader("ETag", (filename + streamToSend.Length).GetHashCode().ToString("x")); //not required

            streamToSend.Position = startAt;
            byte[] buffer = new byte[_chunkSize];

            while (_dataToWrite > 0 && context.Response.IsClientConnected)
            {
                int length = streamToSend.Read(buffer, 0, _chunkSize);

                context.Response.OutputStream.Write(buffer, 0, length);
                context.Response.Flush();

                _dataToWrite -= length;
            }
        }

        #endregion

        #region TransmiteFile methods

        public static void TransmitFile(HttpContext context, string src)
        {
            TransmitFile(context, src, DEFAULT_CONTENT_TYPE);
        }

        public static void TransmitFile(HttpContext context, string src, string contentType)
        {
            if (src == null) throw new ArgumentNullException("src");

            TransmitFile(context, src, contentType, Path.GetFileName(src));
        }

        public static void TransmitFile(HttpContext context, string src, string contentType, string filename)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (src == null) throw new ArgumentNullException("src");
            if (contentType == null) throw new ArgumentNullException("contentType");
            if (filename == null) throw new ArgumentNullException("filename");

            AddFileHeaders(context, contentType, filename);
            context.Response.TransmitFile(src);
        }

        #endregion

        #region Serialization methods

        public static string Object2StringSerialize<TType>(TType obj)
        {
            using (MemoryStream memStream = new MemoryStream())
            {
                new XmlSerializer(typeof(TType)).Serialize(memStream, obj);
                string encoded = Convert.ToBase64String(memStream.GetBuffer(), Base64FormattingOptions.None);
                return encoded;
            }
        }

        public static TType String2ObjectDeserialize<TType>(string encoded)
        {
            using (MemoryStream memStream = new MemoryStream(Convert.FromBase64String(encoded)))
            {
                TType decoded = (TType)new XmlSerializer(typeof(TType)).Deserialize(memStream);
                return decoded;
            }
        }

        #endregion

        #region Helpers

        private static void AddFileHeaders(HttpContext context, string contentType, string filename)
        {
            context.Server.ScriptTimeout = 6000;
            context.Response.Clear();
            context.Response.ContentType = contentType;
            context.Response.AddHeader("Content-Disposition",
                                       "attachment; filename=" +
                                       HttpUtility.UrlEncode(context.Request.ContentEncoding.GetBytes(filename)));
        }

        #endregion
    }
}