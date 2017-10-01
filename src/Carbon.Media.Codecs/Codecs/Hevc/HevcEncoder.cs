namespace Carbon.Media.Codecs
{
    public class HevcEncoder : Encoder
    {
        public override CodecId Id => CodecId.Hevc;

        private readonly HevcEncodingOptions options;

        public HevcEncoder(HevcEncodingOptions options)
        {
            this.options = options;
        }
    }
}
