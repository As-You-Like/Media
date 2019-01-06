
using Xunit;

namespace Carbon.Media.Codecs.Tests
{
    public class AacProfileTests
    {
        [Fact]
        public void AacProfiles()
        {
            Assert.Equal(AacProfile.LC, CodecInfo.Parse("mp4a.40.2"));
            Assert.Equal(AacProfile.HE, CodecInfo.Parse("mp4a.40.5"));

            Assert.Equal(AacProfile.LC, AacProfile.Parse("lc"));
            Assert.Equal(AacProfile.HE, AacProfile.Parse("he"));
        }
    }
}