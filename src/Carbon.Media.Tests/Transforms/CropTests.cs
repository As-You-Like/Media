using System;

using Xunit;

namespace Carbon.Media.Tests
{	
	public class CropTests
	{
		[Fact]
		public void FromFullKey()
		{
			var crop = Crop.Parse("crop:10-0_85x20");

			Assert.Equal(10, crop.Rectangle.X);
			Assert.Equal(0, crop.Rectangle.Y);
			Assert.Equal(85, crop.Rectangle.Width);
			Assert.Equal(20, crop.Rectangle.Height);
		}

		[Fact]
		public void FromPartialKey()
		{
			var crop = Crop.Parse("0-0_85x20");

			Assert.Equal(0, crop.Rectangle.X);
			Assert.Equal(0, crop.Rectangle.Y);
			Assert.Equal(85, crop.Rectangle.Width);
			Assert.Equal(20, crop.Rectangle.Height);
		}
	}
}