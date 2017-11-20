using FFmpeg.AutoGen;

namespace Carbon.Media.Codecs
{
    public unsafe class CodecContext
    {
        protected AVCodecContext* pointer;

        public CodecContext(Codec codec)
        {
            this.pointer = ffmpeg.avcodec_alloc_context3(codec.Pointer);
            
            Codec = codec;
        }


        public AVCodecContext* Pointer => pointer;

        public Codec Codec { get; }

        // MaxBFrames
        // QuantyFactor
        // FrameStategry
        // QuantyOffset
        // HasBFrames

        public BitRate? BitRate
        {
            get => new BitRate(pointer->bit_rate);
            set => pointer->bit_rate = value.Value.Value;
        }

        public BitRate? BitrateTolerance
        {
            get => new BitRate(pointer->bit_rate_tolerance);
            set => pointer->bit_rate_tolerance = (int)value.Value.Value;
        }

        public Rational TimeBase
        {
            get => new Rational(pointer->time_base.num, pointer->time_base.den);
        }

        #region Audio

        public int SampleRate
        {
            get => pointer->sample_rate;
            set => pointer->sample_rate = value;
        }

        public virtual SampleFormat SampleFormat { get; set; }

        public virtual int ChannelCount
        {
            get => pointer->channels;
            set => pointer->channels = value;
        }

        public virtual ChannelLayout ChannelLayout
        {
            get => (ChannelLayout)pointer->channel_layout;
            set => pointer->channel_layout = (ulong)value;
        }

        #endregion

        #region Image / Video

        public ColorSpace ColorSpace  { get; }

        public PixelFormat PixelFormat { get; }

        // ColorPrimarties

        // ColorRange
        
        // BlockAlign


        public int Width { get; }

        public int Height { get; }

        public int CodecWidth { get; }

        public int CodecHeight { get; }

        #endregion
        
        public void Dispose()
        {
            fixed (AVCodecContext** c = &pointer)
            {
                ffmpeg.avcodec_free_context(c);
            }
        }
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
