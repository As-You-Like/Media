using System;

namespace Carbon.Media.Codecs
{
    public sealed class H264Encoder : VideoEncoder
    {
        private readonly H264EncodingParameters options;

        public H264Encoder(H264EncodingParameters paramaters)
             : base(CodecId.H264)
        {
            this.options = paramaters ?? throw new ArgumentNullException(nameof(paramaters));
        }
    }
}