using FFmpeg.AutoGen;

namespace Carbon.Media.Codecs
{
    public unsafe class VideoDecoder : Decoder
    {
        public VideoDecoder(CodecId id)
            : base(id) { }

        public VideoDecoder(AVCodecContext* context)
            : base(context) { }
    }
}