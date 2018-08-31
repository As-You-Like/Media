namespace Carbon.Media.Codecs
{
    public abstract class Mp3Decoder : AudioDecoder
    {
        public Mp3Decoder()
            : base(CodecId.Mp3) { }
    }
}