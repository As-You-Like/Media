using Xunit;

namespace Carbon.Media.Tests
{	
	public class ResizeTests
	{
        [Fact]
        public void FromFullKey1()
        {
            var resize = Resize.Parse("resize(85x20-c)");

            Assert.Equal(85, resize.Width);
            Assert.Equal(20, resize.Height);
            Assert.Equal(CropAnchor.Center, resize.Anchor);
        }

        [Fact]
        public void NamedArgs()
        {
            var resize = Resize.Parse("85x20,carve|pad,anchor:center");

            Assert.Equal(85, resize.Width);
            Assert.Equal(20, resize.Height);
            Assert.Equal(CropAnchor.Center, resize.Anchor);
            
            Assert.Equal(ResizeFlags.Carve | ResizeFlags.Pad, resize.Flags);
            Assert.Equal(ResizeFlags.Pad, resize.Mode);
        }

        [Fact]
        public void NamedArgs2()
        {
            var resize = Resize.Parse("960x540,fit|upscale,background:red");

            Assert.Equal(960, resize.Width);
            Assert.Equal(540, resize.Height);
            Assert.Equal(null, resize.Anchor);

            Assert.Equal(ResizeFlags.Fit | ResizeFlags.Upscale, resize.Flags);
            Assert.Equal(ResizeFlags.Fit, resize.Mode);

            Assert.True(resize.Upscale);
            
            Assert.Equal("red", resize.Background);
        }

        [Fact]
        public void Flags()
        {
            var resize = new Resize(100, 100, ResizeFlags.Carve | ResizeFlags.Pad);

            Assert.Equal(ResizeFlags.Pad, resize.Mode);   
        }

        [Fact]
        public void FromPartialKey1()
        {
            var resize = Resize.Parse("85x20-l");

            Assert.Equal(85, resize.Width);
            Assert.Equal(20, resize.Height);
            Assert.Equal(CropAnchor.Left, resize.Anchor);
        }

        [Fact]
		public void FromFullKey()
		{
			var resize = Resize.Parse("resize(85x20)");

			Assert.Equal(85, resize.Width);
			Assert.Equal(20, resize.Height);
		}

        [Fact]
        public void Scaled()
        {
            var resize = Resize.Parse("resize(85x20-l)") * 2d;

            Assert.Equal(85 * 2, resize.Width);
            Assert.Equal(20 * 2, resize.Height);
            Assert.Equal(CropAnchor.Left, resize.Anchor);
        }

        [Fact]
		public void FromPartialKey()
		{
			var resize = Resize.Parse("85x20");

			Assert.Equal(85, resize.Width);
			Assert.Equal(20, resize.Height);
		}
	}
}