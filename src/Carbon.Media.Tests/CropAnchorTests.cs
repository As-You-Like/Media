using System.Drawing;

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
            var box = new Rectangle(0, 0, 100, 100);
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
		public void ParseTests()
		{
            Assert.Equal(Top | Left,  CropAnchorHelper.Parse("tl"));
            Assert.Equal(Top | Right, CropAnchorHelper.Parse("tr"));

            Assert.Equal(Top,         CropAnchorHelper.Parse("t"));
            Assert.Equal(Right,       CropAnchorHelper.Parse("r"));
            Assert.Equal(Bottom,      CropAnchorHelper.Parse("b"));
            Assert.Equal(Left,        CropAnchorHelper.Parse("l"));

            Assert.Equal(Center,      CropAnchorHelper.Parse("c"));

            // Compass
            Assert.Equal(Top,         CropAnchorHelper.Parse("n"));
            Assert.Equal(Right,       CropAnchorHelper.Parse("e"));
            Assert.Equal(Bottom,      CropAnchorHelper.Parse("s"));
            Assert.Equal(Left,        CropAnchorHelper.Parse("w"));

            // Full words
            Assert.Equal(Top,         CropAnchorHelper.Parse("top"));
            Assert.Equal(Right,       CropAnchorHelper.Parse("right"));
            Assert.Equal(Bottom,      CropAnchorHelper.Parse("bottom"));
            Assert.Equal(Left,        CropAnchorHelper.Parse("left"));
        }
    }
}