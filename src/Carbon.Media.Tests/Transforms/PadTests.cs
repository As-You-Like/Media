using Xunit;

namespace Carbon.Media.Tests
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
        public void Shorthand()
        {
            var pad = Pad.Parse("pad(1)");
            
            Assert.Equal(1, pad.Top);
            Assert.Equal(1, pad.Right);
            Assert.Equal(1, pad.Bottom);
            Assert.Equal(1, pad.Left);

            Assert.Equal("pad(1)", pad.Canonicalize());
        }
    }
}