using Xunit;

namespace Carbon.Media.Tests
{
    public class ImageFormatTests
    {
        [Theory]
        [InlineData(ImageFormat.Bmp,  CodecId.Bmp)]
        [InlineData(ImageFormat.Bpg,  CodecId.Bpg)]
        [InlineData(ImageFormat.Dng,  CodecId.Dng)]
        [InlineData(ImageFormat.Gif,  CodecId.Gif)]
        [InlineData(ImageFormat.Heif, CodecId.Heif)]
        [InlineData(ImageFormat.Ico,  CodecId.Ico)]
        public void ImageCodecTypes(ImageFormat a, CodecId b)
        {
            Assert.Equal((int)a, (int)b);
        }
    }
}