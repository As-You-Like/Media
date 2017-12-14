namespace Carbon.Media.Metadata
{
    using static MetaFormat;

    public sealed class ExifTagInfo
    {
        public static readonly ExifTagInfo ColorSpace                = new ExifTagInfo(ExifTag.ColorSpace,                new NumberToEnum<ExifColorSpace>());
        public static readonly ExifTagInfo Compression               = new ExifTagInfo(ExifTag.Compression,               new NumberToEnum<ExifCompression>());
        public static readonly ExifTagInfo ExposureMode              = new ExifTagInfo(ExifTag.ExposureMode,              new NumberToEnum<ExposureMode>());
        public static readonly ExifTagInfo ExposureProgram           = new ExifTagInfo(ExifTag.ExposureProgram,           new NumberToEnum<ExposureProgram>());
        public static readonly ExifTagInfo FocalPlaneResolutionUnit  = new ExifTagInfo(ExifTag.FocalPlaneResolutionUnit,  new NumberToEnum<ResolutionUnit>());
        public static readonly ExifTagInfo GainControl               = new ExifTagInfo(ExifTag.GainControl,               new NumberToEnum<GainControl>());          
        public static readonly ExifTagInfo LightSource               = new ExifTagInfo(ExifTag.LightSource,               new NumberToEnum<LightSource>());
        public static readonly ExifTagInfo Orientation               = new ExifTagInfo(ExifTag.Orientation,               new NumberToEnum<ExifOrientation>());
        public static readonly ExifTagInfo MeteringMode              = new ExifTagInfo(ExifTag.MeteringMode,              new NumberToEnum<MeteringMode>());
        public static readonly ExifTagInfo PhotometricInterpretation = new ExifTagInfo(ExifTag.PhotometricInterpretation, new NumberToEnum<PhotometricInterpretation>());
        public static readonly ExifTagInfo PlanarConfiguration       = new ExifTagInfo(ExifTag.PlanarConfiguration,       new NumberToEnum<PlanarConfiguration>());
        public static readonly ExifTagInfo ResolutionUnit            = new ExifTagInfo(ExifTag.ResolutionUnit,            new NumberToEnum<ResolutionUnit>());
        public static readonly ExifTagInfo SceneCaptureType          = new ExifTagInfo(ExifTag.SceneCaptureType,          new NumberToEnum<SceneCaptureType>());
        public static readonly ExifTagInfo SensingMethod             = new ExifTagInfo(ExifTag.SensingMethod,             new NumberToEnum<SensingMethod>());
        public static readonly ExifTagInfo SensitivityType           = new ExifTagInfo(ExifTag.SensitivityType,           new NumberToEnum<SensitivityType>());
        public static readonly ExifTagInfo SubjectDistanceRange      = new ExifTagInfo(ExifTag.SubjectDistanceRange,      new NumberToEnum<SubjectDistanceRange>());
        public static readonly ExifTagInfo SubfileType               = new ExifTagInfo(ExifTag.SubfileType,               new NumberToEnum<SubfileType>());
        public static readonly ExifTagInfo WhiteBalance              = new ExifTagInfo(ExifTag.WhiteBalance,              new NumberToEnum<WhiteBalance>());

        internal ExifTagInfo(ExifTag tag, MetaFormat format = Ansi, string description = null)
        {
            Name = tag.ToString();
            Code = (int)tag;
            Description = description;
            Converter = GetConverter(format);
        }

        public ExifTagInfo(ExifTag tag, MetadataItemConverter converter)
        {
            Name      = tag.ToString();
            Code      = (int)tag;
            Converter = converter;
        }

        internal ExifTagInfo(string name, MetaFormat format = Ansi)
            : this(name, GetConverter(format)) { }

        public ExifTagInfo(string name, MetadataItemConverter converter)
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
