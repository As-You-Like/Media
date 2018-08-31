using System;

using FFmpeg.AutoGen;

namespace Carbon.Media
{
    public unsafe class SwsContext : IDisposable
    {
        private bool isDisposed = false;
        private FFmpeg.AutoGen.SwsContext* pointer;

        private SwsContext(FFmpeg.AutoGen.SwsContext* pointer)
        {
            if (pointer == null)
                throw new ArgumentNullException(nameof(pointer));
            
            this.pointer = pointer;
        }

        public static SwsContext Create(VideoFormatInfo source,  VideoFormatInfo target, SwsFlags flags)
        {
            var pointer = ffmpeg.sws_getContext(
                source.Width, 
                source.Height, 
                source.PixelFormat.ToAVFormat(), 
                target.Width, 
                target.Height,
                target.PixelFormat.ToAVFormat(),
                flags     : (int)flags,
                srcFilter : null, 
                dstFilter : null,
                param     : null
            );

            return new SwsContext(pointer);
        }
        
        public int Scale(VideoFrame source, VideoFrame destination)
        {
            return Scale(source, 0, source.Height, destination);
        }

        public int Scale(VideoFrame source, int srcSliceY, int srcSliceH, VideoFrame destination)
        {
             return ffmpeg.sws_scale(
                c         : pointer,
                srcSlice  : source.Pointer->data,
                srcStride : source.Pointer->linesize,
                srcSliceY : srcSliceY,
                srcSliceH : srcSliceH,
                dst       : destination.PlanePointers,
                dstStride : destination.Strides
            );
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);

            Dispose(true);
        }

        public void Dispose(bool disposing)
        {
            if (isDisposed) return;
            
            ffmpeg.sws_freeContext(pointer);

            pointer = null;

            isDisposed = true;
        }

        ~SwsContext()
        {
            Dispose(false);
        }
    }
}