using System;
using System.Collections.Generic;
using System.Globalization;

namespace Carbon.Media.Metadata
{
    public class MetadataItemConverter
    {
        public static readonly MetadataItemConverter Default = new MetadataItemConverter();

        public virtual object Normalize(object value) 
            => value.ToString();
    }

    public sealed class IntegerConverter : MetadataItemConverter
    {
        public static new readonly IntegerConverter Default = new IntegerConverter();

        public override object Normalize(object value)
            => int.Parse(value.ToString());
    }

    public sealed class BooleanConverter : MetadataItemConverter
    {
        public static new readonly BooleanConverter Default = new BooleanConverter();

        public override object Normalize(object value)
            => int.Parse(value.ToString().ToLower());
    }

    public sealed class SignedRational : MetadataItemConverter
    {
        public static readonly new SignedRational Default = new SignedRational();

        public override object Normalize(object value)
        {
            if (value == null) return "null";

            var data = BitConverter.GetBytes((UInt64)value);

            // UInt64

            var numberator = BitConverter.ToInt32(data, 0);
            var denominator = BitConverter.ToInt32(data, 4);

            var x = 0d;

            if (denominator != 0)
            {
                x = ((double)numberator / denominator);
            }

            // NaN Check

            return x.ToString();
            /*
			double focalLength = (double)a / b;

			return int.Parse(value.ToString());
			*/
        }
    }

    public sealed class UnsignedRational : MetadataItemConverter
    {
        public new static readonly UnsignedRational Default = new UnsignedRational();

        public override object Normalize(object value)
        {
            if (value == null) return "null";

            var data = BitConverter.GetBytes((UInt64)value);

            // UInt64

            var numberator = BitConverter.ToUInt32(data, 0); // uint32
            var denominator = BitConverter.ToUInt32(data, 4);

            var x = 0d;

            if (denominator != 0)
            {
                x = ((double)numberator / (double)denominator);
            }

            // NaN Check

            return x.ToString();
            /*
			double focalLength = (double)a / b;

			return int.Parse(value.ToString());
			*/
        }
    }

 

    public sealed class NumberToEnum<T> : MetadataItemConverter
    {
        public override object Normalize(object value)
        {
            return Enum.ToObject(typeof(T), int.Parse(value.ToString()));
        }
    }

    public sealed class DateNormalizer : MetadataItemConverter
    {
        public static readonly new DateNormalizer Default = new DateNormalizer();

        public override object Normalize(object value)
        {
            // 2010:07:24 15:05:03

            var date = DateTime.ParseExact(value.ToString(), "yyyy:MM:dd HH:mm:ss", null, DateTimeStyles.AssumeUniversal);

            return date.ToString("yyyy-MM-ddTHH:mm:ssZ");
        }
    }

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
			{ "/imgdesc/Left",                      new MetadataItemInfo("Left",                    MetaFormat.Short) },	// UInt16
			{ "/imgdesc/Top",                       new MetadataItemInfo("Top",                     MetaFormat.Short) },	// UInt16
			{ "/imgdesc/Height",                    new MetadataItemInfo("Height",                  MetaFormat.Short) },	// UInt16
			{ "/imgdesc/Width",                     new MetadataItemInfo("Width",                   MetaFormat.Short) },	// UInt16
			{ "/imgdesc/LocalColorTableFlag",       new MetadataItemInfo("LocalColorTableFlag",     MetaFormat.Boolean) },	// Bool
			{ "/imgdesc/InterlaceFlag",             new MetadataItemInfo("InterlaceFlag",           MetaFormat.Boolean) },	// Bool
			
			{ "/grctlext/Disposal",                 new MetadataItemInfo("Disposal",                MetaFormat.Byte) },		// Byte
			{ "/grctlext/Delay",                    new MetadataItemInfo("Delay",                   MetaFormat.Short) },	// UInt16
			{ "/grctlext/TransparentColorIndex",    new MetadataItemInfo("TransparentColorIndex",   MetaFormat.Byte) },		// Byte
			{ "/grctlext/TransparencyFlag",         new MetadataItemInfo("TransparencyFlag",        MetaFormat.Boolean) },	// Bool
			{ "/grctlext/UserInputFlag",            new MetadataItemInfo("UserInputFlag",           MetaFormat.Boolean) },	// Bool
			{ "/grctlext/GlobalColorTableFlag",     new MetadataItemInfo("GlobalColorTableFlag",    MetaFormat.Boolean) },	// Bool
			{ "/grctlext/ColorResolution",          new MetadataItemInfo("ColorResolution",         MetaFormat.Byte) },		// Byte


