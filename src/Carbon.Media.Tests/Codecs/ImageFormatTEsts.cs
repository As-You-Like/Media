using Xunit;

namespace Carbon.Media.Tests
{
    public class ImageFormatTests
    {
        [Theory]
        [InlineData(ImageFormat.Bmp,  401)]
        [InlineData(ImageFormat.Bpg,  402)]
        [InlineData(ImageFormat.Dng,  408)]
        [InlineData(ImageFormat.Gif,  410)]
        [InlineData(ImageFormat.Heif, 420)]
        [InlineData(ImageFormat.Ico,  425)]
        public void ImageCodecTypes(ImageFormat a, int b)
        {
            Assert.Equal((int)a, (int)b);
        }
    }
}