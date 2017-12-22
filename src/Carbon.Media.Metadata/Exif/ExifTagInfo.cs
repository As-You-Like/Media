namespace Carbon.Media.Metadata
{
    using static MetaFormat;

    public sealed class ExifTagInfo
    {
        public static readonly ExifTagInfo ApertureValue             = new ExifTagInfo(ExifTag.ApertureValue,             Rational);
        public static readonly ExifTagInfo Artist                    = new ExifTagInfo(ExifTag.Artist,                    Ansi, count: -1);
        public static readonly ExifTagInfo BrightnessValue           = new ExifTagInfo(ExifTag.BrightnessValue,           Rational);
        public static readonly ExifTagInfo ColorSpace                = new ExifTagInfo(ExifTag.ColorSpace,                new NumberToEnum<ExifColorSpace>());
        public static readonly ExifTagInfo Contrast                  = new ExifTagInfo(ExifTag.Contrast,                  new NumberToEnum<ExifContrast>());
        public static readonly ExifTagInfo Compression               = new ExifTagInfo(ExifTag.Compression,               new NumberToEnum<ExifCompression>());
        public static readonly ExifTagInfo Copyright                 = new ExifTagInfo(ExifTag.Artist,                    Ansi, count: -1);
        public static readonly ExifTagInfo CustomRendered            = new ExifTagInfo(ExifTag.CustomRendered,            new NumberToEnum<ExifCustomRendered>());
        public static readonly ExifTagInfo DigitalZoomRatio          = new ExifTagInfo(ExifTag.DigitalZoomRatio,          Rational, count: 1);
        public static readonly ExifTagInfo ExifVersion               = new ExifTagInfo(ExifTag.ExifVersion,               Any);
        public static readonly ExifTagInfo ExposureIndex             = new ExifTagInfo(ExifTag.ExposureIndex,             Rational);
        public static readonly ExifTagInfo ExposureMode              = new ExifTagInfo(ExifTag.ExposureMode,              new NumberToEnum<ExifExposureMode>());
        public static readonly ExifTagInfo ExposureTime              = new ExifTagInfo(ExifTag.ExposureTime,              Rational);
        public static readonly ExifTagInfo ExposureProgram           = new ExifTagInfo(ExifTag.ExposureProgram,           new NumberToEnum<ExifExposureProgram>());
        public static readonly ExifTagInfo FaxProfile                = new ExifTagInfo(ExifTag.FaxProfile,                new NumberToEnum<ExifFaxProfile>());
        public static readonly ExifTagInfo FlashEnergy               = new ExifTagInfo(ExifTag.FlashEnergy,               Rational);
        public static readonly ExifTagInfo FlashpixVersion           = new ExifTagInfo(ExifTag.FlashpixVersion,           Any, count: 4);
        public static readonly ExifTagInfo FNumber                   = new ExifTagInfo(ExifTag.FNumber,                   Rational);
        public static readonly ExifTagInfo FocalLength               = new ExifTagInfo(ExifTag.FocalLength,               Rational);
        public static readonly ExifTagInfo FocalLengthIn35mmFilm     = new ExifTagInfo(ExifTag.FocalLengthIn35mmFilm,     Short, count: 1);
        public static readonly ExifTagInfo FocalPlaneResolutionUnit  = new ExifTagInfo(ExifTag.FocalPlaneResolutionUnit,  new NumberToEnum<ExifResolutionUnit>());
        public static readonly ExifTagInfo FocalPlaneXResolution     = new ExifTagInfo(ExifTag.FocalPlaneXResolution,     Rational);
        public static readonly ExifTagInfo FocalPlaneYResolution     = new ExifTagInfo(ExifTag.FocalPlaneXResolution,     Rational);
        public static readonly ExifTagInfo GainControl               = new ExifTagInfo(ExifTag.GainControl,               new NumberToEnum<ExifGainControl>());
        public static readonly ExifTagInfo ISOSpeedRatings           = new ExifTagInfo(ExifTag.ISOSpeedRatings,           Short, count: -1);
        public static readonly ExifTagInfo LightSource               = new ExifTagInfo(ExifTag.LightSource,               new NumberToEnum<ExifLightSource>());
        public static readonly ExifTagInfo Orientation               = new ExifTagInfo(ExifTag.Orientation,               new NumberToEnum<ExifOrientation>());
        public static readonly ExifTagInfo MeteringMode              = new ExifTagInfo(ExifTag.MeteringMode,              new NumberToEnum<ExifMeteringMode>());
        public static readonly ExifTagInfo PixelXDimension           = new ExifTagInfo(ExifTag.PixelXDimension,           Long); // short | long
        public static readonly ExifTagInfo PixelYDimension           = new ExifTagInfo(ExifTag.PixelYDimension,           Long); // short | long
        public static readonly ExifTagInfo PhotometricInterpretation = new ExifTagInfo(ExifTag.PhotometricInterpretation, new NumberToEnum<ExifPhotometricInterpretation>());
        public static readonly ExifTagInfo PlanarConfiguration       = new ExifTagInfo(ExifTag.PlanarConfiguration,       new NumberToEnum<ExifPlanarConfiguration>());
        public static readonly ExifTagInfo ResolutionUnit            = new ExifTagInfo(ExifTag.ResolutionUnit,            new NumberToEnum<ExifResolutionUnit>());
        public static readonly ExifTagInfo Saturation                = new ExifTagInfo(ExifTag.Saturation,                new NumberToEnum<ExifSaturation>());
        public static readonly ExifTagInfo SceneCaptureType          = new ExifTagInfo(ExifTag.SceneCaptureType,          new NumberToEnum<ExifSceneCaptureType>());
        public static readonly ExifTagInfo SceneType                 = new ExifTagInfo(ExifTag.SceneType,                 new NumberToEnum<ExifSceneType>());
        public static readonly ExifTagInfo SensingMethod             = new ExifTagInfo(ExifTag.SensingMethod,             new NumberToEnum<ExifSensingMethod>());
        public static readonly ExifTagInfo SensitivityType           = new ExifTagInfo(ExifTag.SensitivityType,           new NumberToEnum<ExifSensitivityType>());
        public static readonly ExifTagInfo Sharpness                 = new ExifTagInfo(ExifTag.Sharpness,                 new NumberToEnum<ExifSharpness>());
        public static readonly ExifTagInfo ShutterSpeedValue         = new ExifTagInfo(ExifTag.ShutterSpeedValue,         SRational);
        public static readonly ExifTagInfo Software                  = new ExifTagInfo(ExifTag.Software,                  Ansi, count: -1);
        public static readonly ExifTagInfo SpectralSensitivity       = new ExifTagInfo(ExifTag.SpectralSensitivity,       Ansi, count: -1);
        public static readonly ExifTagInfo SubjectDistanceRange      = new ExifTagInfo(ExifTag.SubjectDistanceRange,      new NumberToEnum<ExifSubjectDistanceRange>());
        public static readonly ExifTagInfo SubjectLocation           = new ExifTagInfo(ExifTag.SubjectLocation,           Short, count: 2);
        public static readonly ExifTagInfo SubfileType               = new ExifTagInfo(ExifTag.SubfileType,               new NumberToEnum<ExifSubfileType>());
        public static readonly ExifTagInfo Thresholding              = new ExifTagInfo(ExifTag.Thresholding,              new NumberToEnum<ExifThresholding>());
        public static readonly ExifTagInfo WhiteBalance              = new ExifTagInfo(ExifTag.WhiteBalance,              new NumberToEnum<ExifWhiteBalance>());
        public static readonly ExifTagInfo XResolution               = new ExifTagInfo(ExifTag.XResolution,               Rational);
        public static readonly ExifTagInfo YResolution               = new ExifTagInfo(ExifTag.YResolution,               Rational);

        internal ExifTagInfo(ExifTag tag, MetaFormat format = Ansi, int count = 1, string description = null)
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

        public int Count { get; }

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
