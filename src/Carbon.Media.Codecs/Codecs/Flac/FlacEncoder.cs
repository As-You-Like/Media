using System;

namespace Carbon.Media.Codecs
{
    public class FlacEncoder : Encoder
    {
        private readonly FlacEncoderOptions options;

        public FlacEncoder(FlacEncoderOptions options)
            : base(CodecId.Flac)
        {
            this.options = options ?? throw new ArgumentNullException(nameof(options));
        }
    }
}