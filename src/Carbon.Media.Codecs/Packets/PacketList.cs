using FFmpeg.AutoGen;

namespace Carbon.Media.IO
{
    public unsafe class PacketList
    {
        private AVPacketList* pointer;

        public PacketList(AVPacketList* pointer)
        {
            this.pointer = pointer;
        }

        public AVPacketList* Pointer => pointer;

        public Packet Current => default;

        public AVPacketList Next => default;
    }
}
