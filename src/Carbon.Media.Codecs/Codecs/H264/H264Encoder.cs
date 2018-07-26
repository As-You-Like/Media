using System;

namespace Carbon.Media.Codecs
{
    public sealed class H264Encoder : VideoEncoder
    {
        private readonly H264EncoderOptions options;

        public H264Encoder(H264EncoderOptions options)
             : base(CodecId.H264)
        {
            this.options = options ?? throw new ArgumentNullException(nameof(options));
        }
    }
}