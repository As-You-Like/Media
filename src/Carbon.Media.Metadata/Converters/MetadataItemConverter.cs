namespace Carbon.Media.Metadata
{
    public class MetadataItemConverter
    {
        public static readonly MetadataItemConverter Default = new MetadataItemConverter();

        public virtual object Normalize(object value) => value.ToString();
    }
}