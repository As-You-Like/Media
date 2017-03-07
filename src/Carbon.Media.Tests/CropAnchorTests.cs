using Xunit;

namespace Carbon.Media.Tests
{
    using static CropAnchor;

	public class CropAnchorTests
	{
        // origin: top left point...

        [Fact]
        public void AlignTests()
        {
            var box = new Rectangle(new Size(100, 100));
            var bounds = new Size(200, 200);

            ResizeHelper.Align(ref box, bounds, Top | Center);

            Assert.Equal(50d, box.X);
            Assert.Equal(0, box.Y);

            ResizeHelper.Align(ref box, bounds, Right | Center);

            Assert.Equal(100d, box.X);
            Assert.Equal(50d, box.Y);

            ResizeHelper.Align(ref box, bounds, Bottom);

            Assert.Equal(50d, box.X);
            Assert.Equal(100d, box.Y);

            ResizeHelper.Align(ref box, bounds, Center);

            Assert.Equal(50d, box.X);
            Assert.Equal(50d, box.Y);

            ResizeHelper.Align(ref box, bounds, Bottom | Right);

            Assert.Equal(100d, box.X);
            Assert.Equal(100d, box.Y);

            ResizeHelper.Align(ref box, bounds, Top | Left);

            Assert.Equal(0, box.X);
            Assert.Equal(0, box.Y);
        }

        [Fact]
		public void WithinTests()
		{
            Assert.Equal(Top | Left,  AnchorHelper.Parse("tl"));
            Assert.Equal(Top | Right, AnchorHelper.Parse("tr"));

            Assert.Equal(Top,    AnchorHelper.Parse("t"));
            Assert.Equal(Right,  AnchorHelper.Parse("r"));
            Assert.Equal(Bottom, AnchorHelper.Parse("b"));
            Assert.Equal(Left,   AnchorHelper.Parse("l"));

            Assert.Equal(Center, AnchorHelper.Parse("c"));

            // Compass
            Assert.Equal(Top,    AnchorHelper.Parse("n"));
            Assert.Equal(Right,  AnchorHelper.Parse("e"));
            Assert.Equal(Bottom, AnchorHelper.Parse("s"));
            Assert.Equal(Left,   AnchorHelper.Parse("w"));
        }
    }
}