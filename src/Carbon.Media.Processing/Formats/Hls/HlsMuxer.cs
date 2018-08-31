namespace Carbon.Media.Formats
{
    public sealed class HlsMuxer : Muxer
    {
        private readonly HslMuxerParamaters options;

        public HlsMuxer(HslMuxerParamaters options)
             : base(FormatId.Hls)
        {
            this.options = options;
        }
    }
}