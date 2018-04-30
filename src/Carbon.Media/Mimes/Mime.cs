using System;
using System.IO;

namespace Carbon.Media
{
    public sealed class Mime : IEquatable<Mime>
    {
        internal Mime(string name, string format = null)
            : this(name, new[] { format }) { }

        internal Mime(string name, string[] formats)
        {
            if (formats == null)
                throw new ArgumentNullException(nameof(formats));

            if (formats.Length == 0)
                throw new ArgumentException("Must not be empty", paramName: nameof(formats));

            Name       = name ?? throw new ArgumentNullException(nameof(name));
            Formats    = formats;
            Type       = name.Substring(0, name.IndexOf('/')).ToEnum<MediaType>(ignoreCase: true);
            Signatures = Array.Empty<MagicNumber>();
        }

        internal Mime(string name, string[] formats, MagicNumber[] magicNumbers)
            : this(name, formats)
        {
            Signatures = magicNumbers;
        }

        public string Name { get; }

        public MediaType Type { get; }

        public string[] Formats { get; }

        public MagicNumber[] Signatures { get; } 

        public string Format => Formats[0];
        
        public override string ToString() => Name;

        #region Equality

        public bool Equals(Mime other) => other?.Name == Name;

        public override int GetHashCode() => Name.GetHashCode();

        public override bool Equals(object obj) => (obj as Mime)?.Equals(this) == true;

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
            if (name == null) throw new ArgumentNullException(nameof(name));

            Mime mime;

            if (name.Contains("/"))
            {
                if (MimeHelper.NameToMimeMap.TryGetValue(name, out mime))
                {
                    return mime;
                }
            }
            else
            {
                if (MimeHelper.FormatToMimeMap.TryGetValue(name, out mime))
                {
                    return mime;
                }
            }

            throw new Exception($"No mime found for '{name}'.");
        }

        public static Mime FromPath(string path)
        {
            return FromExtension(Path.GetExtension(path));
        }

        public static Mime FromExtension(string extension)
        {
            if (extension == null) throw new ArgumentNullException(nameof(extension));

            return FromFormat(extension.TrimStart('.'));
        }

        public static Mime FromFormat(string format)
        {
            if (format == null)
            {
                throw new ArgumentNullException(nameof(format));
            }

            if (MimeHelper.FormatToMimeMap.TryGetValue(format.ToLower(), out Mime mime))
            {
                return mime;
            }
            else
            {
                throw new Exception($"No mime match for '{format}'.");
            }
        }

        public static bool TryGetFromFormat(string format, out Mime mime)
        {
            if (format == null)
            {
                throw new ArgumentNullException(nameof(format));
            }

            return MimeHelper.FormatToMimeMap.TryGetValue(format, out mime);
        }

        #endregion

        // Binary Blob
        public static readonly Mime Blob = new Mime("application/octet-stream", "blob");

        // Applications
        public static readonly Mime Ai   = new Mime("application/illustrator",       new[] { "ai" });
        public static readonly Mime Atom = new Mime("application/atom+xml",          "atom");
        public static readonly Mime Doc  = new Mime("application/msword",            new[] { "doc" }, new[] { MagicNumber.Doc });
        public static readonly Mime M3u8 = new Mime("application/x-mpegURL",         "m3u8");
        public static readonly Mime Mpd  = new Mime("application/dash+xml",          "mpd");
        public static readonly Mime Pdf  = new Mime("application/pdf",               new[] { "pdf" }, new[] { MagicNumber.Pdf });
        public static readonly Mime Swf  = new Mime("application/x-shockwave-flash", "swf");
        public static readonly Mime Xap  = new Mime("application/x-silverlight-app", "xap");
        public static readonly Mime Xaml = new Mime("application/xaml+xml",          "xaml");
        public static readonly Mime Ps   = new Mime("application/postscript",        "ps");

        // Applications - Programing Languages & Data Formats
        public static readonly Mime Js   = new Mime("application/javascript", "js");
        public static readonly Mime Json = new Mime("application/json", "json");

        // Applications - Color Profiles
        public static readonly Mime Icc = new Mime("application/vnd.iccprofile", "icc");

        // Applications - Archives
        public static readonly Mime Tar           = new Mime("application/tar",  "tar");
        public static readonly Mime CompressedTar = new Mime("application/gzip", "tar.gz");
        public static readonly Mime Zip           = new Mime("application/zip",  "zip");

        // Audio (2000-2999)
        public static readonly Mime Aac      = new Mime("audio/aac",         new[] { "aac", "m4a" });
        public static readonly Mime Aiff     = new Mime("audio/aiff",        new[] { "aiff", "aif", "aifc" }, new[] { MagicNumber.Aiff });
        public static readonly Mime Au       = new Mime("audio/au",          new[] { "au" });
        public static readonly Mime Flac     = new Mime("audio/flac",        new[] { "flac" }, new[] { MagicNumber.Flac });
        public static readonly Mime Mka      = new Mime("audio/x-matroska",  "mka");
        public static readonly Mime Mp3      = new Mime("audio/mpeg",        new[] { "mp3" }, new[] { MagicNumber.Mp3 });
        public static readonly Mime Mpc      = new Mime("audio/musepack",    "mpc");
        public static readonly Mime M4a      = new Mime("audio/mp4",         "m4a");
        public static readonly Mime Oga      = new Mime("audio/ogg",         "oga");
        public static readonly Mime Opus     = new Mime("audio/opus",        new[] { "opus" }, new[] { MagicNumber.Opus });
        public static readonly Mime Spx      = new Mime("audio/speex",       "spx");
        public static readonly Mime Qcelp    = new Mime("audio/qcelp",       "qcelp");
        public static readonly Mime Ra       = new Mime("audio/x-realaudio", new[] { "ra", "ram" });
        public static readonly Mime Wav      = new Mime("audio/wav",         new[] { "wav", "wave" }, new[] { MagicNumber.Wav1, MagicNumber.Wav2 });
        public static readonly Mime Wma      = new Mime("audio/x-ms-wma",    new[] { "wma" }, new[] { MagicNumber.Wma });

