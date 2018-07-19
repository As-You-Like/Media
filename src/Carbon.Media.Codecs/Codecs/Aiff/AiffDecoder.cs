namespace Carbon.Media.Codecs
{
    public abstract class AiffDecoder : AudioDecoder
    {
        public AiffDecoder()
            : base(CodecId.Unknown) { }
    }
}