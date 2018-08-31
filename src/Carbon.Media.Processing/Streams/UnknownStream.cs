using FFmpeg.AutoGen;

namespace Carbon.Media
{
    public unsafe sealed class UnknownStream : MediaStream
    {
        internal UnknownStream(AVStream* pointer)
            : base(pointer) { }

        public override MediaStreamType Type => MediaStreamType.Unknown;
    }
}
