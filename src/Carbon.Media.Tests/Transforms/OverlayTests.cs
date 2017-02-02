using Xunit;

namespace Carbon.Media.Tests
{	
	public class OverlayTests
	{
        [Fact]
        public void FromFullKey()
        {
            var overlay = Overlay.Parse("overlay(red,mode:burn)");

            Assert.Equal("red", overlay.Key);
            Assert.Equal(BlendMode.Burn, overlay.BlendMode);
        }
	}
}