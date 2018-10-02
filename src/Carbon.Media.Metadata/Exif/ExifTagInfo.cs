namespace Carbon.Media.Metadata.Exif
{
    using static ExifTagFormat;

    public sealed class ExifTagInfo
    {
        public static readonly ExifTagInfo ApertureValue             = new ExifTagInfo(ExifTag.ApertureValue,             Rational);
        public static readonly ExifTagInfo Artist                    = new ExifTagInfo(ExifTag.Artist,                    Ansi, count: -1);
        public static readonly ExifTagInfo BrightnessValue           = new ExifTagInfo(ExifTag.BrightnessValue,           Rational);
        public static readonly ExifTagInfo ColorSpace                = new ExifTagInfo(ExifTag.ColorSpace,                new NumberToEnumConverter<ExifColorSpace>());
        public static readonly ExifTagInfo Contrast                  = new ExifTagInfo(ExifTag.Contrast,                  new NumberToEnumConverter<ExifContrast>());
        public static readonly ExifTagInfo Compression               = new ExifTagInfo(ExifTag.Compression,               new NumberToEnumConverter<ExifCompression>());
        public static readonly ExifTagInfo Copyright                 = new ExifTagInfo(ExifTag.Artist,                    Ansi, count: -1);
        public static readonly ExifTagInfo CustomRendered            = new ExifTagInfo(ExifTag.CustomRendered,            new NumberToEnumConverter<ExifCustomRendered>());
        public static readonly ExifTagInfo DigitalZoomRatio          = new ExifTagInfo(ExifTag.DigitalZoomRatio,          Rational, count: 1);
        public static readonly ExifTagInfo ExifVersion               = new ExifTagInfo(ExifTag.ExifVersion,               Any);
        public static readonly ExifTagInfo ExposureIndex             = new ExifTagInfo(ExifTag.ExposureIndex,             Rational);
        public static readonly ExifTagInfo ExposureMode              = new ExifTagInfo(ExifTag.ExposureMode,              new NumberToEnumConverter<ExifExposureMode>());
        public static readonly ExifTagInfo ExposureTime              = new ExifTagInfo(ExifTag.ExposureTime,              Rational);
        public static readonly ExifTagInfo ExposureProgram           = new ExifTagInfo(ExifTag.ExposureProgram,           new NumberToEnumConverter<ExifExposureProgram>());
        public static readonly ExifTagInfo FaxProfile                = new ExifTagInfo(ExifTag.FaxProfile,                new NumberToEnumConverter<ExifFaxProfile>());
        public static readonly ExifTagInfo FlashEnergy               = new ExifTagInfo(ExifTag.FlashEnergy,               Rational);
        public static readonly ExifTagInfo FlashpixVersion           = new ExifTagInfo(ExifTag.FlashpixVersion,           Any, count: 4);
        public static readonly ExifTagInfo FNumber                   = new ExifTagInfo(ExifTag.FNumber,                   Rational);
        public static readonly ExifTagInfo FocalLength               = new ExifTagInfo(ExifTag.FocalLength,               Rational);
        public static readonly ExifTagInfo FocalLengthIn35mmFilm     = new ExifTagInfo(ExifTag.FocalLengthIn35mmFilm,     Short, count: 1);
        public static readonly ExifTagInfo FocalPlaneResolutionUnit  = new ExifTagInfo(ExifTag.FocalPlaneResolutionUnit,  new NumberToEnumConverter<ExifResolutionUnit>());
        public static readonly ExifTagInfo FocalPlaneXResolution     = new ExifTagInfo(ExifTag.FocalPlaneXResolution,     Rational);
        public static readonly ExifTagInfo FocalPlaneYResolution     = new ExifTagInfo(ExifTag.FocalPlaneXResolution,     Rational);
        public static readonly ExifTagInfo GainControl               = new ExifTagInfo(ExifTag.GainControl,               new NumberToEnumConverter<ExifGainControl>());
        public static readonly ExifTagInfo ISOSpeedRatings           = new ExifTagInfo(ExifTag.ISOSpeedRatings,           Short, count: -1);
        public static readonly ExifTagInfo LightSource               = new ExifTagInfo(ExifTag.LightSource,               new NumberToEnumConverter<ExifLightSource>());
        public static readonly ExifTagInfo Orientation               = new ExifTagInfo(ExifTag.Orientation,               new NumberToEnumConverter<ExifOrientation>());
        public static readonly ExifTagInfo MeteringMode              = new ExifTagInfo(ExifTag.MeteringMode,              new NumberToEnumConverter<ExifMeteringMode>());
        public static readonly ExifTagInfo PixelXDimension           = new ExifTagInfo(ExifTag.PixelXDimension,           Long); // short | long
        public static readonly ExifTagInfo PixelYDimension           = new ExifTagInfo(ExifTag.PixelYDimension,           Long); // short | long
        public static readonly ExifTagInfo PhotometricInterpretation = new ExifTagInfo(ExifTag.PhotometricInterpretation, new NumberToEnumConverter<ExifPhotometricInterpretation>());
        public static readonly ExifTagInfo PlanarConfiguration       = new ExifTagInfo(ExifTag.PlanarConfiguration,       new NumberToEnumConverter<ExifPlanarConfiguration>());
        public static readonly ExifTagInfo ResolutionUnit            = new ExifTagInfo(ExifTag.ResolutionUnit,            new NumberToEnumConverter<ExifResolutionUnit>());
        public static readonly ExifTagInfo Saturation                = new ExifTagInfo(ExifTag.Saturation,                new NumberToEnumConverter<ExifSaturation>());
        public static readonly ExifTagInfo SceneCaptureType          = new ExifTagInfo(ExifTag.SceneCaptureType,          new NumberToEnumConverter<ExifSceneCaptureType>());
        public static readonly ExifTagInfo SceneType                 = new ExifTagInfo(ExifTag.SceneType,                 new NumberToEnumConverter<ExifSceneType>());
        public static readonly ExifTagInfo SensingMethod             = new ExifTagInfo(ExifTag.SensingMethod,             new NumberToEnumConverter<ExifSensingMethod>());
        public static readonly ExifTagInfo SensitivityType           = new ExifTagInfo(ExifTag.SensitivityType,           new NumberToEnumConverter<ExifSensitivityType>());
        public static readonly ExifTagInfo Sharpness                 = new ExifTagInfo(ExifTag.Sharpness,                 new NumberToEnumConverter<ExifSharpness>());
        public static readonly ExifTagInfo ShutterSpeedValue         = new ExifTagInfo(ExifTag.ShutterSpeedValue,         SRational);
        public static readonly ExifTagInfo Software                  = new ExifTagInfo(ExifTag.Software,                  Ansi, count: -1);
        public static readonly ExifTagInfo SpectralSensitivity       = new ExifTagInfo(ExifTag.SpectralSensitivity,       Ansi, count: -1);
        public static readonly ExifTagInfo SubjectDistanceRange      = new ExifTagInfo(ExifTag.SubjectDistanceRange,      new NumberToEnumConverter<ExifSubjectDistanceRange>());
        public static readonly ExifTagInfo SubjectLocation           = new ExifTagInfo(ExifTag.SubjectLocation,           Short, count: 2);
        public static readonly ExifTagInfo SubfileType               = new ExifTagInfo(ExifTag.SubfileType,               new NumberToEnumConverter<ExifSubfileType>());
        public static readonly ExifTagInfo Thresholding              = new ExifTagInfo(ExifTag.Thresholding,              new NumberToEnumConverter<ExifThresholding>());
        public static readonly ExifTagInfo WhiteBalance              = new ExifTagInfo(ExifTag.WhiteBalance,              new NumberToEnumConverter<ExifWhiteBalance>());
        public static readonly ExifTagInfo XResolution               = new ExifTagInfo(ExifTag.XResolution,               Rational);
        public static readonly ExifTagInfo YResolution               = new ExifTagInfo(ExifTag.YResolution,               Rational);

        internal ExifTagInfo(ExifTag tag, ExifTagFormat format = Ansi, int count = 1, string description = null)
        {
            Name = tag.ToString();
            Code = (int)tag;
            Description = description;
            Converter = ExifValueConverter.Get(format);
        }

        public ExifTagInfo(ExifTag tag, ExifValueConverter converter)
        {
            Name      = tag.ToString();
            Code      = (int)tag;
            Converter = converter;
        }

        internal ExifTagInfo(string name, ExifTagFormat format = Ansi)
            : this(name, ExifValueConverter.Get(format)) { }

        public ExifTagInfo(string name, ExifValueConverter converter)
        {
            Name      = name;
            Converter = converter;
        }

        public string Name { get; }

        public int Code { get; }

        public string Description { get; }

        public int Count { get; }

        public ExifValueConverter Converter { get; }

        public object Normalize(object value)
        {
            if (value is null) return null;

            try
            {
                return Converter.Normalize(value);
            }
            catch
            {
                return null;
            }
        }
    }
}