using Xunit;

namespace Carbon.Media.Tests
{
	public class CropAnchorTests
	{
		[Fact]
		public void WithinTests()
		{
            Assert.Equal(CropAnchor.Top | CropAnchor.Left,  AnchorHelper.Parse("tl"));
            Assert.Equal(CropAnchor.Top | CropAnchor.Right, AnchorHelper.Parse("tr"));

            Assert.Equal(CropAnchor.Top,    AnchorHelper.Parse("t"));
            Assert.Equal(CropAnchor.Right,  AnchorHelper.Parse("r"));
            Assert.Equal(CropAnchor.Bottom, AnchorHelper.Parse("b"));
            Assert.Equal(CropAnchor.Left,   AnchorHelper.Parse("l"));

            Assert.Equal(CropAnchor.Center, AnchorHelper.Parse("c"));

            // Compass
            Assert.Equal(CropAnchor.Top,    AnchorHelper.Parse("n"));
            Assert.Equal(CropAnchor.Right,  AnchorHelper.Parse("e"));
            Assert.Equal(CropAnchor.Bottom, AnchorHelper.Parse("s"));
            Assert.Equal(CropAnchor.Left,   AnchorHelper.Parse("w"));
        }

    }
}