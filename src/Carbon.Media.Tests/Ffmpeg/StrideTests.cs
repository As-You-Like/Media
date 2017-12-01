using Xunit;

namespace Carbon.Media.Tests
{
    public class StrideTests
    {
        static StrideTests()
        {
            FFmpegBinariesHelper.RegisterFFmpegBinaries();
        }

        [Fact]
        public void StrideTest1()
        {
            var strides = VideoFormatInfo.Create(PixelFormat.Rgba32, 800, 600).Strides;

            Assert.Single(strides);
            Assert.Equal(3200, strides[0]);
        }

        [Fact]
        public void StrideTest2()
        {
            var strides = VideoFormatInfo.Create(PixelFormat.Rgb24, 800, 600).Strides;

            Assert.Single(strides);
            Assert.Equal(2400, strides[0]);
        }

        [Fact]
        public void StrideTest3()
        {
            var strides = VideoFormatInfo.Create(PixelFormat.Yuv410p, 800, 600).Strides;

            Assert.Collection(strides,
                a => Assert.Equal(800, a),
                b => Assert.Equal(200, b),
                c => Assert.Equal(200, c)
            );
        }
    }
}
