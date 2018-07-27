using System;

namespace Carbon.Media.Codecs
{
    public class FlacEncoder : Encoder
    {
        private readonly FlacEncodingParameters options;

        public FlacEncoder(FlacEncodingParameters parameters)
            : base(CodecId.Flac)
        {
            this.options = parameters ?? throw new ArgumentNullException(nameof(parameters));
        }
    }
}