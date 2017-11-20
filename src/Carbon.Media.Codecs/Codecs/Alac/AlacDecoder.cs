namespace Carbon.Media.Codecs
{
    public abstract class AlacDecoder : AudioDecoder
    {
        public AlacDecoder()
            : base(CodecId.Alac) { }
    }
}