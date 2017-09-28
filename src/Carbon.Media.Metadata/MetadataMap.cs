using System.Collections.Generic;

namespace Carbon.Media.Metadata
{
    using static MetaFormat;

    public class MetadataMap
    {
        public static readonly Dictionary<string, MetadataItemInfo> PathsToNames = new Dictionary<string, MetadataItemInfo> {
            { "/app0/{ushort=0}",   new MetadataItemInfo("Version") },
            { "/app0/{ushort=1}",   new MetadataItemInfo("Units", new NumberToEnum<ResolutionUnit>()) },
            { "/app0/{ushort=2}",   new MetadataItemInfo("DpiX") },
            { "/app0/{ushort=3}",   new MetadataItemInfo("DpiY") },
            { "/app0/{ushort=4}",   new MetadataItemInfo("Xthumbnail") },
            { "/app0/{ushort=5}",   new MetadataItemInfo("Ythumbnail") },
            { "/app0/{ushort=6}",   new MetadataItemInfo("ThumbnailData") },
									
			// GIFS
			{ "/imgdesc/Left",                    new MetadataItemInfo("Left",                    Short) },	    // UInt16
			{ "/imgdesc/Top",                     new MetadataItemInfo("Top",                     Short) },	    // UInt16
			{ "/imgdesc/Height",                  new MetadataItemInfo("Height",                  Short) },	    // UInt16
			{ "/imgdesc/Width",                   new MetadataItemInfo("Width",                   Short) },	    // UInt16
			{ "/imgdesc/LocalColorTableFlag",     new MetadataItemInfo("LocalColorTableFlag",     Boolean) },	// Bool
			{ "/imgdesc/InterlaceFlag",           new MetadataItemInfo("InterlaceFlag",           Boolean) },	// Bool
			
			{ "/grctlext/Disposal",               new MetadataItemInfo("Disposal",                Byte) },	    // Byte
			{ "/grctlext/Delay",                  new MetadataItemInfo("Delay",                   Short) },	    // UInt16
			{ "/grctlext/TransparentColorIndex",  new MetadataItemInfo("TransparentColorIndex",   Byte) },	    // Byte
			{ "/grctlext/TransparencyFlag",       new MetadataItemInfo("TransparencyFlag",        Boolean) },	// Bool
			{ "/grctlext/UserInputFlag",          new MetadataItemInfo("UserInputFlag",           Boolean) },	// Bool
			{ "/grctlext/GlobalColorTableFlag",   new MetadataItemInfo("GlobalColorTableFlag",    Boolean) },	// Bool
			{ "/grctlext/ColorResolution",        new MetadataItemInfo("ColorResolution",         Byte) },	    // Byte


			// MISC
			{ "/tEXt/{str=Software}",   new MetadataItemInfo("Software",  Ansi) },
            { "/xmp/xmp:CreatorTool",   new MetadataItemInfo("Software",  Ansi) },
            { "{str=Copyright Notice}", new MetadataItemInfo("Copyright", Ansi) },	// /app13/{ushort=0}/{ulonglong=61857348781060}/iptc/{str=Copyright Notice}
			{ "{str=By-line}",          new MetadataItemInfo("Author",    Ansi) },	// /app13/{ushort=0}/{ulonglong=61857348781060}/iptc/{str=By-line}
		};

