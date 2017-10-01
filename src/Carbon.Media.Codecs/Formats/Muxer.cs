namespace Carbon.Media.Formats
{
    // Muxers take encoded data in the form of AVPackets and write it into files or other output bytestreams in the specified container format.

    public abstract class Muxer : Format
    {
        // AudioCodec
        // VideoCodec
        // SubtitleCodec

        
        public virtual void WriteHeader(FormatContext context)
        {
            // Width
            // Height
            // ...
        }

        public virtual void WriteFrame(Frame frame, int? streamIndex) { }

        /// <param name="packet"></param>
        /// <param name="interleave">when true: packets are interleaved in order of increasing DTS</param>
        public virtual void WritePacket(Packet packet, bool interleave = true) { }

        public virtual void WriteTrailer(FormatContext context)
        {
        }
    }
}