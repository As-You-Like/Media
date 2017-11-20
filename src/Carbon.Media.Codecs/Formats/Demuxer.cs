using FFmpeg.AutoGen;

namespace Carbon.Media.Formats
{
    /// <summary>
    /// Demuxers split a media file into packets (data chunks)
    /// </summary>
    public abstract class Demuxer : Format
    {
        public Demuxer(FormatId format)
            : base(format) { }

        public virtual void Open(MediaSource source)
        {


            // Opens a media file and gets the streams
        }

        public void ReadHeader(FormatContext context)
        {
        }

        // Packets are either Video or Audio data
        public bool TryReadPacket(Packet packet)
        {
            return false;
        }

        // Play
        // Seek
        // Close
        
        // Events
        // - OnMetadata
        // - OnPacket
    }
}
