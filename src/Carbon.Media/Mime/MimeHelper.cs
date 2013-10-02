﻿namespace Carbon.Media
{
	using System.Collections.Generic;

	internal static class MimeHelper
	{
		internal static readonly Dictionary<string, Mime> NameToMimeMap = new Dictionary<string, Mime> {
		
			// Applications										   TYPE			NAME
			{ "application/atom+xml",			Mime.Atom },	// Document		Atom
			{ "application/octet-stream",		Mime.Blob },	// Data			Binary Blob
			{ "application/msword",				Mime.Doc },		// Document		Word
			{ "application/vnd.ms-fontobject",	Mime.Eot },		// Font			EOT
			{ "application/javascript",			Mime.Js },		// Script		JavaScript
			{ "application/json",				Mime.Json },	// Data			JSON
			{ "application/x-shockwave-flash",	Mime.Swf },		// Plugin		Flash
			{ "application/x-font-ttf",			Mime.Ttf },		// Font			TTF
			{ "application/pdf",				Mime.Pdf },		// Document		PDF
			{ "application/x-silverlight-app",	Mime.Xap },		// Plugin		Silverlight
			{ "application/x-font-woff",		Mime.Woff },	// Font			woff
			{ "application/font-woff",			Mime.Woff },	// Font			woff
			{ "application/zip",				Mime.Zip },		// Package		ZIP			

			// Audio
			{ "audio/mp4",						Mime.Aac },
			{ "audio/mpeg",						Mime.Mp3 },
			{ "audio/opus",						Mime.Opus },
			{ "audio/x-realaudio",				Mime.Ra },
			{ "audio/wav",						Mime.Wav },
			{ "audio/x-ms-wma",					Mime.Wma },

			// Images 
			{ "image/bmp",						Mime.Bmp },
			{ "image/x-bmp",					Mime.Bmp },
			{ "image/gif",						Mime.Gif },
			{ "image/x-icon",					Mime.Ico },
			{ "image/jpeg",						Mime.Jpeg },
			{ "image/vnd.ms-photo",				Mime.Jxr },		// Jpeg XR
			{ "image/png",						Mime.Png },
			{ "image/svg+xml",					Mime.Svg },
			{ "image/tiff",						Mime.Tiff },
			{ "image/tiff-fx",					Mime.Tiff },
			{ "image/webp",						Mime.WebP },

			// Text
			{ "text/css",						Mime.Css },
			{ "text/csv",						Mime.Csv },
			{ "text/html",						Mime.Html },
			{ "text/plain",						Mime.Txt },
			{ "text/xml",						Mime.Xml },

			// Videos
			{ "video/x-msvideo",				Mime.Avi },
			{ "video/x-flv",					Mime.Flv },
			{ "video/mpeg",						Mime.Mpeg },
			{ "video/quicktime",				Mime.Mov },
			{ "video/mp4",						Mime.Mp4 },
			{ "video/MP2T",						Mime.Ts },
			{ "video/ogg",						Mime.Ogg },
			{ "video/webm",						Mime.WebM },
			{ "video/x-ms-wmv",					Mime.Wmv },
		};

		internal static readonly Dictionary<string, Mime> FormatToMimeMap = new Dictionary<string, Mime> {
			
			// Applications				   TYPE			NAME
			{ "atom",	Mime.Atom },	// Document		Atom
			{ "blob",	Mime.Blob },	// Data			Binary Blob
			{ "doc",	Mime.Doc },		// Document		Word
			{ "eot",	Mime.Eot },		// Font			EOT
			{ "js",		Mime.Js },		// Script		JavaScript
			{ "json",	Mime.Json },	// Data			JSON
			{ "swf",	Mime.Swf },		// Plugin		Flash
			{ "ttf",	Mime.Ttf },		// Font			TTF
			{ "pdf",	Mime.Pdf },		// Document		PDF
			{ "xap",	Mime.Xap },		// Plugin		Silverlight
			{ "woff",	Mime.Woff },	// Font			WOFF
			{ "zip",	Mime.Zip },		// Package		ZIP			

			// Audio
			{ "aac",	Mime.Aac },
			{ "mp3",	Mime.Mp3 },
			{ "opus",	Mime.Opus },
			{ "ra",		Mime.Ra },
			{ "wav",	Mime.Wav },
			{ "wma",	Mime.Wma },

			// Images 
			{ "bmp",	Mime.Bmp },
			{ "gif",	Mime.Gif },
			{ "hdp",	Mime.Jxr },
			{ "ico",	Mime.Ico },
			{ "jpg",	Mime.Jpeg },
			{ "jpeg",	Mime.Jpeg },
			{ "jxr",	Mime.Jxr },		// Jpeg XR
			{ "png",	Mime.Png },
			{ "svg",	Mime.Svg },
			{ "tif",	Mime.Tiff },
			{ "tiff",	Mime.Tiff },
			{ "wdp",	Mime.Jxr },
			{ "webp",	Mime.WebP },

			// Text
			{ "css",	Mime.Css },
			{ "csv",	Mime.Csv },
			{ "htm",	Mime.Html },
			{ "html",	Mime.Html },
			{ "txt",	Mime.Txt },
			{ "xml",	Mime.Xml },

			// Videos
			{ "avi",	Mime.Avi },
			{ "f4v",	Mime.F4v },
			{ "flv",	Mime.Flv },
			{ "m4v",	Mime.Mp4 },
			{ "mpg",	Mime.Mpeg },
			{ "mpeg",	Mime.Mpeg },
			{ "mov",	Mime.Mov },
			{ "mp4",	Mime.Mp4 },
			{ "ts",		Mime.Ts },
			{ "qt",		Mime.Mov },
			{ "webm",	Mime.WebM },
			{ "wmv",	Mime.Wmv }
		};
	}
}