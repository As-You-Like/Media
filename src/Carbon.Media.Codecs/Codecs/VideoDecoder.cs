using System;
using FFmpeg.AutoGen;

namespace Carbon.Media.Codecs
{
    public unsafe class VideoDecoder : Decoder
    {
        public VideoDecoder(CodecId id)
            : base(id) { }

        public VideoDecoder(AVCodecContext* context)
            : base(context) { }

        public VideoFormatInfo GetFormatInfo()
        {
            return new VideoFormatInfo(Context.PixelFormat, Context.Width, Context.Height);
        }
    }
}