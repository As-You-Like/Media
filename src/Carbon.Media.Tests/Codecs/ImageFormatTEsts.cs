using Xunit;

namespace Carbon.Media.Tests
{
    public class ImageFormatTests
    {
        [Theory]
        [InlineData(ImageFormat.Bmp,  MediaCodecType.Bmp)]
        [InlineData(ImageFormat.Bpg,  MediaCodecType.Bpg)]
        [InlineData(ImageFormat.Dng,  MediaCodecType.Dng)]
        [InlineData(ImageFormat.Gif,  MediaCodecType.Gif)]
        [InlineData(ImageFormat.Heif, MediaCodecType.Heif)]
        [InlineData(ImageFormat.Ico,  MediaCodecType.Ico)]
        public void ImageCodecTypes(ImageFormat a, MediaCodecType b)
        {
            Assert.Equal((int)a, (int)b);
        }
    }
}