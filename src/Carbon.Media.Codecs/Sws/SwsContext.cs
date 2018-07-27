using System;

using FFmpeg.AutoGen;

namespace Carbon.Media
{
    public unsafe class SwsContext : IDisposable
    {
        private FFmpeg.AutoGen.SwsContext* pointer;

        private SwsContext(FFmpeg.AutoGen.SwsContext* pointer)
        {
            if (pointer == null)
                throw new ArgumentNullException(nameof(pointer));
            
            this.pointer = pointer;
        }

        public static SwsContext Create(
            int sourceWidth, 
            int sourceHeight, 
            PixelFormat sourcePixelFormat, 
            int targetWidth, 
            int targetHeight,
            PixelFormat targetFormat, 
            SwsFlags flags)
        {
            var pointer = ffmpeg.sws_getContext(
                sourceWidth, 
                sourceHeight, 
                sourcePixelFormat.ToAVFormat(), 
                targetWidth, 
                targetHeight,
                targetFormat.ToAVFormat(),
                flags     : (int)flags,
                srcFilter : null, 
                dstFilter : null,
                param     : null);

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
            GC.SuppressFinalize(this);

            Dispose(true);
        }

        public void Dispose(bool disposing)
        {
            if (pointer != null)
            {
                ffmpeg.sws_freeContext(pointer);

                pointer = null;
            }
        }

        ~SwsContext()
        {
            Dispose(true);
        }
    }
}