			// MISC
			{ "/tEXt/{str=Software}",   new MetadataItemInfo("Software",    MetaFormat.Ansi) },
            { "/xmp/xmp:CreatorTool",   new MetadataItemInfo("Software",    MetaFormat.Ansi) },
            { "{str=Copyright Notice}", new MetadataItemInfo("Copyright",   MetaFormat.Ansi) },			// /app13/{ushort=0}/{ulonglong=61857348781060}/iptc/{str=Copyright Notice}
			{ "{str=By-line}",          new MetadataItemInfo("Author",      MetaFormat.Ansi) },			// /app13/{ushort=0}/{ulonglong=61857348781060}/iptc/{str=By-line}
		};

        public static readonly Dictionary<int, MetadataItemInfo> CodesToNames = new Dictionary<int, MetadataItemInfo> {
			// GPS Metadata			
			{ 0,        new MetadataItemInfo("GPSVersionID") },
            { 1,        new MetadataItemInfo("GPSLatitudeRef") },
            { 2,        new MetadataItemInfo("GPSLatitude",             MetaFormat.Rational) },
            { 3,        new MetadataItemInfo("GPSLongitudeRef",         MetaFormat.Ansi) },
            { 4,        new MetadataItemInfo("GPSLongitude",            MetaFormat.Rational) },
            { 5,        new MetadataItemInfo("GPSAltitudeRef") },
            { 6,        new MetadataItemInfo("GPSAltitude",             MetaFormat.Rational) },
            { 7,        new MetadataItemInfo("GPSTimeStamp",            MetaFormat.Rational) },
            { 8,        new MetadataItemInfo("GPSSatellites") },
            { 9,        new MetadataItemInfo("GPSStatus") },
            { 10,       new MetadataItemInfo("GPSMeasureMode") },
            { 11,       new MetadataItemInfo("GPSDOP") },
            { 12,       new MetadataItemInfo("GPSSpeedRef",             MetaFormat.Ansi) },
            { 13,       new MetadataItemInfo("GPSSpeed") },
            { 14,       new MetadataItemInfo("GPSTrackRef") },
            { 15,       new MetadataItemInfo("GPSTrack") },

			// TIFF / JPEG (Baseline tags)
			{ 254,      new MetadataItemInfo("NewSubfileType") },
            { 255,      new MetadataItemInfo("SubfileType",             new NumberToEnum<SubfileType>()) },
            { 256,      new MetadataItemInfo("ImageWidth",              MetaFormat.Long, 256) },
            { 257,      new MetadataItemInfo("ImageLength") },
            { 258,      new MetadataItemInfo("BitsPerSample") },
            { 259,      new MetadataItemInfo("Compression",             new NumberToEnum<Compression>()) },
            { 262,      new MetadataItemInfo("PhotometricInterpretation") },
            { 270,      new MetadataItemInfo("ImageDescription") },
            { 271,      new MetadataItemInfo("Make",                    MetaFormat.Ansi) },
            { 272,      new MetadataItemInfo("Model",                   MetaFormat.Ansi) },
            { 273,      new MetadataItemInfo("StripOffsets") },
            { 274,      new MetadataItemInfo("Orientation",             new NumberToEnum<MediaOrientation>()) },
            { 277,      new MetadataItemInfo("SamplesPerPixel") },
            { 278,      new MetadataItemInfo("RowsPerStrip") },
            { 279,      new MetadataItemInfo("StripByteCounts") },
            { 282,      new MetadataItemInfo("XResolution",             MetaFormat.Rational) },
            { 283,      new MetadataItemInfo("YResolution",             MetaFormat.Rational) },
            { 284,      new MetadataItemInfo("PlanarConfiguration") },
            { 296,      new MetadataItemInfo("ResolutionUnit",          new NumberToEnum<ResolutionUnit>()) },
            { 305,      new MetadataItemInfo("Software",                MetaFormat.Ansi) },
            { 306,      new MetadataItemInfo("DateTime",                MetaFormat.Date) },
            { 513,      new MetadataItemInfo("ThumbnailOffset") },	// TODO: Better name
			{ 314,      new MetadataItemInfo("ThumbnailLength") },
            { 315,      new MetadataItemInfo("Artist") },
            { 338,      new MetadataItemInfo("ExtraSamples") },
            { 530,      new MetadataItemInfo("YCbCrSubSampling") },
            { 531,      new MetadataItemInfo("YCbCrPositioning") },
            { 33432,    new MetadataItemInfo("Copyright",               MetaFormat.Ansi) },
				
			// EXIF Metadata		
			{ 33434,    new MetadataItemInfo("ExposureTime",            MetaFormat.Rational) }, // 33434, "Exposure time, given in seconds") },
			{ 33437,    new MetadataItemInfo("FNumber",                 MetaFormat.Rational) },
            { 34850,    new MetadataItemInfo("ExposureProgram",         new NumberToEnum<ExposureProgram>()) },
            { 34852,    new MetadataItemInfo("SpectralSensitivity") },
            { 34855,    new MetadataItemInfo("PhotographicSensitivity") },
            { 34856,    new MetadataItemInfo("OECF") },
            { 34864,    new MetadataItemInfo("SensitivityType",         new NumberToEnum<SensitivityType>()) },
            { 34865,    new MetadataItemInfo("StandardOutputSensitivity") },
            { 34866,    new MetadataItemInfo("RecommendedExposureIndex") },
            { 34867,    new MetadataItemInfo("ISOSpeed") },
            { 34868,    new MetadataItemInfo("ISOSpeedLatitudeyyy") },
            { 34869,    new MetadataItemInfo("ISOSpeedLatitudezzz") },
            { 36864,    new MetadataItemInfo("ExifVersion") },
            { 36867,    new MetadataItemInfo("DateTimeOriginal",        MetaFormat.Date) },
            { 36868,    new MetadataItemInfo("DateTimeDigitized",       MetaFormat.Date) },
            { 37377,    new MetadataItemInfo("ShutterSpeedValue",       MetaFormat.SRational) },
            { 37378,    new MetadataItemInfo("ApertureValue",           MetaFormat.Rational) },
            { 37379,    new MetadataItemInfo("BrightnessValue",         MetaFormat.SRational) },
            { 37380,    new MetadataItemInfo("ExposureBiasValue",       MetaFormat.SRational) },
            { 37381,    new MetadataItemInfo("MaxApertureValue",        MetaFormat.Rational) },
            { 37382,    new MetadataItemInfo("SubjectDistance",         MetaFormat.SRational) }, // , 37382, "The distance to the subject, given in meters") },
			{ 37383,    new MetadataItemInfo("MeteringMode",            new NumberToEnum<MeteringMode>()) },
            { 37384,    new MetadataItemInfo("LightSource",             new NumberToEnum<LightSource>()) },
            { 37385,    new MetadataItemInfo("Flash") },
            { 37386,    new MetadataItemInfo("FocalLength",             MetaFormat.Rational) },
            { 37387,    new MetadataItemInfo("FlashEnergy",             MetaFormat.Rational) },
            { 37396,    new MetadataItemInfo("SubjectArea") },
            { 37500,    new MetadataItemInfo("MakerNote") },
            { 37510,    new MetadataItemInfo("UserComment") },
            { 37520,    new MetadataItemInfo("SubsecTime",              MetaFormat.Long, 37520, "A tag used to record fractions of seconds for the DateTime tag.") },
            { 37522,    new MetadataItemInfo("SubsecTimeDigitized",     MetaFormat.Long, 37522) },
            { 40960,    new MetadataItemInfo("FlashpixVersion" ) },
            // { 40961,    new MetadataItemInfo("ColorSpace",              new NumberToEnum<ColorSpace>()) }, 1 = sRGB, 65535 = Uncalibrated
            { 40962,    new MetadataItemInfo("PixelXDimension") },
            { 40963,    new MetadataItemInfo("PixelYDimension") },
            { 41483,    new MetadataItemInfo("FlashEnergy") },
            { 41484,    new MetadataItemInfo("SpatialFrequencyResponse") },
            { 41486,    new MetadataItemInfo("FocalPlaneXResolution") },
            { 41487,    new MetadataItemInfo("FocalPlaneYResolution") },
            { 41488,    new MetadataItemInfo("FocalPlaneResolutionUnit", new NumberToEnum<FocalPlaneMeasurementUnit>()) },
            { 41492,    new MetadataItemInfo("SubjectLocation") },
            { 41493,    new MetadataItemInfo("ExposureIndex") },
            { 41495,    new MetadataItemInfo("SensingMethod",           new NumberToEnum<SensingMethod>()) },
            { 41728,    new MetadataItemInfo("FileSource") },
            { 41729,    new MetadataItemInfo("SceneType") },
            { 41730,    new MetadataItemInfo("CFAPattern") },
            { 41985,    new MetadataItemInfo("CustomRendered") },
            { 41986,    new MetadataItemInfo("ExposureMode",            new NumberToEnum<FocalPlaneMeasurementUnit>()) },
            { 41987,    new MetadataItemInfo("WhiteBalance",            new NumberToEnum<WhiteBalance>()) },
            { 41988,    new MetadataItemInfo("DigitalZoomRatio") },
            { 41989,    new MetadataItemInfo("FocalLengthIn35mmFilm") },
            { 41990,    new MetadataItemInfo("SceneCaptureType",        new NumberToEnum<SceneCaptureType>()) },
            { 41991,    new MetadataItemInfo("GainControl",             new NumberToEnum<GainControl>()) },
            { 41992,    new MetadataItemInfo("Contrast") },
            { 41993,    new MetadataItemInfo("Saturation") },
            { 41995,    new MetadataItemInfo("DeviceSettingDescription") },
            { 41996,    new MetadataItemInfo("SubjectDistanceRange",    new NumberToEnum<SceneCaptureType>()) },
            { 42016,    new MetadataItemInfo("ImageUniqueID",           MetaFormat.Ansi, 42016) },
            { 42032,    new MetadataItemInfo("CameraOwnerName",         MetaFormat.Ansi, 42032) },
            { 42033,    new MetadataItemInfo("BodySerialNumber",        MetaFormat.Ansi, 42033) },
            { 42034,    new MetadataItemInfo("LensSpecification") },
            { 42035,    new MetadataItemInfo("LensMake",                MetaFormat.Ansi, 42035) },
            { 42036,    new MetadataItemInfo("LensModel",               MetaFormat.Ansi, 42036) },
            { 42037,    new MetadataItemInfo("LensSerialNumber",        MetaFormat.Ansi, 42037) }
        };

        public static MetadataItemInfo Get(string path)
        {
            MetadataItemInfo info;

            if (PathsToNames.TryGetValue(path, out info))
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

    public class PrettyMetadata
    {
        public MediaOrientation Orientation { get; set; }

        // Dave Gorum <dave@carbonmade.com>			// EMAIL FORMAT
        public string Creator { get; set; }

        // Rights Holder
        public string Owner { get; set; }

        public string Camera { get; set; }

        public LocationDetails Location { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }
    }

    public class LocationDetails
    {
        public double Longitude { get; set; }

        public double Latitude { get; set; }

        public double Altitude { get; set; } // TODO, use a unit
                                             // Name
    }
}

// http://msdn.microsoft.com/en-us/library/windows/desktop/ee719904(v=vs.85).aspx

// http://nicholasarmstrong.com/2010/02/exif-quick-reference/

// http://www.sno.phy.queensu.ca/~phil/exiftool/TagNames/EXIF.html
/*
 creator: "x"																// Dave Gorum <dave@carbonmade.com>			// EMAIL FORMAT
 owner: "x"																	// Dave Gorum <dave@carbonmade.com>			(Rights Holder)?
 licences: [ "1", "2" ]
 camera: "Nikon D5"															// Combine Make & Model
 created: "2012-05-15T15:01:19Z"
 modified: "2012-05-15T15:01:19Z" 
 location: { longitude: "x", latitude: "x", name: "New York, NY" }
*/
