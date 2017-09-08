namespace Carbon.Media.Muxing
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
