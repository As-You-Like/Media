using System;

namespace Carbon.Media.Codecs
{
    public abstract class AacDecoder : AudioDecoder
    {
        public override CodecId Id => CodecId.Aac;
    }
}