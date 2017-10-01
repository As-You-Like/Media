namespace Carbon.Media.Formats
{
    public class MovMuxer : Muxer
    {
        private readonly MovMuxerOptions options;

        public MovMuxer(MovMuxerOptions options)
        {
            this.options = options;
        }

        public override FormatId Id => FormatId.Mov;

        // StartNewFragment (av_write_frame(ctx, NULL))
    }
}

/// Mp4
/// Ismv