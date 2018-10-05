using Xunit;

namespace Carbon.Media.Processing.Tests
{
    public class ResizeTests
	{
        // 100x100
        // _x100
        // 100x_
        // 100×100
        // 100×100,anchor:c
        // 0.5×0.5
        // 50﹪,
        // 50%x50%

        [Fact]
        public void FromPercentages()
        {
            var resize = ResizeTransform.Parse("50%x50%");

            Assert.Equal(Unit.Percent(50), resize.Width);
            Assert.Equal(Unit.Percent(50), resize.Height);
        }

        [Fact]
        public void FromPt()
        {
            var resize = ResizeTransform.Parse("resize(50pt,50pt)");

            Assert.Equal(Unit.Pt(50), resize.Width);
            Assert.Equal(Unit.Pt(50), resize.Height);
        }


        [Fact]
        public void FromFullKey1()
        {
            var resize = ResizeTransform.Parse("resize(85x20-c)");

            Assert.Equal(85d, resize.Width);
            Assert.Equal(20d, resize.Height);
            Assert.Equal(CropAnchor.Center, resize.Anchor);

            Assert.Equal("85x20-c", resize.ToString());

            Assert.Equal("resize(85,20,anchor:c)", resize.Canonicalize());
        }

        [Fact]
        public void NamedArgs()
        {
            var resize = ResizeTransform.Parse("85x20,carve|pad,anchor:center");

            Assert.Equal(85d, resize.Width);
            Assert.Equal(20d, resize.Height);
            Assert.Equal(CropAnchor.Center, resize.Anchor);
            
            Assert.Equal(ResizeFlags.Carve | ResizeFlags.Pad, resize.Flags);
            Assert.Equal(ResizeFlags.Pad, resize.Mode);
        }

        [Fact]
        public void ToString1()
        {
            var resize = ResizeTransform.Parse("85x20,carve|pad,anchor:center");

            Assert.Equal("85x20,pad|carve,anchor:c", resize.ToString());

            Assert.Equal("resize(85,20,pad|carve,anchor:c)", resize.Canonicalize());
        }

        [Fact]
        public void NamedArgs2()
        {
            var resize = ResizeTransform.Parse("960x540,fit|upscale");

            Assert.Equal(960, resize.Width);
            Assert.Equal(540, resize.Height);
            Assert.Null(resize.Anchor);

            Assert.Equal(ResizeFlags.Fit | ResizeFlags.Upscale, resize.Flags);
            Assert.Equal(ResizeFlags.Fit, resize.Mode);

            Assert.True(resize.Upscale);
            
        }

        [Fact]
        public void Flags()
        {
            var resize = new ResizeTransform(100, 100, ResizeFlags.Carve | ResizeFlags.Pad);

            Assert.Equal(ResizeFlags.Pad, resize.Mode);   
        }

        [Fact]
        public void FromPartialKey1()
        {
            var resize = ResizeTransform.Parse("85x20-l");

            Assert.Equal(85, resize.Width);
            Assert.Equal(20, resize.Height);
            Assert.Equal(CropAnchor.Left, resize.Anchor);
        }

        [Fact]
		public void FromFullKey()
		{
			var resize = ResizeTransform.Parse("resize(85x20)");

			Assert.Equal(85, resize.Width);
			Assert.Equal(20, resize.Height);
		}

        [Fact]
        public void Scaled()
        {
            var resize = ResizeTransform.Parse("resize(85x20-l)") * 2d;

            Assert.Equal(85 * 2, resize.Width);
            Assert.Equal(20 * 2, resize.Height);
            Assert.Equal(CropAnchor.Left, resize.Anchor);
        }

        [Fact]
		public void FromPartialKey()
		{
			var resize = ResizeTransform.Parse("85x20");

			Assert.Equal(85, resize.Width);
			Assert.Equal(20, resize.Height);
		}
	}
}