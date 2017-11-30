namespace Carbon.Media.Metadata
{
    using static MetaFormat;

    public class MetadataItemInfo
    {
        internal MetadataItemInfo(ExifTag tag, MetaFormat format = Ansi,  string description = null)
        {
            Name = tag.ToString();
            Code = (int)tag;
            Description = description;
            Converter = GetConverter(format);
        }

        public MetadataItemInfo(ExifTag tag, MetadataItemConverter converter)
        {
            Name      = tag.ToString();
            Code      = (int)tag;
            Converter = converter;
        }

        internal MetadataItemInfo(string name, MetaFormat format = Ansi)
            : this(name, GetConverter(format)) { }

        public MetadataItemInfo(string name, MetadataItemConverter converter)
        {
            Name      = name;
            Converter = converter;
        }

        public string Name { get; }

        public int Code { get; }

        public string Description { get; }

        public MetadataItemConverter Converter { get; }

        public object Normalize(object value)
        {
            if (value == null) return null;

            try
            {
                return Converter.Normalize(value);
            }
            catch
            {
                return null;
            }
        }

        private static MetadataItemConverter GetConverter(MetaFormat format)
        {
            switch (format)
            {
                case Ansi      : return MetadataItemConverter.Default;
                case Boolean   : return BooleanConverter.Default;
                case Short     : return MetadataItemConverter.Default;
                case Date      : return DateNormalizer.Default;
                case Rational  : return UnsignedRational.Default;
                case SRational : return SignedRational.Default;
                default        : return MetadataItemConverter.Default;
            }
        }
    }
}
