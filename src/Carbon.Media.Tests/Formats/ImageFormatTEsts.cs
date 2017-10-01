using Xunit;

namespace Carbon.Media.Tests
{
    public class ImageFormatTests
    {
        [Theory]
        [InlineData(ImageFormat.Bmp,  4001)]
        [InlineData(ImageFormat.Bpg,  4002)]
        [InlineData(ImageFormat.Dng,  4008)]
        [InlineData(ImageFormat.Gif,  4010)]
        [InlineData(ImageFormat.Heif, 4020)]
        [InlineData(ImageFormat.Ico,  4025)]
        public void ImageCodecTypes(ImageFormat type, int id)
        {
            Assert.Equal((int)type, id);
        }
    }
}