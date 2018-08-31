using Xunit;

namespace Carbon.Media.Tests
{
    public class BitRateTests
    {
        [Fact]
        public void A()
        {
            Assert.Equal(1,   BitRate.Parse("1mbs").Mbps);
            Assert.Equal(128, BitRate.Parse("128kbs").Kbps);

            Assert.Equal(0.5,   BitRate.Parse("0.5 mbs").Mbps);
            Assert.Equal(1,     BitRate.Parse("1 mbs").Mbps);
            Assert.Equal(128,   BitRate.Parse("128 kbs").Kbps);

            Assert.Equal(621, BitRate.Parse("0.621 mbs").Kbps);
        }

        [Fact]
        public void ParseTests()
        {
            Assert.Equal(1,    BitRate.Parse("1").Value);
            Assert.Equal(1,    BitRate.Parse("1000").Kbps);
            Assert.Equal(1,    BitRate.Parse("1000000").Mbps);
            Assert.Equal(128,  BitRate.Parse("128000").Kbps);


            Assert.Equal(128,  BitRate.Parse("128Kb/s").Kbps); // Kb/s
            Assert.Equal(1,    BitRate.Parse("1Mb/s").Mbps);   // Mb/s

            Assert.Equal(128,  BitRate.Parse("128 Kb/s").Kbps); // Kb/s
            Assert.Equal(1,    BitRate.Parse("1 Mb/s").Mbps);     // Mb/s

            Assert.Equal(1.5,  BitRate.FromMbps(1.5).Mbps);
            Assert.Equal(1500, BitRate.FromKbps(1.5d).Value);
        }

        [Fact]
        public void ToStringTests()
        {
            Assert.Equal("1000",    BitRate.FromKbps(1).ToString());   // 1kbs
            Assert.Equal("128000",  BitRate.FromKbps(128).ToString()); // 196kbs
            Assert.Equal("196000",  BitRate.FromKbps(196).ToString()); // 196kbs
            Assert.Equal("1000000", BitRate.FromMbps(1).ToString());
        }
    }
}
