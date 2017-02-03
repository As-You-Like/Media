using Xunit;

namespace Carbon.Media.Tests
{	
	public class OverlayTests
	{
        [Fact]
        public void FromFullKey()
        {
            var overlay = Overlay.Parse("overlay(red,mode:burn,x:1,y:2,width:100,align:middle)");

            Assert.Equal("red", overlay.Key);
            Assert.Equal(BlendMode.Burn, overlay.BlendMode);
            Assert.Equal(1d, overlay.X.Value);
            Assert.Equal(2d, overlay.Y.Value);
            Assert.Equal(100d, overlay.Width.Value);
            Assert.Equal(Alignment.Middle, overlay.Align);
        }
	}
}