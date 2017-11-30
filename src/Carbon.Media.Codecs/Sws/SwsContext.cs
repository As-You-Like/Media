using System;

using FFmpeg.AutoGen;

namespace Carbon.Media
{
    public unsafe class SwsContext : IDisposable
    {
        private FFmpeg.AutoGen.SwsContext* pointer;

        public SwsContext(FFmpeg.AutoGen.SwsContext* pointer)
        {
            this.pointer = pointer;
        }

        public static SwsContext Create(
            int sourceWidth, 
            int sourceHeight, 
            PixelFormat sourceFormat, 
            int targetWidth, 
            int targetHeight,
            PixelFormat targetFormat, 
            SwsFlags flags)
        {
            var pointer = ffmpeg.sws_getContext(
                sourceWidth, 
                sourceHeight, 
                sourceFormat.ToAVFormat(), 
                targetWidth, 
                targetHeight,
                targetFormat.ToAVFormat(),
                (int)flags,
                null, 
                null, 
                null);

            if (pointer == null)
            {
                throw new Exception("error initizing sws context");
            }

            return new SwsContext(pointer);
        }

        public int Scale(VideoFrame source, int srcSliceY, int srcSliceH, VideoFrame destination)
        {
            return ffmpeg.sws_scale(
                c           : pointer,
                srcSlice    : source.Pointer->data,
                srcStride   : source.Pointer->linesize,
                srcSliceY   : srcSliceY,
                srcSliceH   : srcSliceH,
                dst         : destination.PlaneDataPointers,
                dstStride   : destination.Strides
            );
        }

        public void Dispose()
        {
            ffmpeg.av_free(pointer);
        }
    }
}