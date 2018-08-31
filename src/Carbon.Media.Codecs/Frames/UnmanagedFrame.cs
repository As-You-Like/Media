using System;
using FFmpeg.AutoGen;

namespace Carbon.Media
{
    public sealed class UnmanagedFrame : Frame
    {
        public UnmanagedFrame() { }

        public unsafe void Unref()
        {
            if (isDisposed) throw new ObjectDisposedException(nameof(Frame));

            // unreferences the frames's buffers and resets its fields
            // allowing the frame to be reused
            ffmpeg.av_frame_unref(pointer);
        }
    }
}