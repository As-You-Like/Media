using FFmpeg.AutoGen;

namespace Carbon.Media.Codecs
{
    public unsafe class AudioDecoder : Decoder
    {
        public AudioDecoder(CodecId id)
            : base(id) { }

        public AudioDecoder(AVCodecContext* context)
            : base(context) { }


        public AudioFormatInfo GetFormat()
        {
            return new AudioFormatInfo(Context.SampleFormat, Context.ChannelLayout, Context.SampleRate);
        }
    }
}