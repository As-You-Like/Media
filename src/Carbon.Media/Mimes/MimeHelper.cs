using System;
using System.Collections.Generic;

namespace Carbon.Media
{
    using static Mime;

    internal static class MimeHelper
    {
        private static readonly Dictionary<string, Mime> applicationTypes = new Dictionary<string, Mime>
        {
            // application/ + 				   TYPE			    NAME
			{ "atom+xml",           Atom },	// Document		    Atom
			{ "octet-stream",       Blob },	// Data			    Binary Blob
			{ "msword",             Doc },	// Document		    Word
			{ "vnd.iccprofile",     Icc },	// Color Profile    ICC
			{ "vnd.ms-fontobject",  Eot },	// Font			    EOT
			{ "javascript",         Js },	// Script		    JavaScript
			{ "json",               Json },	// Data			    JSON
			{ "x-shockwave-flash",  Swf },	// Plugin		    Flash
			{ "x-font-ttf",         Ttf },	// Font			    TTF
			{ "pdf",                Pdf },	// Document		    PDF
			{ "x-silverlight-app",  Xap },	// Plugin		    Silverlight
			{ "x-font-woff",        Woff },	// Font			    woff
			{ "font-woff",          Woff }, // Font			    woff
            { "tar",                Tar },  // Package          TAR
            { "zip",                Zip },  // Package		    ZIP		
        };

        private static readonly Dictionary<string, Mime> audioTypes = new Dictionary<string, Mime>
        {
            // audio/ +
            { "aac",            Aac },
            { "aiff",           Aiff },
            { "flac",           Flac },
            { "mp3",            Mp3 },
            { "mp4",            M4a },
            { "mpeg",           Mp3 },
            { "ogg",            Oga },
            { "opus",           Opus },
            { "x-realaudio",    Ra },
            { "wav",            Wav },
            { "x-ms-wma",       Wma },
        };

        private static readonly Dictionary<string, Mime> imageTypes = new Dictionary<string, Mime>
        {
            // image/ +
            { "apng",           Apng },
            { "bmp",            Bmp },
            { "x-bmp",          Bmp },
            { "gif",            Gif },
            { "heif",           Heif },
            { "x-icon",         Ico },
            { "jpeg",           Jpeg },
            { "jxr",            Jxr },
            { "vnd.ms-photo",   Jxr },	 // Jpeg XR
			{ "png",            Png },
            { "psd",            Psd },
            { "svg+xml",        Svg },
            { "tiff",           Tiff },
            { "tiff-fx",        Tiff },
            { "webp",           WebP },
        };

        private static readonly Dictionary<string, Mime> textTypes = new Dictionary<string, Mime>
        {
            // text/ +
            { "cache-manifest", AppCache },
            { "css",            Css },
            { "csv",            Csv },
            { "html",           Html },
            { "plain",          Txt },
            { "xml",            Xml },
        };

        private static readonly Dictionary<string, Mime> videoTypes = new Dictionary<string, Mime>
        {
            // video/ + 
            { "x-msvideo",      Avi },
            { "x-flv",          Flv },
            { "mpeg",           Mpeg },
            { "quicktime",      Mov },
            { "mp4",            Mp4 },
            { "MP2T",           Ts },
            { "ogg",            Ogv },
            { "webm",           WebM },
            { "x-ms-wmv",       Wmv },
        };

        private static readonly Dictionary<string, Mime> fontTypes = new Dictionary<string, Mime>
        {
            // font/ +
            { "otf",            Otf },
            { "ttf",            Ttf },
            { "woff",           Woff },
            { "woff2",          Woff2 }
        };
    
        public static Dictionary<MediaType, Dictionary<string, Mime>> sets = new Dictionary<MediaType, Dictionary<string, Mime>>
        {
            [MediaType.Application] = applicationTypes,
            [MediaType.Audio] = audioTypes,
            [MediaType.Font] = fontTypes,
            [MediaType.Image] = imageTypes,
            [MediaType.Text] = textTypes,
            [MediaType.Video] = videoTypes
        };

