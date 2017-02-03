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
            Assert.Equal(1, overlay.X.Value.Value);
            Assert.Equal(2, overlay.Y.Value.Value);
            Assert.Equal(100, overlay.Width.Value.Value);
            Assert.Equal(Alignment.Middle, overlay.Align);
        }
	}
}