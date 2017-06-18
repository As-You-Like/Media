namespace Carbon.Media.Tests
{
	using Xunit;
	
	public class MimeTests
	{
		[Fact]
		public void MimesFromNames()
		{
			// Images
			Assert.Equal("png",		Mime.Parse("image/png").Format);
			Assert.Equal("tiff",	Mime.Parse("image/tiff").Format);
			Assert.Equal("gif",		Mime.Parse("image/gif").Format);
            Assert.Equal("heif",    Mime.Parse("image/heif").Format);

            Assert.Equal("jpeg",	Mime.Parse("image/jpeg").Format);
			Assert.Equal("jxr",		Mime.Parse("image/vnd.ms-photo").Format);
			Assert.Equal("svg",		Mime.Parse("image/svg+xml").Format);
            
			// Audio
			Assert.Equal("flac",	Mime.Parse("audio/flac").Format);
			Assert.Equal("oga",		Mime.Parse("audio/ogg").Format);
			Assert.Equal("opus",	Mime.Parse("audio/opus").Format);

			// Videos
			Assert.Equal("wmv",		Mime.Parse("video/x-ms-wmv").Format);
			Assert.Equal("mp4",		Mime.Parse("video/mp4").Format);
			Assert.Equal("mov",		Mime.Parse("video/quicktime").Format);
			Assert.Equal("ogv",		Mime.Parse("video/ogg").Format);

			// Application
			Assert.Equal("js",		Mime.Parse("application/javascript").Format);
			Assert.Equal("json",	Mime.Parse("application/json").Format);
			Assert.Equal("zip",		Mime.Parse("application/zip").Format);

			// Text
			Assert.Equal("css",		Mime.Parse("text/css").Format);
		}

        [Fact]
        public void FontTests()
        {

            Assert.Equal("application/font-woff",  Mime.FromFormat("woff").Name);
            Assert.Equal("application/font-woff2", Mime.FromFormat("woff2").Name);

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
			Assert.Equal("application/javascript",			Mime.FromFormat("js").ToString());
			Assert.Equal("application/x-shockwave-flash",	Mime.FromFormat("swf").ToString());
			Assert.Equal("application/zip",					Mime.FromFormat("zip").ToString());


			// Audio
			Assert.Equal("audio/flac", Mime.FromFormat("flac").ToString());
			Assert.Equal("audio/mpeg", Mime.FromFormat("mp3").ToString());
			Assert.Equal("audio/x-ms-wma", Mime.FromFormat("wma").ToString());
			Assert.Equal("audio/ogg", Mime.FromFormat("oga").ToString());
			Assert.Equal("audio/opus", Mime.FromFormat("opus").ToString());

			// Documents
			Assert.Equal("application/pdf", Mime.FromFormat("pdf").ToString());
			Assert.Equal("application/msword", Mime.FromFormat("doc").ToString());

			// Images
			Assert.Equal("image/bmp", Mime.FromFormat("bmp").ToString());
			Assert.Equal("image/x-icon", Mime.FromFormat("ico").ToString());
			Assert.Equal("image/jpeg", Mime.FromFormat("jpg").ToString());
			Assert.Equal("image/jpeg", Mime.FromFormat("jpeg").ToString());
			Assert.Equal("image/png", Mime.FromFormat("png").ToString());
			Assert.Equal("image/tiff", Mime.FromFormat("tif").ToString());
			Assert.Equal("image/tiff", Mime.FromFormat("tiff").ToString());

			// Scripts
			Assert.Equal("application/javascript", Mime.FromFormat("js").ToString());

			// Text
			Assert.Equal("text/html", Mime.FromFormat("htm").ToString());
			Assert.Equal("text/html", Mime.FromFormat("html").ToString());
			Assert.Equal("text/plain", Mime.FromFormat("txt").ToString());

			// Videos
			Assert.Equal("video/x-msvideo", Mime.FromFormat("avi").ToString());
			Assert.Equal("video/mp4", Mime.FromFormat("f4v").ToString());
			Assert.Equal("video/mp4", Mime.FromFormat("m4v").ToString());
			Assert.Equal("video/quicktime", Mime.FromFormat("mov").ToString());
			Assert.Equal("video/mp4", Mime.FromFormat("mp4").ToString());
			Assert.Equal("video/mpeg", Mime.FromFormat("mpeg").ToString());
			Assert.Equal("video/ogg", Mime.FromFormat("ogg").ToString());
			Assert.Equal("video/quicktime", Mime.FromFormat("qt").ToString());
			Assert.Equal("video/webm", Mime.FromFormat("webm").ToString());

			// Make sure we don't care about a leading dot or casing
			Assert.Equal("image/jpeg", Mime.FromExtension(".JpG").ToString());
			Assert.Equal("image/png", Mime.FromExtension(".pNG").ToString());
			Assert.Equal("audio/mpeg", Mime.FromExtension(".mP3").ToString());

			Assert.Equal("application/octet-stream", Mime.FromExtension("blob").ToString());

			// Unknowns
			// Assert.Equal("application/octet-stream", Mime.FromFormat(".FID").ToString());
			// Assert.Equal("application/octet-stream", Mime.FromFormat(".pie").ToString());
		}

		[Fact]
		public void StaticMimeMappingTests()
		{
			// Applications
			Assert.Equal("application/json",				Mime.Json.ToString());
			Assert.Equal("application/javascript",			Mime.Js.ToString());
			Assert.Equal("application/x-shockwave-flash",	Mime.Swf.ToString());

			// Text
			Assert.Equal("text/css",						Mime.Css.ToString());

		}
	}
}