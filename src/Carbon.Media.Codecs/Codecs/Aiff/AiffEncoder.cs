namespace Carbon.Media.Codecs
{
    public abstract class AiffEncoder : AudioEncoder
    {
        public AiffEncoder()
            : base(CodecId.Unknown) { }
    }
}