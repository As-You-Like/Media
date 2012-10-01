namespace Carbon.Media
{
	using System;

	public struct Mime
	{
		private readonly string name;
		private readonly string[] formats;
		private readonly MediaType type;

		public Mime(string name, string format = null)
			: this(name, (format != null) ? new[] { format } : null) { }

		public Mime(string name, string[] formats)
		{
			#region Preconditions

			if (name == null)
				throw new ArgumentNullException("name");

			#endregion

			this.name = name;
			this.formats = formats;

			this.type = name.Split('/')[0].ToEnum<MediaType>(ignoreCase: true);
		}

		public string Name
		{
			get { return name; }
		}

		public MediaType Type
		{
			get { return type; }
		}

		public string[] Formats
		{
			get { return formats; }
		}

		public override string ToString()
		{
			return name;
		}

		#region Equality

		public override int GetHashCode()
		{
			return name.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			if (obj == null) return false;

			return this.name == ((Mime)obj).name;
		}

		#endregion

		#region Casts

		public static implicit operator string(Mime mime)
		{
			return mime.Name;
		}

		#endregion

		#region Static Constructors

		public static Mime FromExtension(string extension)
		{
			#region Preconditions

			if (extension == null)
				throw new ArgumentNullException("extension");

			#endregion

			return FromFormat(extension.TrimStart('.'));
		}

		public static Mime FromFormat(string format)
		{
			#region Preconditions

			if (format == null)
				throw new ArgumentNullException("format");

			#endregion

			Mime mime;

			if (MimeHelper.FormatToMimeMap.TryGetValue(format.ToLower(), out mime))
			{
				return mime;
			}

			return new Mime("application/octet-stream", "");
		}

		#endregion

		// Applications
		public static readonly Mime Atom = new Mime("application/atom+xml", "atom");
		public static readonly Mime Doc = new Mime("application/msword", "doc");
		public static readonly Mime Json = new Mime("application/json", "json");			// http://tools.ietf.org/html/rfc4627
		public static readonly Mime M3u8 = new Mime("application/x-mpegURL", "m3u8");
		public static readonly Mime Pdf = new Mime("application/pdf", "pdf");
		public static readonly Mime Swf = new Mime("application/x-shockwave-flash", "swf");
		public static readonly Mime Xap = new Mime("application/x-silverlight-app", "xap");
		public static readonly Mime Zip = new Mime("application/zip", "zip");

		// Applications - Fonts
		public static readonly Mime Eot = new Mime("application/vnd.ms-fontobject", "eot");
		public static readonly Mime Ttf = new Mime("application/x-font-ttf", "ttf");
		public static readonly Mime Woff = new Mime("application/x-font-woff", "woff");

		// Applications - Scripts
		public static readonly Mime Js = new Mime("application/javascript", "js");
		public static readonly Mime Py = new Mime("application/x-python", "py");

		// Audio
		public static readonly Mime Aac = new Mime("audio/mp4", "aac");
		public static readonly Mime Mp3 = new Mime("audio/mpeg", "mp3");
		public static readonly Mime Opus = new Mime("audio/opus", "opus");
		public static readonly Mime Ra = new Mime("audio/x-realaudio", "ra");
		public static readonly Mime Wav = new Mime("audio/wav", "wav");
		public static readonly Mime Wma = new Mime("audio/x-ms-wma", "wma");

		// Image
		public static readonly Mime Bmp = new Mime("image/bmp", "bmp");
		public static readonly Mime Gif = new Mime("image/gif", "gif");
		public static readonly Mime Ico = new Mime("image/x-icon", "ico");	// [0]
		public static readonly Mime Jpeg = new Mime("image/jpeg", "jpeg");
		public static readonly Mime Jxr = new Mime("image/vnd.ms-photo", "jxr");
		public static readonly Mime Png = new Mime("image/png", "png");
		public static readonly Mime Svg = new Mime("image/svg+xml", "svg");
		public static readonly Mime Tiff = new Mime("image/tiff", "tiff");
		public static readonly Mime WebP = new Mime("image/webp", "webp");

		// Video
		public static readonly Mime Avi = new Mime("video/x-msvideo", "avi");
		public static readonly Mime F4v = new Mime("video/mp4", "mp4");
		public static readonly Mime Flv = new Mime("video/x-flv", "flv");
		public static readonly Mime Mov = new Mime("video/quicktime", "mov");
		public static readonly Mime Mp4 = new Mime("video/mp4", "mp4");
		public static readonly Mime Mpeg = new Mime("video/mpeg", "mpeg");
		public static readonly Mime Ogg = new Mime("video/ogg", "ogg");			// http://tools.ietf.org/html/rfc5334
		public static readonly Mime Ts = new Mime("video/MP2T", "ts");
		public static readonly Mime WebM = new Mime("video/webm", "webm");
		public static readonly Mime Wmv = new Mime("video/x-ms-wmv", "wmv");

		// Text
		public static readonly Mime Css = new Mime("text/css", "css");
		public static readonly Mime Csv = new Mime("text/csv", "csv");
		public static readonly Mime Html = new Mime("text/html", "html");
		public static readonly Mime Txt = new Mime("text/plain", "plain");
		public static readonly Mime Xml = new Mime("text/xml", "xml");
	}
}


// NOTES -----------------------------------------------------------------------------------------------------------------------
// [0]:	Internet Explorer 8 does not accept the official mime type "image/vnd.microsoft.icon". Must be "Content-Type: image/x-icon".

// http://en.wikipedia.org/wiki/Internet_media_type
// A media type is composed of two or more parts: A type, a subtype, and zero or more optional parameters. For example, subtypes of text have an optional charset parameter that can be included to indicate the character encoding e.g. text/html; charset=UTF-8), and subtypes of multipart type often define a boundary between parts. Allowed charset values are defined in the list of IANA character sets.