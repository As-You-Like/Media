namespace Carbon.Media.Metadata
{
    public class MetadataItemInfo
    {
        private readonly string name;
        private readonly int code;
        private readonly MetadataItemConverter converter;
        private readonly string description;

        public MetadataItemInfo(string name, MetaFormat format = MetaFormat.Ansi, int code = 0, string description = null)
        {
            this.name = name;
            this.code = code;
            this.description = description;

            switch (format)
            {
                case MetaFormat.Ansi: this.converter = new MetadataItemConverter(); break;
                case MetaFormat.Boolean: this.converter = new BooleanConverter(); break;
                case MetaFormat.Short: this.converter = new MetadataItemConverter(); break;
                case MetaFormat.Date: this.converter = new DateNormalizer(); break;
                case MetaFormat.Rational: this.converter = new UnsignedRational(); break;
                case MetaFormat.SRational: this.converter = new SignedRational(); break;
                default: this.converter = new MetadataItemConverter(); break;
            }
        }

        public MetadataItemInfo(string name, MetadataItemConverter converter)
        {
            this.name = name;
            this.converter = converter;
        }

        public string Name => name;

        public object Normalize(object value)
        {
            if (value == null) return null;

            try
            {
                return this.converter.Normalize(value);
            }
            catch
            {
                return null;
            }
        }
    }
}
