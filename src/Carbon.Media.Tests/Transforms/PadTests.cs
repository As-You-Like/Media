using Xunit;

namespace Carbon.Media.Processors.Tests
{
    public class PadTests
	{
        [Fact]
        public void A()
        {
            var pad = Pad.Parse("pad(1,2,3,4)");

            Assert.Equal(1, pad.Top);
            Assert.Equal(2, pad.Right);
            Assert.Equal(3, pad.Bottom);
            Assert.Equal(4, pad.Left);

            Assert.Equal("pad(1,2,3,4)", pad.Canonicalize());
        }

        [Fact]
        public void Shorthand1()
        {
            var pad = Pad.Parse("pad(1)");
            
            Assert.Equal(1, pad.Top);
            Assert.Equal(1, pad.Right);
            Assert.Equal(1, pad.Bottom);
            Assert.Equal(1, pad.Left);

            Assert.Equal("pad(1)", pad.Canonicalize());
        }

        [Fact]
        public void Shorthand2()
        {
            var pad = Pad.Parse("pad(10,20)");

            Assert.Equal(10, pad.Top);
            Assert.Equal(20, pad.Right);
            Assert.Equal(10, pad.Bottom);
            Assert.Equal(20, pad.Left);

            Assert.Equal("pad(10,20)", pad.Canonicalize());
        }
    }
}