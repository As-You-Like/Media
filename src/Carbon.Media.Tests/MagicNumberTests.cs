
using Xunit;

namespace Carbon.Media.Tests
{
    public class MagicNumberTests
    {
        [Fact]
        public void MatchTest()
        {
            Assert.True(MagicNumber.Png.Matches(new byte[] { 0x89, 80, 78, 71 }));
            Assert.False(MagicNumber.Png.Matches(new byte[] { 0x89, 80, 78, 1 }));

        }
    }
}