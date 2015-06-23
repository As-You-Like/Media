namespace Carbon.Media.Tests
{
	using System;

	using Xunit;

	
	public class AnchoredResizeTests
	{
		[Fact]
		public void FromFullKey()
		{
			var resize = AnchoredResize.Parse("resize:85x20-c");

			Assert.Equal(85, resize.Width);
			Assert.Equal(20, resize.Height);
			Assert.Equal(Alignment.Center, resize.Anchor);
		}

		[Fact]
		public void FromPartialKey()
		{
			var resize = AnchoredResize.Parse("85x20-l");

			Assert.Equal(85, resize.Width);
			Assert.Equal(20, resize.Height);
			Assert.Equal(Alignment.Left, resize.Anchor);
		}
	}
}