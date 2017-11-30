using System;

namespace Carbon.Media.Codecs
{
    public class FlacEncoder : Encoder
    {
        private readonly FlacEncodingParameters options;

        public FlacEncoder(FlacEncodingParameters options)
            : base(CodecId.Flac)
        {
            this.options = options ?? throw new ArgumentNullException(nameof(options));
        }
    }
}