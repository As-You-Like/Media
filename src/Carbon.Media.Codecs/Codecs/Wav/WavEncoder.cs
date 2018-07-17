namespace Carbon.Media.Codecs
{
    public abstract class WavEncoder : AudioEncoder
    {
        public WavEncoder()
            : base(CodecId.AdpcmImaWav) { }
    }
}