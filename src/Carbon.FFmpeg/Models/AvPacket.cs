using Carbon.Media;
using FFmpeg.AutoGen;

using static FFmpeg.AutoGen.ffmpeg;

namespace FFmpeg
{   
    public sealed unsafe class AvPacket : Packet
    {
        private AVPacket* pointer;

        public AvPacket(AVPacket* pointer)
        {
            this.pointer = pointer;
        }

        public AVPacket* Pointer => pointer;

        public override long Dts
        {
            get => pointer->dts;
            set => pointer->dts = value;
        }

        public override long Pts
        {
            get => pointer->pts;
            set => pointer->pts = value;
        }

        public override long Position
        {
            get => pointer->pos;
            set => pointer->pos = value;
        }

        public override long Duration
        {
            get => pointer->duration;
            set => pointer->duration = value;
        }

        public int Flags
        {
            get => pointer->flags;
            set => pointer->flags = value;
        }

        public override void Dispose()
        {
            fixed (AVPacket** pPointer = &pointer)
            {
                av_packet_free(pPointer);
            }
        }

        /// <summary>
        /// Allocate a new FFmpeg AVPacket
        /// </summary>
        /// <returns></returns>
        public static AvPacket Create()
        {
            return new AvPacket(av_packet_alloc());
        }
    }

}
