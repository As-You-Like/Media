using System;

namespace Carbon.Media.Metadata
{
    using static MetaFormat;

    public class MetadataItemInfo
    {
        internal MetadataItemInfo(string name, MetaFormat format = Ansi, int code = 0, string description = null)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Code = code;
            Description = description;
            Converter = GetConverter(format);
        }

        public MetadataItemInfo(string name, MetadataItemConverter converter)
        {
            Name = name;
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
