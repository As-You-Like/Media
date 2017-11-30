using FFmpeg.AutoGen;

namespace Carbon.Media.IO
{
    public unsafe class PacketList
    {
        AVPacketList* pointer;

        public PacketList()
        {
        }

        public Packet Current => default;

        public AVPacketList Next => default;
    }
}
