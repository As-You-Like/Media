using Xunit;

namespace Carbon.Media.Tests
{
    public class FileFormatTests
    {
        [Theory]
        [InlineData(".GIF", "gif")]
        [InlineData(".jpg", "jpeg")]
        [InlineData(".MpG", "mpeg")]
        public void Normalize(string input, string normalized)
        {
            Assert.Equal(normalized, FileFormat.Normalize(input));
        }

        [Theory]
        [InlineData("a/asfasdf.GIF", "gif")]
        [InlineData("234234(adasf.gif)/a/asfasdf.pNg", "png")]
        [InlineData("a\\a\\..asdf\\.fasdfpkf\\asdf\\asdfSdfdsaf.tiff", "tiff")]
        [InlineData("holiday_gift_center_1998.pdf", "pdf")]
        public void FromPaths(string input, string normalized)
        {
            Assert.Equal(normalized, FileFormat.FromPath(input));
        }
    }
}