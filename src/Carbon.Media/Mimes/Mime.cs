using System;
using System.IO;

namespace Carbon.Media
{
    public sealed class Mime : IEquatable<Mime>
    {
        internal Mime(string name, string format, MagicNumber[] magicNumbers = null)
        {
            Name       = name ?? throw new ArgumentNullException(nameof(name));
            Format     = format ?? throw new ArgumentNullException(nameof(name));
            Type       = MediaTypeHelper.Parse(name.AsSpan().Slice(0, name.IndexOf('/')));
            Signatures = magicNumbers ?? Array.Empty<MagicNumber>();
        }
        
        public string Name { get; }

        public MediaType Type { get; }

        public MagicNumber[] Signatures { get; } 

        public string Format { get; }
        
        public override string ToString() => Name;

        #region Equality

        public bool Equals(Mime other) => other?.Name == Name;

        public override int GetHashCode() => Name.GetHashCode();

        public override bool Equals(object obj) => obj is Mime other && Equals(other);

        #endregion

        public static implicit operator string(Mime mime) => mime.Name;

        public void Deconstruct(out MediaType type, out string name)
        {
            type = Type;
            name = Name.Substring(Name.IndexOf('/') + 1);
        }

        #region Static Constructors

        public static Mime Parse(string name)
        {
            if (name is null) throw new ArgumentNullException(nameof(name));

            if (name.IndexOf('/') > -1)
            {
                if (MimeHelper.TryGetFromName(name, out Mime mime))
                {
                    return mime;
                }
                else
                {
                    throw new Exception($"No mime found for '{name}'.");
                }
            }

            return Mime.FromFormat(name);
        }

        public static Mime FromPath(string path)
        {
            return FromExtension(Path.GetExtension(path));
        }

        public static Mime FromExtension(string extension)
        {
            if (extension is null) throw new ArgumentNullException(nameof(extension));
            
            if (extension[0] == '.')
            {
                extension = extension.Substring(1);
            }

            return FromFormat(extension);
        }

        public static Mime FromFormat(FormatId format)
        {
            switch (format)
            {
                // Audio
                case FormatId.Aac  : return Aac;
                case FormatId.Flac : return Flac;
                case FormatId.M4a  : return M4a; 
                case FormatId.Mp3  : return Mp3;
                case FormatId.Oga  : return Oga;
                case FormatId.Opus : return Opus;

                // Images
                case FormatId.Bmp  : return Bmp;
                case FormatId.Bpg  : return Bpg;
                case FormatId.Gif  : return Gif;
                case FormatId.Dng  : return Dng;
                case FormatId.Heif : return Heif;
                case FormatId.Ico  : return Ico;
                case FormatId.Jpeg : return Jpeg;
                case FormatId.Jp2  : return Jp2;
                case FormatId.Jxr  : return Jxr;
                case FormatId.Png  : return Png;
                case FormatId.Psd  : return Psd;
                case FormatId.Svg  : return Svg;
                case FormatId.Tiff : return Tiff;
                case FormatId.WebP : return WebP;

                // Videos
                case FormatId.Mp4  : return Mp4;
                case FormatId.M4v  : return M4v;
                case FormatId.WebM : return WebM;

                // Fonts
                case FormatId.Ttf   : return Ttf;
                case FormatId.Woff  : return Woff;
                case FormatId.Woff2 : return Woff2;
            }

            return MimeHelper.FormatToMimeMap.TryGetValue(format.ToString().ToLower(), out Mime mime)
                ? mime
                : throw new Exception($"No mime found for '{format}'.");
        }

        public static Mime FromFormat(string format)
        {
            if (format is null) throw new ArgumentNullException(nameof(format));

            return MimeHelper.FormatToMimeMap.TryGetValue(format.ToLower(), out Mime mime)
               ? mime
               : throw new Exception($"No mime found for '{format}'.");
        }

        public static bool TryGetFromFormat(string format, out Mime mime)
        {
            if (format is null) throw new ArgumentNullException(nameof(format));

            return MimeHelper.FormatToMimeMap.TryGetValue(format, out mime);
        }

        #endregion

        // Binary Blob
        public static readonly Mime Blob = new Mime("application/octet-stream", "blob");

        // Applications
        public static readonly Mime Ai   = new Mime("application/postscript",        "ai");
        public static readonly Mime Atom = new Mime("application/atom+xml",          "atom");
        public static readonly Mime Doc  = new Mime("application/msword",            "doc", new[] { MagicNumber.Doc });
        public static readonly Mime M3u8 = new Mime("application/x-mpegURL",         "m3u8");
        public static readonly Mime Mpd  = new Mime("application/dash+xml",          "mpd");
        public static readonly Mime Pdf  = new Mime("application/pdf",               "pdf", new[] { MagicNumber.Pdf });
        public static readonly Mime Swf  = new Mime("application/x-shockwave-flash", "swf");
        public static readonly Mime Xap  = new Mime("application/x-silverlight-app", "xap");
        public static readonly Mime Xaml = new Mime("application/xaml+xml",          "xaml");
        public static readonly Mime Ps   = new Mime("application/postscript",        "ps");

