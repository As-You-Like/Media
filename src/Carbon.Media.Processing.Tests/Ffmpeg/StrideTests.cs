using Xunit;

namespace Carbon.Media.Tests
{
    public class StrideTests
    {
        [Fact]
        public void StrideTest1()
        {
            var strides = new VideoFormatInfo(PixelFormat.Rgba32, 800, 600).GetStrides(1);

            Assert.Single(strides);
            Assert.Equal(3200, strides[0]);
        }

        [Fact]
        public void StrideTest2()
        {
            var strides = new VideoFormatInfo(PixelFormat.Rgb24, 800, 600).GetStrides(1);

            Assert.Single(strides);
            Assert.Equal(2400, strides[0]);
        }

        [Fact]
        public void StrideTest3()
        {
            var strides = new VideoFormatInfo(PixelFormat.Yuv410p, 800, 600).GetStrides(1);

            Assert.Collection(strides,
                a => Assert.Equal(800, a),
                b => Assert.Equal(200, b),
                c => Assert.Equal(200, c)
            );
        }
    }
}
