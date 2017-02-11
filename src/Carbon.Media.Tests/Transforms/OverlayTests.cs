using Xunit;

namespace Carbon.Media.Processors.Tests
{
    public class OverlayTests
	{
        [Fact]
        public void FromFullKey()
        {
            var overlay = DrawColor.Parse("color(red,mode:burn,x:1,y:2,width:100,height:300,align:middle,padding:10px)");

            Assert.Equal("red", overlay.Color);
            Assert.Equal(BlendMode.Burn, overlay.BlendMode);
            Assert.Equal(1d, overlay.Box.X.Value);
            Assert.Equal(2d, overlay.Box.Y.Value);
            Assert.Equal(100d, overlay.Box.Width.Value);
            Assert.Equal(300d, overlay.Box.Height.Value);
            Assert.Equal(Alignment.Middle, overlay.Align);
            Assert.Equal("10", overlay.Box.Padding.ToString());
        }
	}
}