        // Applications - Programing Languages & Data Formats
        public static readonly Mime Js   = new Mime("application/javascript", "js");
        public static readonly Mime Json = new Mime("application/json",       "json");

        // Applications - Color Profiles
        public static readonly Mime Icc = new Mime("application/vnd.iccprofile", "icc");

        // Applications - Archives
        public static readonly Mime Tar           = new Mime("application/tar",  "tar");
        public static readonly Mime CompressedTar = new Mime("application/gzip", "tar.gz");
        public static readonly Mime Zip           = new Mime("application/zip",  "zip");

        // Applications - Multimedia containers
        public static readonly Mime Mxf = new Mime("application/mxf", "mxf");


        // Audio (2000-2999)
        public static readonly Mime _3GP_A   = new Mime("audio/3gpp",           "3gp");
        public static readonly Mime _3GP2_A  = new Mime("audio/3gpp2",          "3g2");
        public static readonly Mime Aac      = new Mime("audio/aac",            "aac",    new[] { MagicNumber.Aac_1, MagicNumber.Aac_2 });
        public static readonly Mime Aiff     = new Mime("audio/aiff",           "aiff",   new[] { MagicNumber.Aiff });
        public static readonly Mime Au       = new Mime("audio/au",             "au");
        public static readonly Mime Flac     = new Mime("audio/flac",           "flac",   new[] { MagicNumber.Flac });
        public static readonly Mime Mka      = new Mime("audio/x-matroska",     "mka");
        public static readonly Mime Mp3      = new Mime("audio/mpeg",           "mp3",    new[] { MagicNumber.Mp3_1, MagicNumber.Mp3_2 });
        public static readonly Mime Mpc      = new Mime("audio/musepack",       "mpc");
        public static readonly Mime M4a      = new Mime("audio/mp4",            "m4a",    new[] { MagicNumber.M4a });
        public static readonly Mime Oga      = new Mime("audio/ogg",            "oga");
        public static readonly Mime Opus     = new Mime("audio/opus",           "opus",   new[] { MagicNumber.Opus });
        public static readonly Mime Spx      = new Mime("audio/speex",          "spx");
        public static readonly Mime Qcelp    = new Mime("audio/qcelp",          "qcelp");
        public static readonly Mime Ra       = new Mime("audio/x-realaudio",    "ra");
        public static readonly Mime Tta      = new Mime("audio/x-tta",          "tta");
        public static readonly Mime Wav      = new Mime("audio/wav",            "wav",    new[] { MagicNumber.Wav });
        public static readonly Mime Wma      = new Mime("audio/x-ms-wma",       "wma",    new[] { MagicNumber.Wma });
                                                                                
        // Image (4000-4999)                                                    
        public static readonly Mime Apng     = new Mime("image/apng",           "apng");
        public static readonly Mime Bmp      = new Mime("image/bmp",            "bmp",    new[] { MagicNumber.Bmp });
        public static readonly Mime Bpg      = new Mime("image/bpg",            "bpg",    new[] { MagicNumber.Bgp });
        public static readonly Mime Cr2      = new Mime("image/x-canon-cr2",    "cr2",    new[] { MagicNumber.Cr2 });
        public static readonly Mime Dng      = new Mime("image/dng",            "dng");
        public static readonly Mime Fits     = new Mime("image/fits",           "fits");
        public static readonly Mime Fpx      = new Mime("image/fpx",            "fpx");
        public static readonly Mime Gif      = new Mime("image/gif",            "gif",    new[] { MagicNumber.Gif87a, MagicNumber.Gif89a});
        public static readonly Mime Heic     = new Mime("image/heic",           "heic");
        public static readonly Mime Heif     = new Mime("image/heif",           "heif");
        public static readonly Mime Ico      = new Mime("image/x-icon",         "ico",    new[] { MagicNumber.Ico });  // [0]
        public static readonly Mime Jp2      = new Mime("image/jp2",            "jp2",    new[] { MagicNumber.Jp2 });
        public static readonly Mime Jpeg     = new Mime("image/jpeg",           "jpeg",   new[] { MagicNumber.Jpeg_1, MagicNumber.Jpeg_2, MagicNumber.Jpeg_3 });
        public static readonly Mime Jxr      = new Mime("image/jxr",            "jxr");
        public static readonly Mime Orf      = new Mime("image/x-olympus-orf",  "orf");
        public static readonly Mime Png      = new Mime("image/png",            "png",    new[] { MagicNumber.Png });
        public static readonly Mime Psd      = new Mime("image/psd",            "psd",    new[] { MagicNumber.Psd } );
        public static readonly Mime Raf      = new Mime("image/x-fuji-raf",     "raf",    new[] { MagicNumber.Raf });
        public static readonly Mime Sgi      = new Mime("image/sgi",            "sgi");
        public static readonly Mime Svg      = new Mime("image/svg+xml",        "svg");
        public static readonly Mime Tga      = new Mime("image/targa",          "tga");
        public static readonly Mime Tiff     = new Mime("image/tiff",           "tiff",   new[] { MagicNumber.Tiff_1, MagicNumber.Tiff_2 });
        public static readonly Mime WebP     = new Mime("image/webp",           "webp");

