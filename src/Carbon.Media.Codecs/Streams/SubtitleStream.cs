using FFmpeg.AutoGen;

namespace Carbon.Media
{
    public unsafe sealed class SubtitleStream : MediaStream
    {
        public SubtitleStream(AVStream* pointer)
            : base(pointer) { }

        public override MediaType Type => MediaType.Text;
    }
}