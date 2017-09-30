namespace Carbon.Media
{
    public class AudioStream : MediaStream
    {
        public AudioStream(
            int index, 
            ICodec codec,
            int channelCount,
            ChannelLayout channelLayout, 
            SampleFormat sampleFormat,
            int sampleRate)
            : base(index, codec)
        {
            ChannelCount  = channelCount;
            ChannelLayout = channelLayout;
            SampleFormat  = sampleFormat;
            SampleRate    = sampleRate;
        }

        public SampleFormat SampleFormat { get; } 

        /// <summary>
        /// The sampling rate defines the number of samples per second
        /// taken from a continuous signal to make a discrete signal.
        /// Measured in hertz (Hz), or samples per second
        /// 8,000 Hz     : Telephone
        /// 44,100 Hz    : Audio CD, most popular MPEG-1 (VCD, SVCD, MP3) sampling rate
        /// 48,000 Hz    : TV, DVD, and films. 
        /// 96,000 Hz    : DVD-Audio, BD-ROM (Blu-ray Disc)/HD-DVD audio tracks
        /// 192,000 Hz   : DVD-Audio, BD-ROM (Blu-ray Disc)/HD-DVD audio tracks
        /// 2,822,400 Hz : SACD
        /// </summary>
        public int SampleRate { get; }

        public int ChannelCount { get; }

        public ChannelLayout ChannelLayout { get; }

        /// <summary>
        /// framesize?
        /// </summary>
        // public int SamplesPerChannel { get; set; }

        // BlockAlignment ? 

        public override MediaType Type => MediaType.Audio;
    }
}

// Channels { L, R, C }