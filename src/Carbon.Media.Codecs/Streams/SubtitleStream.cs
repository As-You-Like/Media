using FFmpeg.AutoGen;

namespace Carbon.Media
{
    public unsafe sealed class SubtitleStream : MediaStream
    {
        internal SubtitleStream(AVStream* pointer)
            : base(pointer) { }

        public override MediaStreamType Type => MediaStreamType.Subtitle;
    }
}