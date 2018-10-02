using System;

namespace Carbon.Media.Metadata.Exif
{
    public sealed class NumberToEnumConverter<T> : ExifValueConverter
    {
        public override object Normalize(object value)
        {
            return Enum.ToObject(typeof(T), int.Parse(value.ToString()));
        }
    }
}