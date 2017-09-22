using FFmpeg.AutoGen;

namespace FFmpeg
{
    public unsafe class AvIOContext
    {
        private AVIOContext* pointer;

        public AvIOContext(AVIOContext* pointer)
        {
            this.pointer = pointer;
        }

        public AVIOContext* Pointer => pointer;


    }

}
