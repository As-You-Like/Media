namespace Carbon.Media.Formats
{
    /// <summary>
    /// Demuxers split a media file into packets (data chunks)
    /// </summary>
    public abstract class Demuxer : Format
    {
        public virtual void Open(MediaSource source)
        {
            // Opens a media file and gets the streams
        }
        
        public void Probe() { }

        public void ReadHeader(FormatContext context)
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
}