        // Image (4000-4999)
        public static readonly Mime Bmp      = new Mime("image/bmp",         new[] { "bmp" }, new[] { MagicNumber.Bmp });
        public static readonly Mime Bpg      = new Mime("image/bpg",         new[] { "bpg" }, new[] { MagicNumber.Bgp });
        public static readonly Mime Dng      = new Mime("image/dng",         "dng");
        public static readonly Mime Fpx      = new Mime("image/fpx",         new[] { "fpx", "fpix" });
        public static readonly Mime Gif      = new Mime("image/gif",         new[] { "gif" }, new[] { MagicNumber.Gif87a, MagicNumber.Gif89a});
        public static readonly Mime Heif     = new Mime("image/heif",        new[] { "heif", "heic" });
        public static readonly Mime Ico      = new Mime("image/x-icon",      new[] { "ico" }, new[] { MagicNumber.Ico });  // [0]
        public static readonly Mime Jp2      = new Mime("image/jp2",         new[] { "jp2", "j2k", "jpf", "jpx", "jpm", "mj2" }, new[] { MagicNumber.Jp2 });
        public static readonly Mime Jpeg     = new Mime("image/jpeg",        new[] { "jpeg", "jpg", "jpe", "jif", "jfif", "jfi" }, new[] { MagicNumber.Jpeg1, MagicNumber.Jpeg2, MagicNumber.Jpeg3 });
        public static readonly Mime Jxr      = new Mime("image/jxr",         new[] { "jxr", "hdp", "wdp" });
        public static readonly Mime Png      = new Mime("image/png",         new[] { "png" }, new[] { MagicNumber.Png });
        public static readonly Mime Psd      = new Mime("image/psd",         new[] { "psd" }, new[] { MagicNumber.Psd } );
        public static readonly Mime Sgi      = new Mime("image/sgi",         "sgi");
        public static readonly Mime Svg      = new Mime("image/svg+xml",     "svg");
        public static readonly Mime Tga      = new Mime("image/targa",       "tga");
        public static readonly Mime Tiff     = new Mime("image/tiff",        new[] { "tiff", "tif" }, new[] { MagicNumber.Tiff1, MagicNumber.Tiff2 });
        public static readonly Mime WebP     = new Mime("image/webp",        "webp");

        // Text (8000-8999)
        public static readonly Mime AppCache = new Mime("text/cache-manifest", "appcache");
        public static readonly Mime Css      = new Mime("text/css",     "css");
        public static readonly Mime Csv      = new Mime("text/csv",     "csv");
        public static readonly Mime Html     = new Mime("text/html",    "html");
        public static readonly Mime Txt      = new Mime("text/plain",   "plain");
        public static readonly Mime Xml      = new Mime("text/xml",     "xml");

        // Video (9000-9999)
        public static readonly Mime Avi      = new Mime("video/x-msvideo",  new[] { "avi" }, new[] { MagicNumber.Avi });
        public static readonly Mime F4v      = new Mime("video/mp4",        "mp4");
        public static readonly Mime Flv      = new Mime("video/x-flv",      new[] { "flv" }, new[] { MagicNumber.Flv });
        public static readonly Mime Mkv      = new Mime("video/x-matroska", new[] { "mkv", "mk3d", "mks" });
        public static readonly Mime Mov      = new Mime("video/quicktime",  "mov");
        public static readonly Mime Mp4      = new Mime("video/mp4",        new[] { "mp4", "m4v" });
        public static readonly Mime Mpeg     = new Mime("video/mpeg",       "mpeg");
        public static readonly Mime Ogv      = new Mime("video/ogg",        new[] { "ogv", "ogg" }, new[] { MagicNumber.Ogg } ); // http://tools.ietf.org/html/rfc5334 (predominantly video)
        public static readonly Mime Ts       = new Mime("video/MP2T",       "ts");
        public static readonly Mime WebM     = new Mime("video/webm",       "webm");
        public static readonly Mime Wmv      = new Mime("video/x-ms-wmv",   "wmv");

        // Containers (Audio & Video Variations) ----
        public static readonly Mime _3GP     = new Mime("video/3gpp",      "3gp");
        public static readonly Mime _3GP2    = new Mime("video/3gpp2",     "3g2"); 
        public static readonly Mime Mxf      = new Mime("application/mxf", "mxf");

        public static readonly Mime _3GP_Audio  = new Mime("audio/3gpp",   "3gp"); // Can be audio or video...
        public static readonly Mime _3GP2_Audio = new Mime("audio/3gpp2",  "3g2"); // Can be audio or video...



        // Fonts 
        public static readonly Mime Eot   = new Mime("application/vnd.ms-fontobject", "eot");
        public static readonly Mime Otf   = new Mime("font/otf",   new[] { "otf" }, new[] { MagicNumber.Otf });
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