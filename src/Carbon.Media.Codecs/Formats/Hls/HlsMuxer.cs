namespace Carbon.Media.Formats
{
    public class HlsMuxer : Muxer
    {
        private readonly HlsMuxerOptions options;

        public HlsMuxer(HlsMuxerOptions options)
        {
            this.options = options;
        }

        public override FormatId Id => FormatId.Hls;
    }

    public class HlsMuxerOptions
    {

    }
}