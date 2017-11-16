using System;
using System.IO;

namespace Carbon.Media
{
    public static class FileFormat
    {
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
                case "aif"  : return "aiff";
                case "fpix" : return "fpx";
                case "jpe"  : return "jpeg";
                case "jpg"  : return "jpeg";
                case "tif"  : return "tiff";
                case "mpg"  : return "mpeg";
                case "wave" : return "wav";

                default     : return format;
            }
        }

        public static string FromPath(string path)
        {
            #region Preconditions

            if (path == null) throw new ArgumentNullException(nameof(path));

            #endregion

            var extension = Path.GetExtension(path);

            return Normalize(extension);
        }
    }
}