namespace Carbon.Media.Metadata
{
    public sealed class BooleanConverter : MetadataItemConverter
    {
        public static new readonly BooleanConverter Default = new BooleanConverter();

        public override object Normalize(object value) => int.Parse(value.ToString().ToLower());
    }
}