using System.Collections.Generic;

namespace Carbon.Media.Metadata
{
    using static MetaFormat;
    using static ExifTag;

    public class MetadataMap
    {
        public static readonly Dictionary<string, ExifTagInfo> PathsToNames = new Dictionary<string, ExifTagInfo> {
            { "/app0/{ushort=0}",   new ExifTagInfo("Version") },
            { "/app0/{ushort=1}",   new ExifTagInfo("Units", new NumberToEnum<ResolutionUnit>()) },
            { "/app0/{ushort=2}",   new ExifTagInfo("DpiX") },
            { "/app0/{ushort=3}",   new ExifTagInfo("DpiY") },
            { "/app0/{ushort=4}",   new ExifTagInfo("Xthumbnail") },
            { "/app0/{ushort=5}",   new ExifTagInfo("Ythumbnail") },
            { "/app0/{ushort=6}",   new ExifTagInfo("ThumbnailData") },
									
			// GIFS
			{ "/imgdesc/Left",                    new ExifTagInfo("Left",                    Short) },	    // UInt16
			{ "/imgdesc/Top",                     new ExifTagInfo("Top",                     Short) },	    // UInt16
			{ "/imgdesc/Height",                  new ExifTagInfo("Height",                  Short) },	    // UInt16
			{ "/imgdesc/Width",                   new ExifTagInfo("Width",                   Short) },	    // UInt16
			{ "/imgdesc/LocalColorTableFlag",     new ExifTagInfo("LocalColorTableFlag",     Boolean) },	// Bool
			{ "/imgdesc/InterlaceFlag",           new ExifTagInfo("InterlaceFlag",           Boolean) },	// Bool
			
			{ "/grctlext/Disposal",               new ExifTagInfo("Disposal",                Byte) },	    // Byte
			{ "/grctlext/Delay",                  new ExifTagInfo("Delay",                   Short) },	    // UInt16
			{ "/grctlext/TransparentColorIndex",  new ExifTagInfo("TransparentColorIndex",   Byte) },	    // Byte
			{ "/grctlext/TransparencyFlag",       new ExifTagInfo("TransparencyFlag",        Boolean) },	// Bool
			{ "/grctlext/UserInputFlag",          new ExifTagInfo("UserInputFlag",           Boolean) },	// Bool
			{ "/grctlext/GlobalColorTableFlag",   new ExifTagInfo("GlobalColorTableFlag",    Boolean) },	// Bool
			{ "/grctlext/ColorResolution",        new ExifTagInfo("ColorResolution",         Byte) },	    // Byte


			// MISC
			{ "/tEXt/{str=Software}",   new ExifTagInfo("Software",  Ansi) },
            { "/xmp/xmp:CreatorTool",   new ExifTagInfo("Software",  Ansi) },
            { "{str=Copyright Notice}", new ExifTagInfo("Copyright", Ansi) },	// /app13/{ushort=0}/{ulonglong=61857348781060}/iptc/{str=Copyright Notice}
			{ "{str=By-line}",          new ExifTagInfo("Author",    Ansi) },	// /app13/{ushort=0}/{ulonglong=61857348781060}/iptc/{str=By-line}
		};

