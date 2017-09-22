using Carbon.Media.Processing;

namespace Carbon.Media.Containers
{
    // Muxers take encoded data in the form of AVPackets and write it into files or other output bytestreams in the specified container format.

    public abstract class Muxer : Container
    {
        // AudioCodec
        // VideoCodec
        // SubtitleCodec
        
        public void WriteHeader(FormatContext context)
        {
            // Width
            // Height
            // ...
        }

        public void WriteFrame(Frame frame, int? streamIndex) { }
        
        // if interleave is true: the muxer will ensure that packets are interleaved in order of increasing DTS
        public void WritePacket(Packet packet, bool interleave = true) { }

        public void WriteTrailer(FormatContext context)
        {
        }
    }

    // AKA: AVOutputFormat

    // AudioCodec
    // VideoCodec
    // SubtitleCodec

   
    /// Chromoprint
    /// Crc
    /// Framecrc
    /// Framehash
    /// Gif
    /// Hls
    /// Ico
    /// Mpegts
    /// Webm
}
