using Xunit;

namespace Carbon.Media.Tests
{
    public class ImageFormatTests
    {
        [Theory]
        [InlineData(ImageFormat.Bmp,  4101)]
        [InlineData(ImageFormat.Bpg,  4105)]
        [InlineData(ImageFormat.Dng,  4208)]
        [InlineData(ImageFormat.Gif,  4219)]
        [InlineData(ImageFormat.Heif, 4230)]
        [InlineData(ImageFormat.Ico,  4245)]
        public void ImageCodecTypes(ImageFormat type, int id)
        {
            Assert.Equal((int)type, id);
        }
    }
}