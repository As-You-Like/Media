namespace Carbon.Media.Tests
{
	using System;
	using System.Linq;

	using Carbon.Helpers;

	using NUnit.Framework;

	[TestFixture]
	public class MediaTypeTests
	{
		[Test]
		public void IntMappingTests()
		{
			Assert.AreEqual(1, (int)MediaType.Application);
			Assert.AreEqual(2, (int)MediaType.Audio);
			Assert.AreEqual(4, (int)MediaType.Image);
			Assert.AreEqual(8, (int)MediaType.Text);
			Assert.AreEqual(9, (int)MediaType.Video);
		}

		[Test]
		public void ApplicationTypeTests()
		{
			var formats = new[] { "js", "json", "swf", "xap", "zip" };

			Assert.IsTrue(formats.All(format => Mime.FromFormat(format).Type == MediaType.Application));
		}

		[Test]
		public void TextTypeTests()
		{
			// Text
			var formats = new[] { "css", "csv", "txt", "xml" };

			Assert.IsTrue(formats.All(format => Mime.FromFormat(format).Type == MediaType.Text));
		}

		[Test]
		public void AudioTypeTests()
		{
			var formats = new[] { "aac", "mp3", "ra", "wav", "wma" };

			Assert.IsTrue(formats.All(format => Mime.FromFormat(format).Type == MediaType.Audio));
		}

		[Test]
		public void ImageTypeTests()
		{
			var formats = new[] { "bmp", "gif", "ico", "jpg", "jpeg", "jxr", "png", "tif", "tiff" };

			Assert.IsTrue(formats.All(format => Mime.FromFormat(format).Type == MediaType.Image));
		}

		[Test]
		public void VideoTypeTests()
		{
			Assert.AreEqual(MediaType.Video, Mime.FromPath("DemoReel_01.10.13-HD for Apple Devices.m4v").Type);
			Assert.AreEqual("mp4", Mime.FromPath("DemoReel_01.10.13-HD for Apple Devices.m4v").Format);

			var formats = new[] { "avi", "f4v", "flv", "m4v", "mp4", "mpg", "mpeg", "qt", "webm", "wmv" };

			Assert.IsTrue(formats.All(format => Mime.FromFormat(format).Type == MediaType.Video));
		}
	}
}