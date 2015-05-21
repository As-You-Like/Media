namespace Carbon.Media.Tests
{
	using NUnit.Framework;

	using Carbon.Media;

	[TestFixture]
	public class MimeTests
	{
		[Test]
		public void MimesFromNames()
		{
			// Images
			Assert.AreEqual("png",	Mime.Parse("image/png").Format);
			Assert.AreEqual("tiff",	Mime.Parse("image/tiff").Format);
			Assert.AreEqual("gif",	Mime.Parse("image/gif").Format);
			Assert.AreEqual("jpeg",	Mime.Parse("image/jpeg").Format);
			Assert.AreEqual("jxr",	Mime.Parse("image/vnd.ms-photo").Format);
			Assert.AreEqual("svg",	Mime.Parse("image/svg+xml").Format);

			// Audio
			Assert.AreEqual("flac", Mime.Parse("audio/flac").Format);
			Assert.AreEqual("oga",  Mime.Parse("audio/ogg").Format);
			Assert.AreEqual("opus", Mime.Parse("audio/opus").Format);

			// Videos
			Assert.AreEqual("wmv",	Mime.Parse("video/x-ms-wmv").Format);
			Assert.AreEqual("mp4",	Mime.Parse("video/mp4").Format);
			Assert.AreEqual("mov",	Mime.Parse("video/quicktime").Format);
			Assert.AreEqual("ogv",  Mime.Parse("video/ogg").Format);

			Assert.AreEqual("zip",	Mime.Parse("application/zip").Format);
		}

		[Test]
		public void MimeEqualityTests()
		{
			Assert.AreEqual(Mime.Zip, Mime.Zip);
		}

		[Test]
		public void MimeFromFileFormatTests()
		{
			// Applications
			Assert.AreEqual("application/x-shockwave-flash", Mime.FromFormat("swf").ToString());
			Assert.AreEqual("application/zip", Mime.FromFormat("zip").ToString());

			// Audio
			Assert.AreEqual("audio/flac", Mime.FromFormat("flac").ToString());
			Assert.AreEqual("audio/mpeg", Mime.FromFormat("mp3").ToString());
			Assert.AreEqual("audio/x-ms-wma", Mime.FromFormat("wma").ToString());
			Assert.AreEqual("audio/ogg", Mime.FromFormat("oga").ToString());
			Assert.AreEqual("audio/opus", Mime.FromFormat("opus").ToString());

			// Documents
			Assert.AreEqual("application/pdf", Mime.FromFormat("pdf").ToString());
			Assert.AreEqual("application/msword", Mime.FromFormat("doc").ToString());

			// Images
			Assert.AreEqual("image/bmp", Mime.FromFormat("bmp").ToString());
			Assert.AreEqual("image/x-icon", Mime.FromFormat("ico").ToString());
			Assert.AreEqual("image/jpeg", Mime.FromFormat("jpg").ToString());
			Assert.AreEqual("image/jpeg", Mime.FromFormat("jpeg").ToString());
			Assert.AreEqual("image/png", Mime.FromFormat("png").ToString());
			Assert.AreEqual("image/tiff", Mime.FromFormat("tif").ToString());
			Assert.AreEqual("image/tiff", Mime.FromFormat("tiff").ToString());

			// Scripts
			Assert.AreEqual("application/javascript", Mime.FromFormat("js").ToString());

			// Text
			Assert.AreEqual("text/html", Mime.FromFormat("htm").ToString());
			Assert.AreEqual("text/html", Mime.FromFormat("html").ToString());
			Assert.AreEqual("text/plain", Mime.FromFormat("txt").ToString());

			// Videos
			Assert.AreEqual("video/x-msvideo", Mime.FromFormat("avi").ToString());
			Assert.AreEqual("video/mp4", Mime.FromFormat("f4v").ToString());
			Assert.AreEqual("video/mp4", Mime.FromFormat("m4v").ToString());
			Assert.AreEqual("video/quicktime", Mime.FromFormat("mov").ToString());
			Assert.AreEqual("video/mp4", Mime.FromFormat("mp4").ToString());
			Assert.AreEqual("video/mpeg", Mime.FromFormat("mpeg").ToString());
			Assert.AreEqual("video/ogg", Mime.FromFormat("ogg").ToString());
			Assert.AreEqual("video/quicktime", Mime.FromFormat("qt").ToString());
			Assert.AreEqual("video/webm", Mime.FromFormat("webm").ToString());

			// Make sure we don't care about a leading dot or casing
			Assert.AreEqual("image/jpeg", Mime.FromExtension(".JpG").ToString());
			Assert.AreEqual("image/png", Mime.FromExtension(".pNG").ToString());
			Assert.AreEqual("audio/mpeg", Mime.FromExtension(".mP3").ToString());

			Assert.AreEqual("application/octet-stream", Mime.FromExtension("blob").ToString());

			// Unknowns
			// Assert.AreEqual("application/octet-stream", Mime.FromFormat(".FID").ToString());
			// Assert.AreEqual("application/octet-stream", Mime.FromFormat(".pie").ToString());
		}

		[Test]
		public void StaticMimeMappingTests()
		{
			Assert.AreEqual("application/javascript", Mime.Js.ToString());
			Assert.AreEqual("application/x-shockwave-flash", Mime.Swf.ToString());
		}
	}
}