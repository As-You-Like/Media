using Xunit;

namespace Carbon.Media.Tests
{
    public class MediaTypeTests
    {
        [Fact]
        public void IntMappingTests()
        {
            Assert.Equal(1,  (int)MediaType.Application);
            Assert.Equal(2,  (int)MediaType.Audio);
            Assert.Equal(3,  (int)MediaType.Example);
            Assert.Equal(4,  (int)MediaType.Image);
            Assert.Equal(6,  (int)MediaType.Model);
            Assert.Equal(8,  (int)MediaType.Text);
            Assert.Equal(9,  (int)MediaType.Video);
            Assert.Equal(10, (int)MediaType.Font);
        }

        [Fact]
        public void ApplicationTypeTests()
        {
            var formats = new[] { "js", "json", "swf", "xap", "zip" };

            foreach (var format in formats)
            {
                var mime = Mime.FromFormat(format);

                Assert.Equal(MediaType.Application, mime.Type);
                Assert.Equal(mime, Mime.Parse(mime.Name));

            }
        }

        [Fact]
        public void TextTypeTests()
        {
            // Text
            var formats = new[] { "css", "csv", "txt", "xml" };

            foreach (var format in formats)
            {
                var mime = Mime.FromFormat(format);

                Assert.Equal(MediaType.Text, mime.Type);
                Assert.Equal(mime, Mime.Parse(mime.Name));
            }
        }


        [Fact]
        public void ModelTests()
        {
            // var mime = new Mime("model/x3d+xml");
        }


        [Fact]
        public void AudioTypeTests()
        {
            var formats = new[] { "aiff", "aif", "aac", "mp3", "m4a", "opus", "ra", "wav", "wma" };

            foreach (var format in formats)
            {
                var mime = Mime.FromFormat(format);

                Assert.Equal(MediaType.Audio, mime.Type);
                Assert.Equal(mime, Mime.Parse(mime.Name));
            }
        }

        [Fact]
        public void ImageTypeTests()
        {
            var formats = new[] {
                "bmp", "gif", "heif", "ico", "jpg", "jpeg", "jxr", "png", "tif", "tiff", "webp"
            };

            foreach (var format in formats)
            {
                var mime = Mime.FromFormat(format);

                Assert.Equal(MediaType.Image, mime.Type);
                Assert.Equal(mime, Mime.Parse(mime.Name));

            }
        }

        [Fact]
        public void VideoTypeTests()
        {
            var formats = new[] { "avi", "f4v", "flv", "m4s", "m4v", "mp4", "mpg", "mpeg", "qt", "webm", "wmv" };

            foreach (var format in formats)
            {
                var mime = Mime.FromFormat(format);

                Assert.Equal(MediaType.Video, mime.Type);
                Assert.Equal(mime, Mime.Parse(mime.Name));

            }
        }

        [Fact]
        public void FontTypeTests()
        {
            var formats = new[] {
                "otf", "ttf", "woff", "woff2"
            };

            foreach (var format in formats)
            {
                var mime = Mime.FromFormat(format);

                Assert.Equal(format, mime.Format);
                Assert.Equal(MediaType.Font, mime.Type);
                Assert.Equal(mime, Mime.Parse(mime.Name));
            }
        }
    }
}