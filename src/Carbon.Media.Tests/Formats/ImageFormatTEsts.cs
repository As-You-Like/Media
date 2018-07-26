using Xunit;

namespace Carbon.Media.Tests
{
    public class ImageFormatTests
    {
        [Theory]
        [InlineData(ImageFormat.Apng, 4040)]
        [InlineData(ImageFormat.Bmp,  4101)]
        [InlineData(ImageFormat.Bpg,  4105)]
        [InlineData(ImageFormat.Dng,  4170)]
        [InlineData(ImageFormat.Gif,  4220)]
        [InlineData(ImageFormat.Heif, 4230)]
        [InlineData(ImageFormat.Ico,  4301)]
        [InlineData(ImageFormat.Jp2,  4310)]
        [InlineData(ImageFormat.Jpeg, 4320)]
        public void ImageCodecTypes(ImageFormat type, int id)
        {
            Assert.Equal((int)type, id);
        }
    }
}