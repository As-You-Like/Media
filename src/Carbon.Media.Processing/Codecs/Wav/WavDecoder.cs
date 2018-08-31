namespace Carbon.Media.Codecs
{
    public abstract class WavDecoder : AudioDecoder
    {
        public WavDecoder()
            : base(CodecId.AdpcmImaWav) { }
    }
}