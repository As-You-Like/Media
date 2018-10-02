namespace Carbon.Media.Metadata.Exif
{
    public sealed class BooleanConverter : ExifValueConverter
    {
        public static new readonly BooleanConverter Default = new BooleanConverter();

        public override object Normalize(object value) => int.Parse(value.ToString().ToLower());
    }
}