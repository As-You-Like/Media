using System.Linq;

using Xunit;

namespace Carbon.Media.Tests
{	
	public class MediaTypeTests
	{
		[Fact]
		public void IntMappingTests()
		{
			Assert.Equal(1, (int)MediaType.Application);
			Assert.Equal(2, (int)MediaType.Audio);
			Assert.Equal(4, (int)MediaType.Image);
			Assert.Equal(8, (int)MediaType.Text);
			Assert.Equal(9, (int)MediaType.Video);

            // Non-Standard
            Assert.Equal(100, (int)MediaType.Subtitle);
        }

        [Fact]
		public void ApplicationTypeTests()
		{
			var formats = new[] { "js", "json", "swf", "xap", "zip" };

			Assert.True(formats.All(format => Mime.FromFormat(format).Type == MediaType.Application));
		}

		[Fact]
		public void TextTypeTests()
		{
			// Text
			var formats = new[] { "css", "csv", "txt", "xml" };

			Assert.True(formats.All(format => Mime.FromFormat(format).Type == MediaType.Text));
		}

		[Fact]
		public void AudioTypeTests()
		{
			var formats = new[] { "aiff", "aif", "aac", "mp3", "m4a", "opus", "ra", "wav", "wma" };

			Assert.True(formats.All(format => Mime.FromFormat(format).Type == MediaType.Audio));
		}

		[Fact]
		public void ImageTypeTests()
		{
			var formats = new[] {
                "bmp", "gif", "heif", "ico", "jpg", "jpeg", "jxr", "png", "tif", "tiff", "webp"
            };

			Assert.True(formats.All(format => Mime.FromFormat(format).Type == MediaType.Image));
		}

		[Fact]
		public void VideoTypeTests()
		{
			Assert.Equal(MediaType.Video, Mime.FromPath("DemoReel_01.10.13-HD for Apple Devices.m4v").Type);
			Assert.Equal("mp4", Mime.FromPath("DemoReel_01.10.13-HD for Apple Devices.m4v").Format);

			var formats = new[] { "avi", "f4v", "flv", "m4v", "mp4", "mpg", "mpeg", "qt", "webm", "wmv" };

			Assert.True(formats.All(format => Mime.FromFormat(format).Type == MediaType.Video));
		}
	}
}