using Xunit;

namespace Carbon.Media.Tests
{	
	public class ResizeTests
	{
		[Fact]
		public void FromFullKey()
		{
			var resize = Resize.Parse("resize:85x20");

			Assert.Equal(85, resize.Width);
			Assert.Equal(20, resize.Height);
		}

        [Fact]
        public void Scaled()
        {
            var resize = Resize.Parse("resize:85x20-l") * 2;

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