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

            #endregion

            if (format[0] == '.')
            {
                format = format.Substring(1);
            }

            // Ensure the file is lowercased
            if (!format.IsLowercase())
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

        private static bool IsLowercase(this string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (!char.IsLower(input[i])) return false;
            }

            return true;
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