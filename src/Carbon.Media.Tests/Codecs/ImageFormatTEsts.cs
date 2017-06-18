using Xunit;

namespace Carbon.Media.Tests
{
    public class ImageFormatTests
    {
        [Theory]
        [InlineData(ImageFormat.Bmp,  CodecType.Bmp)]
        [InlineData(ImageFormat.Bpg,  CodecType.Bpg)]
        [InlineData(ImageFormat.Dng,  CodecType.Dng)]
        [InlineData(ImageFormat.Gif,  CodecType.Gif)]
        [InlineData(ImageFormat.Heif, CodecType.Heif)]
        [InlineData(ImageFormat.Ico,  CodecType.Ico)]
        public void ImageCodecTypes(ImageFormat a, CodecType b)
        {
            Assert.Equal((int)a, (int)b);
        }
    }
}