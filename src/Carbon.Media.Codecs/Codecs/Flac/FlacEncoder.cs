using System;

namespace Carbon.Media.Codecs
{
    public class FlacEncoder : Encoder
    {
        private readonly AacEncoderOptions options;

        public FlacEncoder(AacEncoderOptions options)
        {
            this.options = options ?? throw new ArgumentNullException(nameof(options));
        }

        public override CodecId Id => CodecId.Flac;
    }
}