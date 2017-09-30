namespace Carbon.Media.Containers
{
    public class HlsMuxer : Muxer
    {
        private readonly HlsMuxerOptions options;

        public HlsMuxer(HlsMuxerOptions options)
        {
            this.options = options;
        }
    }

    public class HlsMuxerOptions
    {

    }
}