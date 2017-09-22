using Carbon.Media;
using FFmpeg.AutoGen;

using static FFmpeg.AutoGen.ffmpeg;

namespace FFmpeg
{
    public unsafe class AvFrame : Frame
    {
        // The buffer is managed seperately from this object

        private AVFrame* pointer;

        public AvFrame(AVFrame* pointer)
            : base(null) { }

        public AVFrame* Pointer => pointer;

        /// <summary>
        /// Allocate a new FFmpeg AVFrame
        /// </summary>
        public static AvFrame Create()
        {
            return new AvFrame(av_frame_alloc());
        }
        
        public bool IsKeyFrame => pointer->key_frame != 0;

        public override long Pts
        {
            get => pointer->pts;
            set => pointer->pts = value;
        }
        
        /*
        ~AvFrame()
        {
        }
        */

        public void Dispose()
        {
            fixed (AVFrame** pPointer = &pointer)
            {
                av_frame_free(pPointer);
            }
        }
    }

}
