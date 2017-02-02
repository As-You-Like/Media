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
    }
}