        public static readonly Dictionary<int, MetadataItemInfo> CodesToNames = new Dictionary<int, MetadataItemInfo> {
			// GPS Metadata			
			{ 0,        new MetadataItemInfo(ExifTag.GPSVersionID,            Byte) },
            { 1,        new MetadataItemInfo(ExifTag.GPSLatitudeRef,          Ansi) },
            { 2,        new MetadataItemInfo(ExifTag.GPSLatitude,             Rational) },
            { 3,        new MetadataItemInfo(ExifTag.GPSLongitudeRef,         Ansi) },
            { 4,        new MetadataItemInfo(ExifTag.GPSLongitude,            Rational) },
            { 5,        new MetadataItemInfo(ExifTag.GPSAltitudeRef) },
            { 6,        new MetadataItemInfo(ExifTag.GPSAltitude,             Rational) },
            { 7,        new MetadataItemInfo(ExifTag.GPSTimeStamp,            Rational) },
            { 8,        new MetadataItemInfo(ExifTag.GPSSatellites) },
            { 9,        new MetadataItemInfo(ExifTag.GPSStatus) },
            { 10,       new MetadataItemInfo(ExifTag.GPSMeasureMode) },
            { 11,       new MetadataItemInfo(ExifTag.GPSDOP) },
            { 12,       new MetadataItemInfo(ExifTag.GPSSpeedRef,             MetaFormat.Ansi) },
            { 13,       new MetadataItemInfo(ExifTag.GPSSpeed) },
            { 14,       new MetadataItemInfo(ExifTag.GPSTrackRef) },
            { 15,       new MetadataItemInfo(ExifTag.GPSTrack) },

			// TIFF / JPEG (Baseline tags)
			{ 254,      new MetadataItemInfo(ExifTag.NewSubfileType) },
            { 255,      new MetadataItemInfo(ExifTag.SubfileType,             new NumberToEnum<SubfileType>()) },
            { 256,      new MetadataItemInfo(ExifTag.ImageWidth,              Long) },
            { 257,      new MetadataItemInfo(ExifTag.ImageLength) },
            { 258,      new MetadataItemInfo(ExifTag.BitsPerSample) },
            { 259,      new MetadataItemInfo(ExifTag.Compression,             new NumberToEnum<Compression>()) },
            { 262,      new MetadataItemInfo(ExifTag.PhotometricInterpretation) },
            { 270,      new MetadataItemInfo(ExifTag.ImageDescription) },
            { 271,      new MetadataItemInfo(ExifTag.Make,                    Ansi) },
            { 272,      new MetadataItemInfo(ExifTag.Model,                   Ansi) },
            { 273,      new MetadataItemInfo(ExifTag.StripOffsets) },
            { 274,      new MetadataItemInfo(ExifTag.Orientation,             new NumberToEnum<MediaOrientation>()) },
            { 277,      new MetadataItemInfo(ExifTag.SamplesPerPixel) },
            { 278,      new MetadataItemInfo(ExifTag.RowsPerStrip) },
            { 279,      new MetadataItemInfo(ExifTag.StripByteCounts) },
            { 282,      new MetadataItemInfo(ExifTag.XResolution,             Rational) },
            { 283,      new MetadataItemInfo(ExifTag.YResolution,             Rational) },
            { 284,      new MetadataItemInfo(ExifTag.PlanarConfiguration) },
            { 296,      new MetadataItemInfo(ExifTag.ResolutionUnit,          new NumberToEnum<ResolutionUnit>()) },
            { 305,      new MetadataItemInfo(ExifTag.Software,                Ansi) },
            { 306,      new MetadataItemInfo(ExifTag.DateTime,                Date) },
            { 513,      new MetadataItemInfo(ExifTag.JPEGInterchangeFormat) },
			{ 314,      new MetadataItemInfo(ExifTag.JPEGInterchangeFormatLength) },
            { 315,      new MetadataItemInfo(ExifTag.Artist) },
            { 530,      new MetadataItemInfo(ExifTag.YCbCrSubSampling) },
            { 531,      new MetadataItemInfo(ExifTag.YCbCrPositioning) },
            { 33432,    new MetadataItemInfo(ExifTag.Copyright,         Ansi) },
				
			// EXIF Metadata		
			{ 33434,    new MetadataItemInfo(ExifTag.ExposureTime,            Rational) }, // 33434, "Exposure time, given in seconds") },
			{ 33437,    new MetadataItemInfo(ExifTag.FNumber,                 Rational) },
            { 34850,    new MetadataItemInfo(ExifTag.ExposureProgram,         new NumberToEnum<ExposureProgram>()) },
            { 34852,    new MetadataItemInfo(ExifTag.SpectralSensitivity,    Ansi) },
            { 34855,    new MetadataItemInfo(ExifTag.ISOSpeedRatings,        Short) },
            { 34856,    new MetadataItemInfo(ExifTag.OECF) },
            { 34864,    new MetadataItemInfo(ExifTag.SensitivityType,         new NumberToEnum<SensitivityType>()) },
            { 34865,    new MetadataItemInfo(ExifTag.StandardOutputSensitivity) },
            { 34866,    new MetadataItemInfo(ExifTag.RecommendedExposureIndex) },
            { 34867,    new MetadataItemInfo(ExifTag.ISOSpeed) },
            { 34868,    new MetadataItemInfo(ExifTag.ISOSpeedLatitudeyyy) },
            { 34869,    new MetadataItemInfo(ExifTag.ISOSpeedLatitudezzz) },
            { 36864,    new MetadataItemInfo(ExifTag.ExifVersion) },
            { 36867,    new MetadataItemInfo(ExifTag.DateTimeOriginal,        Date) },
            { 36868,    new MetadataItemInfo(ExifTag.DateTimeDigitized,       Date) },
            { 37377,    new MetadataItemInfo(ExifTag.ShutterSpeedValue,       SRational) },
            { 37378,    new MetadataItemInfo(ExifTag.ApertureValue,           Rational) },
            { 37379,    new MetadataItemInfo(ExifTag.BrightnessValue,         SRational) },
            { 37380,    new MetadataItemInfo(ExifTag.ExposureBiasValue,       SRational) },
            { 37381,    new MetadataItemInfo(ExifTag.MaxApertureValue,        Rational) },
            { 37382,    new MetadataItemInfo(ExifTag.SubjectDistance,         SRational) }, // , 37382, "The distance to the subject, given in meters") },
			{ 37383,    new MetadataItemInfo(ExifTag.MeteringMode,            new NumberToEnum<MeteringMode>()) },
            { 37384,    new MetadataItemInfo(ExifTag.LightSource,             new NumberToEnum<LightSource>()) },
            { 37385,    new MetadataItemInfo(ExifTag.Flash) },
            { 37386,    new MetadataItemInfo(ExifTag.FocalLength,             Rational) },
            { 37387,    new MetadataItemInfo(ExifTag.FlashEnergy,             Rational) },
            { 37396,    new MetadataItemInfo(ExifTag.SubjectArea) },
            { 37500,    new MetadataItemInfo(ExifTag.MakerNote) },
            { 37510,    new MetadataItemInfo(ExifTag.UserComment) },
            { 37520,    new MetadataItemInfo(ExifTag.SubSecTime,              Long, "A tag used to record fractions of seconds for the DateTime tag.") },
            { 37522,    new MetadataItemInfo(ExifTag.SubSecTimeDigitized,     Long) },
            { 40960,    new MetadataItemInfo(ExifTag.FlashpixVersion ) },
            // { 40961,    new MetadataItemInfo("ColorSpace",              new NumberToEnum<ColorSpace>()) }, 1 = sRGB, 65535 = Uncalibrated
            { 40962,    new MetadataItemInfo(ExifTag.PixelXDimension) },
            { 40963,    new MetadataItemInfo(ExifTag.PixelYDimension) },
            { 41483,    new MetadataItemInfo(ExifTag.FlashEnergy) },
            { 41484,    new MetadataItemInfo(ExifTag.SpatialFrequencyResponse) },
            { 41486,    new MetadataItemInfo(ExifTag.FocalPlaneXResolution) },
            { 41487,    new MetadataItemInfo(ExifTag.FocalPlaneYResolution) },
            { 41488,    new MetadataItemInfo(ExifTag.FocalPlaneResolutionUnit, new NumberToEnum<FocalPlaneMeasurementUnit>()) },
            { 41492,    new MetadataItemInfo(ExifTag.SubjectLocation) },
            { 41493,    new MetadataItemInfo(ExifTag.ExposureIndex) },
            { 41495,    new MetadataItemInfo(ExifTag.SensingMethod,           new NumberToEnum<SensingMethod>()) },
            { 41728,    new MetadataItemInfo(ExifTag.FileSource) },
            { 41729,    new MetadataItemInfo(ExifTag.SceneType) },
            { 41730,    new MetadataItemInfo(ExifTag.CFAPattern) },
            { 41985,    new MetadataItemInfo(ExifTag.CustomRendered) },
            { 41986,    new MetadataItemInfo(ExifTag.ExposureMode,            new NumberToEnum<FocalPlaneMeasurementUnit>()) },
            { 41987,    new MetadataItemInfo(ExifTag.WhiteBalance,            new NumberToEnum<WhiteBalance>()) },
            { 41988,    new MetadataItemInfo(ExifTag.DigitalZoomRatio) },
            { 41989,    new MetadataItemInfo(ExifTag.FocalLengthIn35mmFilm) },
            { 41990,    new MetadataItemInfo(ExifTag.SceneCaptureType,        new NumberToEnum<SceneCaptureType>()) },
            { 41991,    new MetadataItemInfo(ExifTag.GainControl,             new NumberToEnum<GainControl>()) },
            { 41992,    new MetadataItemInfo(ExifTag.Contrast) },
            { 41993,    new MetadataItemInfo(ExifTag.Saturation) },
            { 41995,    new MetadataItemInfo(ExifTag.DeviceSettingDescription) },
            { 41996,    new MetadataItemInfo(ExifTag.SubjectDistanceRange,    new NumberToEnum<SceneCaptureType>()) },
            { 42016,    new MetadataItemInfo(ExifTag.ImageUniqueID,           Ansi) },
            { 42032,    new MetadataItemInfo(ExifTag.CameraOwnerName,         Ansi) },
            { 42033,    new MetadataItemInfo(ExifTag.BodySerialNumber,        Ansi) },
            { 42034,    new MetadataItemInfo(ExifTag.LensSpecification,       Rational) },
            { 42035,    new MetadataItemInfo(ExifTag.LensMake,                Ansi) },
            { 42036,    new MetadataItemInfo(ExifTag.LensModel,               Ansi) },
            { 42037,    new MetadataItemInfo(ExifTag.LensSerialNumber,        Ansi) }
        };

        public static MetadataItemInfo Get(ExifTag tag)
        {
            CodesToNames.TryGetValue((int)tag, out var metadata);

            return metadata;
        }

        public static MetadataItemInfo Get(string path)
        {
            if (PathsToNames.TryGetValue(path, out MetadataItemInfo info))
            {
                return info;
            }

            // BY CODE
            // /{ushort=7}
            try
            {
                var parts = path.Split('/');

                var code = int.Parse(parts[parts.Length - 1].Replace("{ushort=", "").Replace("}", ""));

                CodesToNames.TryGetValue(code, out info);
            }
            catch { }

            return info;
        }
    }
}

// http://www.exif.org/Exif2-2.PDF
