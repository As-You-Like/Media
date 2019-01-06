using Xunit;

namespace Carbon.Media.Codecs.Tests
{
    public class ImageCodecTests
    {
        [Theory]
        [InlineData("apng", CodecId.Apng)]
        [InlineData("bmp",  CodecId.Bmp)]
        [InlineData("heif", CodecId.Heif)]
        [InlineData("ico",  CodecId.Ico)]
        [InlineData("jpeg", CodecId.Jpeg)]
        [InlineData("jp2",  CodecId.Jp2)]
        [InlineData("tiff", CodecId.Tiff)]
        [InlineData("webp", CodecId.WebP)]
        public void CanParse(string name, CodecId id)
        {
            Assert.Equal(id, CodecIdHelper.Parse(name));
        }
    }
}