        internal static bool TryGetFromName(string name, out Mime result)
        {
            int seperatorIndex = name.IndexOf('/');

            var lhs = name.AsSpan().Slice(0, seperatorIndex);
            var rhs = name.Substring(seperatorIndex + 1);

            if (sets.TryGetValue(MediaTypeHelper.Parse(lhs), out var set))
            {
                return set.TryGetValue(rhs, out result);
            }

            result = default;

            return false;
        }

        internal static readonly Dictionary<string, Mime> FormatToMimeMap = new Dictionary<string, Mime> {
			
			// Applications	      TYPE              NAME
			{ "ai",     Ai },	  //			    Illustrator
			{ "atom",   Atom },	  // Document	    Atom
			{ "blob",   Blob },	  // Data		    Binary Blob
			{ "doc",    Doc },	  // Document	    Word
            { "icc",    Icc },    // Color Profile
            { "mpd",    Mpd },	  // Dash
			{ "js",     Js },	  // Script		    JavaScript
			{ "json",   Json },	  // Data		    JSON
			{ "swf",    Swf },	  // Plugin		    Flash
			{ "pdf",    Pdf },	  // Document	    PDF
			{ "xap",    Xap },    // Plugin		    Silverlight
			{ "zip",    Zip },	  // Package	    ZIP			

            // Containers ----
            { "asf",    Asf }, // Advanced Systems Format

			// Audio --------------------------------------------
			{ "aac",    Aac },
            { "aif",    Aiff },
            { "aifc",   Aiff },
            { "aiff",   Aiff },
            { "flac",   Flac },
            { "m4a",    M4a },
            { "mp3",    Mp3 },
            { "oga",    Oga },
            { "opus",   Opus },
            { "ra",     Ra },
            { "ram",    Ra },
            { "wav",    Wav },
            { "wave",   Wav },
            { "wma",    Wma },

            // Images --------------------------------------------
            { "apng",   Apng },
            { "bpg",    Bpg }, 
			{ "bmp",    Bmp },
            { "cr2",    Cr2 },
            { "dng",    Dng },
            { "fpx",    Fpx },
            { "fpix",   Fpx },  // alias
            { "gif",    Gif },
            { "hdp",    Jxr },  // alis
            { "heif",   Heif },
            { "ico",    Ico },
            { "j2k",    Jp2 },  // alias
            { "jif",    Jpeg }, // alias
            { "jiff",   Jpeg }, // alias
            { "jp2",    Jp2 }, 
			{ "jpg",    Jpeg }, // alias
            { "jpeg",   Jpeg },
            { "jxr",    Jxr }, 
			{ "png",    Png },
            { "psd",    Psd },
            { "sgi",    Sgi },
            { "svg",    Svg },
            { "tif",    Tiff },
            { "tiff",   Tiff },
            { "wdp",    Jxr },  // alias
            { "webp",   WebP },

            // JP2 aliases
            
            { "jpf", Jp2 },
            { "jpx", Jp2 },
            { "jpm", Jp2 },
            { "mj2", Jp2 },

            // JPEG aliases
            { "jfi", Jpeg },

			// Text --------------------------------------------
			{ "appcache", AppCache },
            { "css",      Css },
            { "csv",      Csv },
            { "htm",      Html },
            { "html",     Html },
            { "txt",      Txt },
            { "xml",      Xml },

            // Videos --------------------------------------------
			{ "avi",    Avi },
            { "f4v",    F4v },
            { "flv",    Flv },
            { "m4v",    M4v },
            { "mpg",    Mpeg },
            { "mpeg",   Mpeg },
            { "mov",    Mov },
            { "mp4",    Mp4 },
            { "ogg",    Ogv },
            { "ogv",    Ogv },
            { "ts",     Ts },
            { "qt",     Mov },
            { "webm",   WebM },
            { "wmv",    Wmv },

            // Fonts --------------------------------------------
            { "eot",    Eot },
            { "ttf",    Ttf },
            { "otf",    Otf },
			{ "woff",   Woff },	 
            { "woff2",  Woff2 },
        };
    }
}