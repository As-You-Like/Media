namespace Carbon.Media.Containers
{
    public class AviMuxer : Muxer
    {
    }

    public class AviMuxerOptions
    {
        public int ReserveIndexSpace { get; set; }

        public int WriteChannelMask { get; set; }
    }
}
