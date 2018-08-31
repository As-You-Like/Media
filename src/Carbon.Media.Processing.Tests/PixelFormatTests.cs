using FFmpeg.AutoGen;
using Xunit;

namespace Carbon.Media.Processing.Tests
{
    public class PixelFormatTests
    {
        [Theory]
        [InlineData(AVPixelFormat.AV_PIX_FMT_YUV410P, PixelFormat.Yuv410p)]
        [InlineData(AVPixelFormat.AV_PIX_FMT_YUV411P, PixelFormat.Yuv411p)]
        [InlineData(AVPixelFormat.AV_PIX_FMT_YUV420P, PixelFormat.Yuv420p)]
        [InlineData(AVPixelFormat.AV_PIX_FMT_YUYV422, PixelFormat.Yuyv422)]

        // RGB
        [InlineData(AVPixelFormat.AV_PIX_FMT_RGB4, PixelFormat.Rgb4)]
        [InlineData(AVPixelFormat.AV_PIX_FMT_RGB8, PixelFormat.Rgb8)]
        [InlineData(AVPixelFormat.AV_PIX_FMT_RGB24, PixelFormat.Rgb24)]
        [InlineData(AVPixelFormat.AV_PIX_FMT_RGBA, PixelFormat.Rgba32)]

        // BGR
        [InlineData(AVPixelFormat.AV_PIX_FMT_BGR4, PixelFormat.Bgr4)]
        [InlineData(AVPixelFormat.AV_PIX_FMT_BGR8, PixelFormat.Bgr8)]
        [InlineData(AVPixelFormat.AV_PIX_FMT_BGR24, PixelFormat.Bgr24)]
        [InlineData(AVPixelFormat.AV_PIX_FMT_BGRA, PixelFormat.Bgra32)]

        // GRAY
        [InlineData(AVPixelFormat.AV_PIX_FMT_GRAY8,    PixelFormat.Gray8)]
        [InlineData(AVPixelFormat.AV_PIX_FMT_GRAY16BE, PixelFormat.Gray16be)]

        // BGR(A)P

        [InlineData(AVPixelFormat.AV_PIX_FMT_GBRP, PixelFormat.Gbrp)]
        [InlineData(AVPixelFormat.AV_PIX_FMT_GBRAP, PixelFormat.Gbrap)]
        [InlineData(AVPixelFormat.AV_PIX_FMT_GBRAPF32BE, PixelFormat.Gbrapfbe)]
        [InlineData(AVPixelFormat.AV_PIX_FMT_GBRAPF32LE, PixelFormat.Gbrapfle)]

        // YUV
        [InlineData(AVPixelFormat.AV_PIX_FMT_YUV422P, PixelFormat.Yuv422p)]
        [InlineData(AVPixelFormat.AV_PIX_FMT_YUV444P, PixelFormat.Yuv444p)]

        // [InlineData(AVPixelFormat.AV_PIX_FMT_BGR555BE, PixelFormat.Bgr555)]
        [InlineData(AVPixelFormat.AV_PIX_FMT_NV12, PixelFormat.Nv12)]
        public void FfmpegInterop(AVPixelFormat avFormat, PixelFormat format)
        {
            Assert.Equal(avFormat, format.ToAVFormat());
            Assert.Equal(format, avFormat.ToFormat());
        }
    }
}
