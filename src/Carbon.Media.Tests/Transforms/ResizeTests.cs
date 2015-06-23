namespace Carbon.Media.Tests
{
	using System;

	using Xunit;

	
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
		public void FromPartialKey()
		{
			var resize = Resize.Parse("85x20");

			Assert.Equal(85, resize.Width);
			Assert.Equal(20, resize.Height);
		}
	}
}