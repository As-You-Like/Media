using System;

namespace Carbon.Media.Metadata
{
    public sealed class SignedRational : MetadataItemConverter
    {
        public static readonly new SignedRational Default = new SignedRational();

        public override object Normalize(object value)
        {
            if (value == null) return "null";

            var data = BitConverter.GetBytes((UInt64)value);

            int num = BitConverter.ToInt32(data, 0);
            int den = BitConverter.ToInt32(data, 4);

            var x = 0d;

            if (den != 0)
            {
                x = ((double)num / den);
            }

            // NaN Check

            return x.ToString();
        }
    }
}