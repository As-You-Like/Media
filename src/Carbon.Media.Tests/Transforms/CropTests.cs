using Xunit;

namespace Carbon.Media.Processing.Tests
{
    public class CropTests
	{
        [Fact]
        public void FromPercentages()
        {
            var crop = CropTransform.Parse("crop(50%,50%,960,540)");

            Assert.Equal(Unit.Percent(50), crop.X);
            Assert.Equal(Unit.Percent(50), crop.Y);
            Assert.Equal(960, crop.Width);
            Assert.Equal(540, crop.Height);

            Assert.Equal("crop(50%,50%,960,540)", crop.ToString());
        }
        
        [Fact]
        public void A()
        {
            var crop = CropTransform.Parse("crop(0,0,960,540)");

            Assert.Equal(0d  , crop.X);
            Assert.Equal(0d  , crop.Y);
            Assert.Equal(960 , crop.Width);
            Assert.Equal(540 , crop.Height);

            Assert.Equal("crop(0,0,960,540)", crop.ToString());
        }

        [Fact]
        public void B()
        {
            var crop = CropTransform.Parse("crop(x:0,y:0,width:960,height:540)");

            Assert.Equal(0d,  crop.X);
            Assert.Equal(0d,  crop.Y);
            Assert.Equal(960, crop.Width);
            Assert.Equal(540, crop.Height);

            Assert.Equal("crop(0,0,960,540)", crop.ToString());
        }
    }
}