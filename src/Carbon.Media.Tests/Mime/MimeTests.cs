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
			Assert.AreEqual("png",	Mime.FromName("image/png").Format);
			Assert.AreEqual("tiff",	Mime.FromName("image/tiff").Format);
			Assert.AreEqual("gif",	Mime.FromName("image/gif").Format);
			Assert.AreEqual("jpeg",	Mime.FromName("image/jpeg").Format);
			Assert.AreEqual("jxr",	Mime.FromName("image/vnd.ms-photo").Format);
			Assert.AreEqual("svg",	Mime.FromName("image/svg+xml").Format);

			// Videos
			Assert.AreEqual("wmv",	Mime.FromName("video/x-ms-wmv").Format);
			Assert.AreEqual("mp4",	Mime.FromName("video/mp4").Format);
			Assert.AreEqual("mov",	Mime.FromName("video/quicktime").Format);
			
			Assert.AreEqual("zip",	Mime.FromName("application/zip").Format);
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
			Assert.AreEqual("audio/mpeg", Mime.FromFormat("mp3").ToString());
			Assert.AreEqual("audio/x-ms-wma", Mime.FromFormat("wma").ToString());

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