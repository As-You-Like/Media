using Xunit;

namespace Carbon.Media.Processing.Tests
{
    public class BitrateFilterTests
	{
        [Fact]
        public void Parse()
        {
            var bitrate = Processor.Parse("bitrate(96000)") as BitRateFilter;

            Assert.Equal("bitrate(96000)", bitrate.ToString());
        }

        [Fact]
        public void ParseKbs()
        {
            var bitrate = Processor.Parse("bitrate(96kbs)") as BitRateFilter;

            Assert.Equal("bitrate(96000)", bitrate.ToString());
        }

        [Fact]
        public void ParseMbs()
        {
            var bitrate = Processor.Parse("bitrate(1mbs)") as BitRateFilter;

            Assert.Equal("bitrate(1000000)", bitrate.ToString());
        }
    }
}