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
        public void FromPaths(string input, string normalized)
        {
            Assert.Equal(normalized, FileFormat.FromPath(input));
        }
    }
}