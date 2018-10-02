namespace Carbon.Media.Metadata.Exif
{
    public sealed class IntegerConverter : ExifValueConverter
    {
        public static new readonly IntegerConverter Default = new IntegerConverter();

        public override object Normalize(object value) => int.Parse(value.ToString());
    }
}