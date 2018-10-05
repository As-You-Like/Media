using Xunit;

namespace Carbon.Media.Tests
{
    using static ChannelLayout;

    public class ChannelLayoutTests
    {        
        [Fact]
        public void DownmixTests()
        {
            Assert.Equal(536870912,  (long)DownmixLeft);
            Assert.Equal(1073741824, (long)DownmixRight);
        }
    }
}