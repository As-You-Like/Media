namespace Carbon.Media.Tests
{
    using Xunit;

    public class MimeTests
	{
        [Fact]
        public void MimesToFormatId()
        {
            // Audio
            Assert.Equal(FormatId.Aac,  Mime.Parse("audio/aac").ToFormatId());
            Assert.Equal(FormatId.Flac, Mime.Parse("audio/flac").ToFormatId());
            Assert.Equal(FormatId.Mp3,  Mime.Parse("audio/mpeg").ToFormatId());
            Assert.Equal(FormatId.Ogg,  Mime.Parse("audio/ogg").ToFormatId());
            Assert.Equal(FormatId.Opus, Mime.Parse("audio/opus").ToFormatId());

            // Images             
            Assert.Equal(FormatId.Png,  Mime.Parse("image/png").ToFormatId());
            Assert.Equal(FormatId.Tiff, Mime.Parse("image/tiff").ToFormatId());
            Assert.Equal(FormatId.Gif,  Mime.Parse("image/gif").ToFormatId());
            Assert.Equal(FormatId.Heif, Mime.Parse("image/heif").ToFormatId());
            Assert.Equal(FormatId.Jpeg, Mime.Parse("image/jpeg").ToFormatId());
            Assert.Equal(FormatId.Jxr,  Mime.Parse("image/vnd.ms-photo").ToFormatId());
            Assert.Equal(FormatId.Png,  Mime.Parse("image/png").ToFormatId());
            Assert.Equal(FormatId.Svg,  Mime.Parse("image/svg+xml").ToFormatId());
            Assert.Equal(FormatId.WebP, Mime.Parse("image/webp").ToFormatId());
        }

        [Fact]
		public void MimesFromNames()
		{
            // Audio
            Assert.Equal("aac",   Mime.Parse("audio/aac").Format);
            Assert.Equal("flac",  Mime.Parse("audio/flac").Format);
            Assert.Equal("mp3",   Mime.Parse("audio/mpeg").Format);
            Assert.Equal("oga",	  Mime.Parse("audio/ogg").Format);
			Assert.Equal("opus",  Mime.Parse("audio/opus").Format);
                                  
            // Images             
			Assert.Equal("png",	  Mime.Parse("image/png").Format);
			Assert.Equal("tiff",  Mime.Parse("image/tiff").Format);
			Assert.Equal("gif",	  Mime.Parse("image/gif").Format);
            Assert.Equal("heif",  Mime.Parse("image/heif").Format);
            Assert.Equal("jpeg",  Mime.Parse("image/jpeg").Format);
			Assert.Equal("jxr",	  Mime.Parse("image/vnd.ms-photo").Format);
            Assert.Equal("png",	  Mime.Parse("image/png").Format);
            Assert.Equal("svg",	  Mime.Parse("image/svg+xml").Format);
			Assert.Equal("webp",  Mime.Parse("image/webp").Format);
                                  
			// Videos             
			Assert.Equal("wmv",	  Mime.Parse("video/x-ms-wmv").Format);
			Assert.Equal("mp4",	  Mime.Parse("video/mp4").Format);
			Assert.Equal("mov",	  Mime.Parse("video/quicktime").Format);
			Assert.Equal("ogv",	  Mime.Parse("video/ogg").Format);
                                  
			// Application        
			Assert.Equal("js",	  Mime.Parse("application/javascript").Format);
			Assert.Equal("json",  Mime.Parse("application/json").Format);
			Assert.Equal("zip",	  Mime.Parse("application/zip").Format);
                                  
			// Text               
			Assert.Equal("css",	  Mime.Parse("text/css").Format);

            // Fonts
            Assert.Equal("ttf",   Mime.Parse("font/ttf").Format);
            Assert.Equal("woff",  Mime.Parse("font/woff").Format);
            Assert.Equal("woff2", Mime.Parse("font/woff2").Format);
        }

        [Fact]
        public void FontTests()
        {
            Assert.Equal("font/woff",  Mime.FromFormat("woff").Name);
            Assert.Equal("font/woff2", Mime.FromFormat("woff2").Name);
        }

        [Fact]
		public void MimeEqualityTests()
		{
			Assert.Equal(Mime.Zip, Mime.Zip);
		}

		[Fact]
		public void MimeFromFileFormatTests()
		{
			// Applications
			Assert.Equal("application/javascript",		  Mime.FromFormat("js"));
			Assert.Equal("application/x-shockwave-flash", Mime.FromFormat("swf"));
			Assert.Equal("application/zip",				  Mime.FromFormat("zip"));


			// Audio
			Assert.Equal("audio/flac",     Mime.FromFormat("flac"));
			Assert.Equal("audio/mpeg",     Mime.FromFormat("mp3"));
			Assert.Equal("audio/x-ms-wma", Mime.FromFormat("wma"));
			Assert.Equal("audio/ogg",      Mime.FromFormat("oga"));
			Assert.Equal("audio/opus",     Mime.FromFormat("opus"));

			// Documents
			Assert.Equal("application/pdf", Mime.FromFormat("pdf"));
			Assert.Equal("application/msword", Mime.FromFormat("doc"));

			// Images
			Assert.Equal("image/bmp",     Mime.FromFormat("bmp"));
			Assert.Equal("image/x-icon",  Mime.FromFormat("ico"));
			Assert.Equal("image/jpeg",    Mime.FromFormat("jpg"));
			Assert.Equal("image/jpeg",    Mime.FromFormat("jpeg"));
			Assert.Equal("image/png",     Mime.FromFormat("png"));
            Assert.Equal("image/svg+xml", Mime.FromFormat("svg"));
			Assert.Equal("image/tiff",    Mime.FromFormat("tif"));
			Assert.Equal("image/tiff",    Mime.FromFormat("tiff"));
            Assert.Equal("image/webp",    Mime.FromFormat("webp"));

			// Scripts
			Assert.Equal("application/javascript", Mime.FromFormat("js"));

			// Text
			Assert.Equal("text/html", Mime.FromFormat("htm"));
			Assert.Equal("text/html", Mime.FromFormat("html"));
			Assert.Equal("text/plain", Mime.FromFormat("txt"));

			// Videos
			Assert.Equal("video/x-msvideo", Mime.FromFormat("avi"));
			Assert.Equal("video/mp4", Mime.FromFormat("f4v"));
			Assert.Equal("video/mp4", Mime.FromFormat("m4v"));
			Assert.Equal("video/quicktime", Mime.FromFormat("mov"));
			Assert.Equal("video/mp4", Mime.FromFormat("mp4"));
			Assert.Equal("video/mpeg", Mime.FromFormat("mpeg"));
			Assert.Equal("video/ogg", Mime.FromFormat("ogg"));
			Assert.Equal("video/quicktime", Mime.FromFormat("qt"));
			Assert.Equal("video/webm", Mime.FromFormat("webm"));

			// Make sure we don't care about a leading dot or casing
			Assert.Equal("image/jpeg",  Mime.FromExtension(".JpG"));
			Assert.Equal("image/png",   Mime.FromExtension(".pNG"));
			Assert.Equal("audio/mpeg",  Mime.FromExtension(".mP3"));

			Assert.Equal("application/octet-stream", Mime.FromExtension("blob"));

			// Unknowns
			// Assert.Equal("application/octet-stream", Mime.FromFormat(".FID").ToString());
			// Assert.Equal("application/octet-stream", Mime.FromFormat(".pie").ToString());
		}

		[Fact]
		public void StaticMimeMappingTests()
		{
			// Applications
			Assert.Equal("application/json",				Mime.Json);
			Assert.Equal("application/javascript",			Mime.Js);
			Assert.Equal("application/x-shockwave-flash",	Mime.Swf);

			// Text
			Assert.Equal("text/css",						Mime.Css);

		}
	}
}