        // Text (8000-8999)
        public static readonly Mime AppCache = new Mime("text/cache-manifest",  "appcache");
        public static readonly Mime Css      = new Mime("text/css",             "css");
        public static readonly Mime Csv      = new Mime("text/csv",             "csv");
        public static readonly Mime Html     = new Mime("text/html",            "html");
        public static readonly Mime Txt      = new Mime("text/plain",           "plain");
        public static readonly Mime Xml      = new Mime("text/xml",             "xml");

        // Video (9000-9999)
        public static readonly Mime Asf      = new Mime("video/x-ms-asf",       "asf",    new[] { MagicNumber.Asf });
        public static readonly Mime _3GP     = new Mime("video/3gpp",           "3gp");
        public static readonly Mime _3GP2    = new Mime("video/3gpp2",          "3g2"); 
        public static readonly Mime Avi      = new Mime("video/x-msvideo",      "avi",    new[] { MagicNumber.Avi });
        public static readonly Mime F4v      = new Mime("video/mp4",            "f4v",    new[] { MagicNumber.F4v });
        public static readonly Mime Flv      = new Mime("video/x-flv",          "flv",    new[] { MagicNumber.Flv });
        public static readonly Mime Mk3d     = new Mime("video/x-matroska-3d",  "mk3d");
        public static readonly Mime Mkv      = new Mime("video/x-matroska",     "mkv");
        public static readonly Mime M4v      = new Mime("video/mp4",            "m4v",    new[] { MagicNumber.M4v });
        public static readonly Mime Mov      = new Mime("video/quicktime",      "mov",    new[] { MagicNumber.Mov_1, MagicNumber.Mov_2 });
        public static readonly Mime Mp4      = new Mime("video/mp4",            "mp4",    new[] { MagicNumber.Mp4_1, MagicNumber.Mp4_2, MagicNumber.Mp4_3, MagicNumber.Mp4_4, MagicNumber.Mp4_5, MagicNumber.Mp4_6, MagicNumber.Mp4_7 });
        public static readonly Mime Mpeg     = new Mime("video/mpeg",           "mpeg",   new[] { MagicNumber.Mpeg_1 });
        public static readonly Mime Ogv      = new Mime("video/ogg",            "ogv",    new[] { MagicNumber.Ogg } );
        public static readonly Mime Ts       = new Mime("video/MP2T",           "ts");
        public static readonly Mime WebM     = new Mime("video/webm",           "webm",   new[] { MagicNumber.WebM });
        public static readonly Mime Wmv      = new Mime("video/x-ms-wmv",       "wmv");
        
        // Multipart
        public static readonly Mime FormData = new Mime("multipart/form-data",  "formdata");

        // Fonts ------
        public static readonly Mime Eot   = new Mime("application/vnd.ms-fontobject", "eot");
        public static readonly Mime Otf   = new Mime("font/otf",  "otf",                        new[] { MagicNumber.Otf });
        public static readonly Mime Ttf   = new Mime("font/ttf",   "ttf");
        public static readonly Mime Woff  = new Mime("font/woff",  "woff");
        public static readonly Mime Woff2 = new Mime("font/woff2", "woff2");
    }
}

// NOTES -----------------------------------------------------------------------------------------------------------------------
// [0]:	Internet Explorer 8 does not accept the official mime type "image/vnd.microsoft.icon". Must be "Content-Type: image/x-icon".

// http://en.wikipedia.org/wiki/Internet_media_type
// A media type is composed of two or more parts: A type, a subtype, and zero or more optional parameters.
// For example, subtypes of text have an optional charset parameter that can be included to indicate the character encoding e.g. text/html; charset=UTF-8),
// and subtypes of multipart type often define a boundary between parts. Allowed charset values are defined in the list of IANA character sets.