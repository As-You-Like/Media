using Carbon.Media.IO;

namespace Carbon.Media.Formats
{
    public sealed class Mp4Muxer : Muxer
    {
        private readonly Mp4MuxerOptions options;

        public Mp4Muxer(IOContext output, Mp4MuxerOptions options)
            : base(FormatId.Mov)
        {
            this.options = options;
        }

        // StartNewFragment (av_write_frame(ctx, NULL))
    }
}

/// Mp4
/// Ismv