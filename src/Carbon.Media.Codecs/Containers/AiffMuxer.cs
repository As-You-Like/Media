namespace Carbon.Media.Muxing
{
    public class AiffMuxer : Muxer
    {
    }

    public class AiffMuxerOptions
    {
        public int PacketSize { get; set; } = 3200;
    }
}