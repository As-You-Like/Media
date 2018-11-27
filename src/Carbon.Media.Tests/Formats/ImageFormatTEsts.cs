using Xunit;

namespace Carbon.Media.Tests
{
    public class ImageFormatTests
    {
        [Theory]
        [InlineData(ImageFormat.Apng, "image/apng",         4040)]
        [InlineData(ImageFormat.Bmp,  "image/bmp",          4101)]
        [InlineData(ImageFormat.Bpg,  "image/bpg",          4105)]
        [InlineData(ImageFormat.Cr2,  "image/x-canon-cr2",  4127)] // fmt/592
        [InlineData(ImageFormat.Dng,  "image/dng",          4170)]
        [InlineData(ImageFormat.Gif,  "image/gif",          4220)]
        [InlineData(ImageFormat.Heif, "image/heif",         4230)]
        [InlineData(ImageFormat.Ico,  "image/x-icon",       4301)]
        [InlineData(ImageFormat.Jp2,  "image/jp2",          4310)]
        [InlineData(ImageFormat.Jpeg, "image/jpeg",         4320)]
        [InlineData(ImageFormat.Tiff, "image/tiff",         4775)]
        public void MimesAreCorrect(ImageFormat type, string mediaType, int id)
        {
            Assert.Equal((int)type, id);

            var mime = Mime.FromFormat((FormatId)type);

            Assert.Equal(mediaType, mime.Name);
        }
    }
}