using System;

namespace Carbon.Media.Codecs
{
    public abstract class AacEncoder : AudioEncoder
    {
        private readonly AacEncoderOptions options;

        public AacEncoder(AacEncoderOptions options)
        {
            this.options = options ?? throw new ArgumentNullException(nameof(options));
        }

        public override CodecId Id => CodecId.Aac;
    }
}