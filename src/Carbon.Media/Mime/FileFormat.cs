using System;
using System.IO;

namespace Carbon.Media
{
    public static class FileFormat
    {
        private static readonly string[] compressableFormats = { "appcache", "atom", "css", "csv", "html", "js", "json", "txt", "xml" };

        public static string Normalize(string format)
        {
            #region Preconditions

            if (format == null)
                throw new ArgumentNullException(nameof(format));

            if (format.Length == 0)
                throw new ArgumentException("Must not be empty", nameof(format));

            #endregion

            if (format[0] == '.')
            {
                format = format.Substring(1);
            }

            // Ensure the format is in lowercase
            if (!format.IsLower())
            {
                format = format.ToLower();
            }
            
            switch (format)
            {
                case "jpg": return "jpeg";
                case "tif": return "tiff";
                case "mpg": return "mpeg";

                default: return format;
            }
        }

        public static bool IsCompressible(string format)
            => Array.BinarySearch(compressableFormats, format) > 0;

        public static string FromPath(string path)
        {
            var extension = Path.GetExtension(path);

            return Normalize(extension);
        }
    }
}