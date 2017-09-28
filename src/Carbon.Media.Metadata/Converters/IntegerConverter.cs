namespace Carbon.Media.Metadata
{
    public sealed class IntegerConverter : MetadataItemConverter
    {
        public static new readonly IntegerConverter Default = new IntegerConverter();

        public override object Normalize(object value) => int.Parse(value.ToString());
    }
}