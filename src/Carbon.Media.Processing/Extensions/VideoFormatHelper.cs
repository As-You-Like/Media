
using FFmpeg.AutoGen;

namespace Carbon.Media
{
    public static class VideoFormatHelper
    {
        public static int GetBufferSize(this VideoFormatInfo format, int align)
        {
            return ffmpeg.av_image_get_buffer_size(format.PixelFormat.ToAVFormat(), format.Width, format.Height, align);
        }

        public static int[] GetStrides(this VideoFormatInfo format, int align)
        {
            return GetStrides(format.PixelFormat, format.Width, align);
        }

        public static int GetBufferSize(PixelFormat pixelFormat, int width, int height, int align)
        {
            return ffmpeg.av_image_get_buffer_size(pixelFormat.ToAVFormat(), width, height, align);
        }

        public static int[] GetStrides(PixelFormat pixelFormat, int width, int align)
        {
            // Ensure align is a power of two...

            // Based on:
            // https://github.com/ibukisaar/SaarFFmpeg/blob/9310b8e8dea99712c9dfec4df746cfb5b8f72d25/SaarFFmpeg/CSharp/VideoFormat.cs
            // MIT Licenced
            // Copyright (c) 2018 Saar Ibuki

            var avFormat = pixelFormat.ToAVFormat();

            int planeCount = ffmpeg.av_pix_fmt_count_planes(avFormat);

            var temp = new int_array4();

            ffmpeg.av_image_fill_linesizes(ref temp, avFormat, width);

            var tempValues = temp.ToArray();

            var strides = new int[planeCount];

            for (int i = 0; i < planeCount; i++)
            {
                strides[i] = (tempValues[i] + (align - 1)) & ~(align - 1);
            }

            return strides;
        }
    }
}