        private static readonly Dictionary<int, ExifTagInfo> CodesToNames = new Dictionary<int, ExifTagInfo> {
			// GPS Metadata			
			{ 0,        new ExifTagInfo(GPSVersionID,              Byte) },
            { 1,        new ExifTagInfo(GPSLatitudeRef,            Ansi) },
            { 2,        new ExifTagInfo(GPSLatitude,               Rational) },
            { 3,        new ExifTagInfo(GPSLongitudeRef,           Ansi) },
            { 4,        new ExifTagInfo(GPSLongitude,              Rational) },
            { 5,        new ExifTagInfo(GPSAltitudeRef,            Byte) },
            { 6,        new ExifTagInfo(GPSAltitude,               Rational) },
            { 7,        new ExifTagInfo(GPSTimestamp,              Rational) },
            { 8,        new ExifTagInfo(GPSSatellites,             Ansi) },
            { 9,        new ExifTagInfo(GPSStatus,                 Ansi) },
            { 10,       new ExifTagInfo(GPSMeasureMode,            Ansi) },
            { 11,       new ExifTagInfo(GPSDOP,                    Rational) },
            { 12,       new ExifTagInfo(GPSSpeedRef,               Ansi) },
            { 13,       new ExifTagInfo(GPSSpeed,                  Rational) },
            { 14,       new ExifTagInfo(GPSTrackRef) },
            { 15,       new ExifTagInfo(GPSTrack) },
            { 16,       new ExifTagInfo(GPSImgDirectionRef) },
            { 17,       new ExifTagInfo(GPSImgDirection) },
            { 18,       new ExifTagInfo(GPSMapDatum,               Ansi) },
            { 19,       new ExifTagInfo(GPSDestLatitudeRef) },
            { 20,       new ExifTagInfo(GPSDestLatitude) },
            { 21,       new ExifTagInfo(GPSDestLongitudeRef) },
            { 22,       new ExifTagInfo(GPSDestLongitude) },
            { 23,       new ExifTagInfo(GPSDestBearingRef) },
            { 24,       new ExifTagInfo(GPSDestBearing) },
            { 25,       new ExifTagInfo(GPSDestDistanceRef) },
            { 26,       new ExifTagInfo(GPSDestDistance) },
            { 27,       new ExifTagInfo(GPSProcessingMethod) },
            { 28,       new ExifTagInfo(GPSAreaInformation) },
            { 29,       new ExifTagInfo(GPSDateStamp,              Ansi) },
            { 30,       new ExifTagInfo(GPSDifferential,           Short) },

			// TIFF / JPEG (Baseline tags)
			{ 254,      ExifTagInfo.SubfileType },
            { 255,      new ExifTagInfo(OldSubfileType) },
            { 256,      new ExifTagInfo(ImageWidth,                 Long) },
            { 257,      new ExifTagInfo(ImageLength) },
            { 258,      new ExifTagInfo(BitsPerSample) },
            { 259,      ExifTagInfo.Compression },
            { 262,      ExifTagInfo.PhotometricInterpretation },
            { 270,      new ExifTagInfo(ImageDescription) },
            { 271,      new ExifTagInfo(Make,                       Ansi) },
            { 272,      new ExifTagInfo(Model,                      Ansi) },
            { 273,      new ExifTagInfo(StripOffsets) },
            { 274,      ExifTagInfo.Orientation },
            { 277,      new ExifTagInfo(SamplesPerPixel) },
            { 278,      new ExifTagInfo(RowsPerStrip) },
            { 279,      new ExifTagInfo(StripByteCounts) },
            { 282,      new ExifTagInfo(XResolution,                Rational) },
            { 283,      new ExifTagInfo(YResolution,                Rational) },
            { 284,      ExifTagInfo.PlanarConfiguration },
            { 296,      ExifTagInfo.ResolutionUnit },
            { 305,      new ExifTagInfo(Software,                   Ansi) },
            { 306,      new ExifTagInfo(DateTime,                   Date) },
            { 513,      new ExifTagInfo(JPEGInterchangeFormat) },
			{ 314,      new ExifTagInfo(JPEGInterchangeFormatLength) },
            { 315,      new ExifTagInfo(Artist) },
            { 530,      new ExifTagInfo(YCbCrSubSampling) },
            { 531,      new ExifTagInfo(YCbCrPositioning) },
            { 33432,    new ExifTagInfo(Copyright,                  Ansi) },
				
			// EXIF Metadata		
			{ 33434,    new ExifTagInfo(ExposureTime,               Rational) }, // 33434, "Exposure time, given in seconds") },
			{ 33437,    new ExifTagInfo(FNumber,                    Rational) },
            { 34850,    ExifTagInfo.ExposureProgram },
            { 34852,    new ExifTagInfo(SpectralSensitivity,        Ansi) },
            { 34855,    new ExifTagInfo(ISOSpeedRatings,            Short) },
            { 34856,    new ExifTagInfo(OECF) },
            { 34864,    ExifTagInfo.SensitivityType },
            { 34865,    new ExifTagInfo(StandardOutputSensitivity) },
            { 34866,    new ExifTagInfo(RecommendedExposureIndex) },
            { 34867,    new ExifTagInfo(ISOSpeed) },
            { 34868,    new ExifTagInfo(ISOSpeedLatitudeyyy) },
            { 34869,    new ExifTagInfo(ISOSpeedLatitudezzz) },
            { 36864,    new ExifTagInfo(ExifVersion) },
            { 36867,    new ExifTagInfo(DateTimeOriginal,        Date) },
            { 36868,    new ExifTagInfo(DateTimeDigitized,       Date) },
            { 37377,    new ExifTagInfo(ShutterSpeedValue,       SRational) },
            { 37378,    new ExifTagInfo(ApertureValue,           Rational) },
            { 37379,    new ExifTagInfo(BrightnessValue,         SRational) },
            { 37380,    new ExifTagInfo(ExposureBiasValue,       SRational) },
            { 37381,    new ExifTagInfo(MaxApertureValue,        Rational) },
            { 37382,    new ExifTagInfo(SubjectDistance,         SRational) }, // , 37382, "The distance to the subject, given in meters") },
			{ 37383,    ExifTagInfo.MeteringMode },
            { 37384,    ExifTagInfo.LightSource },
            { 37385,    new ExifTagInfo(Flash) },
            { 37386,    new ExifTagInfo(FocalLength,             Rational) },
            { 37387,    new ExifTagInfo(FlashEnergy,             Rational) },
            { 37396,    new ExifTagInfo(SubjectArea) },
            { 37500,    new ExifTagInfo(MakerNote) },
            { 37510,    new ExifTagInfo(UserComment) },
            { 37520,    new ExifTagInfo(SubsecTime,              Long, "A tag used to record fractions of seconds for the DateTime tag.") },
            { 37522,    new ExifTagInfo(SubsecTimeDigitized,     Long) },
            { 37892,    new ExifTagInfo(Acceleration) },
            { 40960,    new ExifTagInfo(FlashpixVersion ) },
            { 40961,    ExifTagInfo.ColorSpace },
            { 40962,    new ExifTagInfo(PixelXDimension) },
            { 40963,    new ExifTagInfo(PixelYDimension) },
            { 41483,    new ExifTagInfo(FlashEnergy) },
            { 41484,    new ExifTagInfo(SpatialFrequencyResponse) },
            { 41486,    new ExifTagInfo(FocalPlaneXResolution) },
            { 41487,    new ExifTagInfo(FocalPlaneYResolution) },
            { 41488,    ExifTagInfo.FocalPlaneResolutionUnit },
            { 41492,    new ExifTagInfo(SubjectLocation) },
            { 41493,    new ExifTagInfo(ExposureIndex) },
            { 41495,    ExifTagInfo.SensingMethod },
            { 41728,    new ExifTagInfo(FileSource) },
            { 41729,    new ExifTagInfo(SceneType) },
            { 41730,    new ExifTagInfo(CFAPattern) },
            { 41985,    new ExifTagInfo(CustomRendered) },
            { 41986,    ExifTagInfo.ExposureMode },
            { 41987,    ExifTagInfo.WhiteBalance },
            { 41988,    new ExifTagInfo(DigitalZoomRatio) },
            { 41989,    new ExifTagInfo(FocalLengthIn35mmFilm) },
            { 41990,    ExifTagInfo.SceneCaptureType },
            { 41991,    ExifTagInfo.GainControl },
            { 41992,    new ExifTagInfo(Contrast) },
            { 41993,    new ExifTagInfo(Saturation) },
            { 41995,    new ExifTagInfo(DeviceSettingDescription) },
            { 41996,    ExifTagInfo.SubjectDistanceRange },
            { 42016,    new ExifTagInfo(ImageUniqueID,           Ansi) },
            { 42032,    new ExifTagInfo(CameraOwnerName,         Ansi) },
            { 42033,    new ExifTagInfo(CameraSerialNumber,      Ansi) },
            { 42034,    new ExifTagInfo(LensSpecification,       Rational) },
            { 42035,    new ExifTagInfo(LensMake,                Ansi) },
            { 42036,    new ExifTagInfo(LensModel,               Ansi) },
            { 42037,    new ExifTagInfo(LensSerialNumber,        Ansi) }
        };

        public static bool TryGet(ExifTag tag, out ExifTagInfo info)
        {
            return CodesToNames.TryGetValue((int)tag, out info);
        }

        public static ExifTagInfo Get(ExifTag tag)
        {
            CodesToNames.TryGetValue((int)tag, out var info);

            return info;
        }

        public static ExifTagInfo Get(string path)
        {
            if (PathsToNames.TryGetValue(path, out ExifTagInfo info))
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
