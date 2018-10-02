namespace Carbon.Media.Metadata.Exif
{
    public class ExifValueConverter
    {
        public static readonly ExifValueConverter Default = new ExifValueConverter();

        public virtual object Normalize(object value) => value.ToString();

        internal static ExifValueConverter Get(ExifTagFormat format)
        {
            switch (format)
            {
                case ExifTagFormat.Ansi     : return ExifValueConverter.Default;
                case ExifTagFormat.Boolean  : return BooleanConverter.Default;
                case ExifTagFormat.Short     : return ExifValueConverter.Default;
                case ExifTagFormat.Date      : return DateNormalizer.Default;
                case ExifTagFormat.Rational  : return UnsignedRationalConverter.Default;
                case ExifTagFormat.SRational : return SignedRationalConverter.Default;
                default                      : return ExifValueConverter.Default;
            }
        }
    }
}