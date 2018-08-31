using System.Collections.Generic;

namespace Carbon.Media
{
    using static Mime;

    internal static class MimeHelper
    {
        internal static readonly Dictionary<string, Mime> NameToMimeMap = new Dictionary<string, Mime> {
		
			// Applications								   TYPE			    NAME
			{ "application/atom+xml",           Atom },	// Document		    Atom
			{ "application/octet-stream",       Blob },	// Data			    Binary Blob
			{ "application/msword",             Doc },	// Document		    Word
			{ "application/vnd.iccprofile",     Icc },	// Color Profile    ICC
			{ "application/vnd.ms-fontobject",  Eot },	// Font			    EOT
			{ "application/javascript",         Js },	// Script		    JavaScript
			{ "application/json",               Json },	// Data			    JSON
			{ "application/x-shockwave-flash",  Swf },	// Plugin		    Flash
			{ "application/x-font-ttf",         Ttf },	// Font			    TTF
			{ "application/pdf",                Pdf },	// Document		    PDF
			{ "application/x-silverlight-app",  Xap },	// Plugin		    Silverlight
			{ "application/x-font-woff",        Woff },	// Font			    woff
			{ "application/font-woff",          Woff }, // Font			    woff
            { "application/tar",                Tar },  // Package          TAR
            { "application/zip",                Zip },  // Package		    ZIP			

            // Audio --------------------------------------------
            { "audio/aac",                      Aac },
			{ "audio/flac",                     Flac },
            { "audio/mp3",                      Mp3 },
            { "audio/mp4",                      M4a },
            { "audio/mpeg",                     Mp3 },
            { "audio/ogg",                      Oga },
            { "audio/opus",                     Opus },
            { "audio/x-realaudio",              Ra },
            { "audio/wav",                      Wav },
            { "audio/x-ms-wma",                 Wma },

			// Images --------------------------------------------
			{ "image/bmp",                      Bmp },
            { "image/x-bmp",                    Bmp },
            { "image/gif",                      Gif },
            { "image/heif",                     Heif },
            { "image/x-icon",                   Ico },
            { "image/jpeg",                     Jpeg },
            { "image/vnd.ms-photo",             Jxr },	 // Jpeg XR
			{ "image/png",                      Png },
            { "image/psd",                      Psd },
            { "image/svg+xml",                  Svg },
            { "image/tiff",                     Tiff },
            { "image/tiff-fx",                  Tiff },
            { "image/webp",                     WebP },

			// Text --------------------------------------------
			{ "text/cache-manifest",            AppCache },
            { "text/css",                       Css },
            { "text/csv",                       Csv },
            { "text/html",                      Html },
            { "text/plain",                     Txt },
            { "text/xml",                       Xml },

			// Videos --------------------------------------------
			{ "video/x-msvideo",                Avi },
            { "video/x-flv",                    Flv },
            { "video/mpeg",                     Mpeg },
            { "video/quicktime",                Mov },
            { "video/mp4",                      Mp4 },
            { "video/MP2T",                     Ts },
            { "video/ogg",                      Ogv },
            { "video/webm",                     WebM },
            { "video/x-ms-wmv",                 Wmv },

            // Fonts --------------------------------------------
            { "font/ttf",                       Ttf },
            { "font/woff",                      Woff },
            { "font/woff2",                     Woff2 }
        };

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
            { "wav",    Wav },
            { "wma",    Wma },

            // Images --------------------------------------------
            { "bpg",    Bpg },  // Better portable graphics
			{ "bmp",    Bmp },
            { "fpx",    Fpx },
            { "gif",    Gif },
            { "hdp",    Jxr },
            { "heif",   Heif },
            { "ico",    Ico },
            { "jp2",    Jp2 },  // JPEG 2000
			{ "jpg",    Jpeg },
            { "jpeg",   Jpeg },
            { "jxr",    Jxr },  // JPEG XR
			{ "png",    Png },
            { "psd",    Psd },
            { "sgi",    Sgi },
            { "svg",    Svg },
            { "tif",    Tiff },
            { "tiff",   Tiff },
            { "wdp",    Jxr },
            { "webp",   WebP },

			// Text --------------------------------------------
			{ "appcache", AppCache },
            { "css",      Css },
            { "csv",      Csv },
            { "htm",      Html },
            { "html",     Html },
            { "txt",      Txt },
            { "xml",      Xml },

            // Videos --------------------------------------------
            { "asf",    Asf }, // Advanced Systems Format
			{ "avi",    Avi },
            { "f4v",    F4v },
            { "flv",    Flv },
            { "m4v",    Mp4 },
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