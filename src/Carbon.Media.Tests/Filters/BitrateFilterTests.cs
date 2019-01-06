using System;
using Xunit;

namespace Carbon.Media.Processing.Filters.Tests
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
        public void ParseMax()
        {
            var bitrate = (BitRateFilter)Processor.Parse("bitrate(1mbs,max:1.1mbs)");

            Assert.Equal("bitrate(1000000,1100000)", bitrate.ToString());
        }

        [Fact]
        public void ParseMaxWithWindow()
        {
            var bitrate = (BitRateFilter)Processor.Parse("bitrate(1mbs,max:1.1mbs,buffer:2s)");

            Assert.Equal(2000000, bitrate.Buffer.Value.Value);
            Assert.Equal("bitrate(1000000,1100000,2000000)", bitrate.ToString());
        }

        [Fact]
        public void ParseMaxWithVal()
        {
            var bitrate = (BitRateFilter)Processor.Parse("bitrate(1mbs,max:1.1mbs,buffer:1000)");

            Assert.Equal("bitrate(1000000,1100000,1000)", bitrate.ToString());
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