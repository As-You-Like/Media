using Xunit;

namespace Carbon.Media.Processors.Tests
{
    public class CropTests
	{
        [Fact]
        public void FromPercentages()
        {
            var crop = CropTransform.Parse("crop(50%,50%,960,540)");

            Assert.Equal(0.5d, crop.X);
            Assert.Equal(0.5d, crop.Y);
            Assert.Equal(960, crop.Width);
            Assert.Equal(540, crop.Height);

            Assert.Equal("crop(50％,50％,960,540)", crop.ToString());
        }

        [Fact]
        public void CropNewFormat()
        {
            var crop = CropTransform.Parse("crop(0,0,960,540)");

            Assert.Equal(0d  , crop.X);
            Assert.Equal(0d  , crop.Y);
            Assert.Equal(960 , crop.Width);
            Assert.Equal(540 , crop.Height);

            Assert.Equal("crop(0,0,960,540)", crop.ToString());
        }

        [Fact]
		public void FromLegacyFormat()
		{
			var crop = CropTransform.Parse("crop:10-0_85x20");

			Assert.Equal(10, crop.X);
			Assert.Equal(0,  crop.Y);
			Assert.Equal(85, crop.Width);
			Assert.Equal(20, crop.Height);
		}

		[Fact]
		public void FromLegacyFormatShort()
		{
			var crop = CropTransform.Parse("0-0_85x20");

			Assert.Equal(0,  crop.X);
			Assert.Equal(0,  crop.Y);
			Assert.Equal(85, crop.Width);
			Assert.Equal(20, crop.Height);
		}
	}
}