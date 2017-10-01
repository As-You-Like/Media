using Xunit;

namespace Carbon.Media.Tests
{
    public class ColorSpaceTests
    {
        [Fact]
        public void IdsAreStable()
        {
            Assert.Equal(4,  (int)ColorSpace.AdobeRGB);
            Assert.Equal(11, (int)ColorSpace.LUV);
            Assert.Equal(21, (int)ColorSpace.CMYK);
            Assert.Equal(42, (int)ColorSpace.HLS);
        }

        [Fact]
        public void ColorSpaceInfoTests()
        {
            var colorSpace = ColorSpaceInfo.DciP3;
            Assert.Equal(4,  (int)ColorSpace.AdobeRGB);
            Assert.Equal(11, (int)ColorSpace.LUV);
            Assert.Equal(21, (int)ColorSpace.CMYK);
            Assert.Equal(42, (int)ColorSpace.HLS);
        }
    }
}
