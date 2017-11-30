using FFmpeg.AutoGen;

namespace Carbon.Media
{
    public unsafe sealed class UnknownStream : MediaStream
    {
        public UnknownStream(AVStream* pointer)
            : base(pointer) { }

        public override MediaType Type => MediaType.Unknown;
    }
}
