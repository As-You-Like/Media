using System;
using System.Runtime.InteropServices;
using Carbon.Color;
using Xunit;

namespace Carbon.Media.Processing.Tests
{
    public class ResamplerTests
    {
        [Fact]
        public unsafe void ChangePixelFormat()
        {
            var sourceFormat = new VideoFormatInfo(PixelFormat.Bgra32, 100, 100);
            var targetFormat = new VideoFormatInfo(PixelFormat.Rgb24, 100, 100);

            using (var source = new VideoFrame(sourceFormat))
            using (var target = new VideoFrame(targetFormat))
            using (var resampler = new VideoResampler(sourceFormat, targetFormat))
            {
                Assert.Equal(300, target.Strides[0]);

                var pixels = MemoryMarshal.Cast<byte, Bgra32>(source.Memory.Span);

                pixels.Fill(new Bgra32(new Rgba32(1, 2, 3, 4)));

                Assert.Equal(100 * 100 * 4, source.Memory.Length);
                Assert.Equal(100 * 100 * 3, target.Memory.Length);

                resampler.Resample(source, target);

                foreach (Rgb24 pixel in MemoryMarshal.Cast<byte, Rgb24>(target.Memory.Span))
                {
                    Assert.Equal(new Rgb24(1, 2, 3), pixel);
                }
            }
        }

        [Fact]
        public unsafe void Scale()
        {
            var sourceFormat = new VideoFormatInfo(PixelFormat.Bgra32, 1000, 1000);
            var targetFormat = new VideoFormatInfo(PixelFormat.Rgb24, 100, 100);

            using (var source = new VideoFrame(sourceFormat))
            using (var target = new VideoFrame(targetFormat))
            using (var resampler = new VideoResampler(sourceFormat, targetFormat, SwsFlags.Lanczos))
            {
                Assert.Equal(300, target.Strides[0]);

                var pixels = MemoryMarshal.Cast<byte, Bgra32>(source.Memory.Span);

                pixels.Fill(new Bgra32(new Rgba32(1, 2, 3, 4)));

                Assert.Equal(1000 * 1000 * 4, source.Memory.Length);
                Assert.Equal(100 * 100 * 3, target.Memory.Length);

                resampler.Resample(source, target);

                int i = 0;

                foreach (Rgb24 pixel in MemoryMarshal.Cast<byte, Rgb24>(target.Memory.Span))
                {
                    if (!pixel.Equals(new Rgb24(1, 2, 3)))
                    {
                        throw new Exception($"{i} | {pixel.R},{pixel.B},{pixel.G})");
                    }

                    Assert.Equal(new Rgb24(1, 2, 3), pixel);

                    i++;
                }
            }
        }
    }
}