using FFmpeg.AutoGen;

namespace Carbon.Media.IO
{
    public unsafe class PacketList
    {
        public PacketList(AVPacketList* pointer)
        {
            Pointer = pointer;
        }

        public readonly AVPacketList* Pointer;

        public Packet Current => default;

        public AVPacketList Next => default;
    }
}