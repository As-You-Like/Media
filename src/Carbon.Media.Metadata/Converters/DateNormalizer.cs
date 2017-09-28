using System;
using System.Globalization;

namespace Carbon.Media.Metadata
{
    internal sealed class DateNormalizer : MetadataItemConverter
    {
        public static readonly new DateNormalizer Default = new DateNormalizer();

        public override object Normalize(object value)
        {
            // 2010:07:24 15:05:03

            var date = DateTime.ParseExact(value.ToString(), "yyyy:MM:dd HH:mm:ss", null, DateTimeStyles.AssumeUniversal);

            return date.ToString("yyyy-MM-ddTHH:mm:ssZ");
        }
    }
}