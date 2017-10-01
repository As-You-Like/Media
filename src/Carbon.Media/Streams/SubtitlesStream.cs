namespace Carbon.Media.Streams
{
    public class SubtitlesStream : MediaStream
    {
        public SubtitlesStream(
          int index,
          ICodec codec)
            : base(index, codec)
        {
           
        }

        public override MediaType Type => MediaType.Subtitles;
    }
}
