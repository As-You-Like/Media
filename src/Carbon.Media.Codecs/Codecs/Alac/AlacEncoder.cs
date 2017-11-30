namespace Carbon.Media.Codecs
{
    public abstract class AlacEncoder : AudioEncoder
    {
        public AlacEncoder()
            : base(CodecId.Alac) { }
    }
}