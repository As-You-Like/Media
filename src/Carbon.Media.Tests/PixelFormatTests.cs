using Xunit;

using FFmpeg.AutoGen;

namespace Carbon.Media.Tests
{
    using static ColorComponent;

    public class PixelFormatTests
    {
        [Theory]
        [InlineData("A8",         PixelFormat.A8)]
        [InlineData("BlackWhite", PixelFormat.BlackWhite)]
        [InlineData("Cmyk32",     PixelFormat.Cmyk32)]
        // RGB -------------------------------------------
        [InlineData("Rgb24",      PixelFormat.Rgb24)]
        [InlineData("Rgba32",     PixelFormat.Rgba32)]
        [InlineData("Rgba64",     PixelFormat.Rgba64)]
        [InlineData("rgb48be",    PixelFormat.Rgb48be)]
        // BGR(A) -------------------------------------------
        [InlineData("Bgr24",      PixelFormat.Bgr24)]
        [InlineData("Bgra32",     PixelFormat.Bgra32)]
        [InlineData("Bgra64",     PixelFormat.Bgra64)]
        // YUV
        [InlineData("yuv422p",    PixelFormat.Yuv422p)]
        public void Parse(string text, PixelFormat type)
        {
            Assert.Equal(type, PixelFormatHelper.Parse(text));
        }


        [Fact]
        public void Identity()
        {
            Assert.Equal(10, (int)PixelFormat.Bgr4);
        }

        // https://ffmpeg.org/pipermail/ffmpeg-devel/2007-May/035617.html

        [Theory]
        [InlineData(AVPixelFormat.AV_PIX_FMT_YUV410P,   PixelFormat.Yuv410p)]
        [InlineData(AVPixelFormat.AV_PIX_FMT_YUV411P,   PixelFormat.Yuv411p)]
        [InlineData(AVPixelFormat.AV_PIX_FMT_YUV420P,   PixelFormat.Yuv420p)]
        [InlineData(AVPixelFormat.AV_PIX_FMT_YUYV422,   PixelFormat.Yuyv422)]

        // RGB
        [InlineData(AVPixelFormat.AV_PIX_FMT_RGB4,      PixelFormat.Rgb4)]
        [InlineData(AVPixelFormat.AV_PIX_FMT_RGB8,      PixelFormat.Rgb8)]
        [InlineData(AVPixelFormat.AV_PIX_FMT_RGB24,     PixelFormat.Rgb24)]
        [InlineData(AVPixelFormat.AV_PIX_FMT_RGBA,      PixelFormat.Rgba32)]

        // BGR
        [InlineData(AVPixelFormat.AV_PIX_FMT_BGR4,      PixelFormat.Bgr4)]
        [InlineData(AVPixelFormat.AV_PIX_FMT_BGR8,      PixelFormat.Bgr8)]
        [InlineData(AVPixelFormat.AV_PIX_FMT_BGR24,     PixelFormat.Bgr24)]
        [InlineData(AVPixelFormat.AV_PIX_FMT_BGRA,      PixelFormat.Bgra32)]


        // GRAY
        [InlineData(AVPixelFormat.AV_PIX_FMT_GRAY8, PixelFormat.Gray8)]

        // BGR(A)P
        [InlineData(AVPixelFormat.AV_PIX_FMT_GBRP,       PixelFormat.Gbrp)]
        [InlineData(AVPixelFormat.AV_PIX_FMT_GBRAP,      PixelFormat.Gbrap)]
        [InlineData(AVPixelFormat.AV_PIX_FMT_GBRAPF32BE, PixelFormat.Gbrapfbe)]
        [InlineData(AVPixelFormat.AV_PIX_FMT_GBRAPF32LE, PixelFormat.Gbrapfle)]
        
        // YUV
        [InlineData(AVPixelFormat.AV_PIX_FMT_YUV422P,   PixelFormat.Yuv422p)]
        [InlineData(AVPixelFormat.AV_PIX_FMT_YUV444P,   PixelFormat.Yuv444p)]

        // [InlineData(AVPixelFormat.AV_PIX_FMT_BGR555BE, PixelFormat.Bgr555)]
        [InlineData(AVPixelFormat.AV_PIX_FMT_NV12, PixelFormat.Nv12)]
        public void FfmpegInterop(AVPixelFormat avFormat, PixelFormat format)
        {
            Assert.Equal(avFormat, format.ToAVFormat());
        }

        [Fact]
        public void ComponentTests()
        {
            // RGBA
            Assert.Equal(1,  (int)R);
            Assert.Equal(2,  (int)G);
            Assert.Equal(3,  (int)B);
            Assert.Equal(4,  (int)A);

            // YUV
            Assert.Equal(5,  (int)Y);
            Assert.Equal(6,  (int)U); 
            Assert.Equal(7,  (int)V);
            
            // CMYK
            Assert.Equal(10, (int)Cyan);
            Assert.Equal(11, (int)Magenta);
            Assert.Equal(12, (int)Yellow);
            Assert.Equal(13, (int)Key);
        }

        [Fact]
        public void ColorChannelAliasTests()
        {
            // CbCr aliases
            Assert.Equal(6, (int)ColorChannel.Cb(1).Component);
            Assert.Equal(7, (int)ColorChannel.Cr(1).Component);
        }

        [Fact]
        public void General()
        {
            var bw = PixelFormat.BlackWhite.GetInfo();

            Assert.Equal(1, bw.BitsPerPixel);
            // Assert.Equal(ColorChannels.K, bw.Channels);
            Assert.Equal(ColorModel.Monochrome, bw.ColorModel);

            var rgb24 = PixelFormat.Rgb24.GetInfo();

            Assert.Equal(8, rgb24.BitsPerPixel);
            // Assert.Equal(ColorChannels.RGB, rgb24.Channels);
            Assert.Equal(ColorModel.RGB, rgb24.ColorModel);

            var rgba64 = PixelFormat.Rgba64.GetInfo();

            Assert.Equal(16, rgba64.BitsPerPixel);
            // Assert.Equal(ColorChannels.RGBA, rgba64.Channels);
            Assert.Equal(ColorModel.RGB, rgba64.ColorModel);
        }
    }
}