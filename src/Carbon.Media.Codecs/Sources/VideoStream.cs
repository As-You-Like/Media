using Carbon.Media.Codecs;

namespace Carbon.Media
{
    public class VideoStream : MediaStream
    {
        public VideoStream(int index, Codec codec)
            : base(index, codec) { }

        //	picture width / height
        public int Width { get; set; }

        public int Height { get; set; }

        public int CodedWidth { get; set; }

        public int CodedHeight { get; set; }

        public Rational FrameRate { get; set; }

        public Rational Aspect { get; set; }

        public PixelFormat PixelFormat { get; set; }
        
        public BitRate BitRateAverage { get; set; }

        public BitRate BitRateTolerance { get; set; }

        public override MediaStreamType Type => MediaStreamType.Video;
    }
}