namespace Carbon.Media.Containers
{
    /// <summary>
    /// Demuxers read a media file and split it into chunks of data (packets).
    /// </summary>
    public abstract class Demuxer : Container
    {
        public Demuxer()
        {
            // open the container
            // avformat_open_input

            // open the "container"

            // get the streams
        }

       
        public void Probe() { }

        public void ReadHeader(ContainerContext context)
        {
        }


        // Packets are either Video or Audio
        public Packet ReadPacket() => null;

        // Play
        // Seek
        // Close


        // Events
        // - OnMetadata
        // - OnPacket
    }

    // AVInputFormat
    // AA
    // AppleHttp
    // Asf
    // Flv
    // Gif
    // Hls
    // Mov
    // Mpegts
    // Mpjpeg
    // RawVideo
}
