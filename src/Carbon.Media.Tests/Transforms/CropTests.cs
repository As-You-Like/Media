using Xunit;

namespace Carbon.Media.Tests
{	
	public class CropTests
	{
        [Fact]
        public void CropNewFormat()
        {
            var crop = Crop.Parse("crop(0,0,960,540)");

            Assert.Equal(0d  , crop.Rectangle.X);
            Assert.Equal(0d  , crop.Rectangle.Y);
            Assert.Equal(960 , crop.Rectangle.Width);
            Assert.Equal(540 , crop.Rectangle.Height);

            Assert.Equal("crop(0,0,960,540)", crop.ToString());
        }

        [Fact]
		public void FromLegacyFormat()
		{
			var crop = Crop.Parse("crop:10-0_85x20");

			Assert.Equal(10, crop.Rectangle.X);
			Assert.Equal(0, crop.Rectangle.Y);
			Assert.Equal(85, crop.Rectangle.Width);
			Assert.Equal(20, crop.Rectangle.Height);
		}

		[Fact]
		public void FromLegacyFormatShort()
		{
			var crop = Crop.Parse("0-0_85x20");

			Assert.Equal(0, crop.Rectangle.X);
			Assert.Equal(0, crop.Rectangle.Y);
			Assert.Equal(85, crop.Rectangle.Width);
			Assert.Equal(20, crop.Rectangle.Height);
		}
	}
}