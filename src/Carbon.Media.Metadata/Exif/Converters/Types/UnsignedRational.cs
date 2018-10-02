using System;

namespace Carbon.Media.Metadata.Exif
{
    public sealed class UnsignedRationalConverter : ExifValueConverter
    {
        public new static readonly UnsignedRationalConverter Default = new UnsignedRationalConverter();

        public override object Normalize(object value)
        {
            if (value is null) return "null";

            var data = BitConverter.GetBytes((UInt64)value);

            // UInt64

            uint num = BitConverter.ToUInt32(data, 0); // uint32
            uint den = BitConverter.ToUInt32(data, 4);

            var x = 0d;

            if (den != 0)
            {
                x = ((double)num / (double)den);
            }

            return x.ToString();
        }
    }
}