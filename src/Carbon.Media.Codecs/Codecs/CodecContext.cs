namespace Carbon.Media.Codecs
{
    public class CodecContext
    {
        public Codec Codec { get; set; }

        public BitRate Bitrate { get; set; }

        public BitRate BitrateTolerance { get; set; }

        public PixelFormat Format { get; set; }

        // MaxBFrames
        // QuantyFactor
        // FrameStategry
        // QuantyOffset
        // HasBFrames
        // 
        public int Width { get; set; }

        public int Height { get; set; }

        public int SampleRate { get; set; }

        public int ChannelCount { get; set; }

        public ColorSpace ColorSpace  { get; set; }

        // FrameIndex
        // BlockAlign
        // FrameSize
        // SampleFormat

        // CodecWidth
        // CodedHeight

        // GopSize

        // Compression

        // ticksPerFrame
        // TimeBase
        // Delay
       
    }
}
