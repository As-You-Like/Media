using System;

namespace Carbon.Media.Codecs
{
    public class H264Encoder : VideoEncoder
    {
        private readonly H264EncoderOptions options;

        public H264Encoder(H264EncoderOptions options)
        {
            this.options = options ?? throw new ArgumentNullException(nameof(options));
        }

        public override CodecId Id => CodecId.H264;
    }
}
