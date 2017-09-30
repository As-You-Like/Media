namespace Carbon.Media.Codecs
{
    public abstract class AlacDecoder : AudioDecoder
    {
        public override CodecId Id => CodecId.Alac;
    }
}