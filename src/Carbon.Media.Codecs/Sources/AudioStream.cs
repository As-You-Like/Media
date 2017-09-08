using Carbon.Media.Codecs;

namespace Carbon.Media
{
    public class AudioStream : MediaStream
    {
        public AudioStream(int index, Codec codec)
            : base(index, codec) { }

        public int SampleRate { get; set; }

        public int ChannelCount { get; set; }

        public ChannelLayout ChannelLayout { get; set; }

        /// <summary>
        /// The number of samples per channel
        /// </summary>
        public int FrameSize { get; set; }

        public override MediaStreamType Type => MediaStreamType.Audio;
    }
}
