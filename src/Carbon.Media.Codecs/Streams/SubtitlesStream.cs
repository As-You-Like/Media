using FFmpeg.AutoGen;

namespace Carbon.Media
{
    public unsafe class SubtitlesStream : MediaStream
    {
        public SubtitlesStream(AVStream* pointer)
            : base(pointer)
        {
           
        }

        public override MediaType Type => MediaType.Subtitles;
    }


    public unsafe class UnknownStream : MediaStream
    {
        public UnknownStream(AVStream* pointer)
            : base(pointer)
        {

        }

        public override MediaType Type => MediaType.Unknown;
    }
}
