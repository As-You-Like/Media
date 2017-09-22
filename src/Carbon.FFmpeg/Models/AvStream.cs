using FFmpeg.AutoGen;

namespace FFmpeg
{
    public unsafe class AvStream
    {
        private readonly AVStream* pointer;

        public AvStream(AVStream* pointer)
        {
            this.pointer = pointer;
        }

        public AVStream* Pointer => pointer;
    }
}
