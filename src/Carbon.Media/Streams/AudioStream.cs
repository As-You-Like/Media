namespace Carbon.Media
{
    public class AudioStream : MediaStream
    {
        public AudioStream(int streamIndex, ICodec codec, SampleFormat format, int sampleRate)
            : base(streamIndex, codec)
        {
            Format = format;
            SampleRate = sampleRate;
        }

        // bitcount and planar can be determined from the format
        public SampleFormat Format { get; }

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

        public int ChannelCount { get; set; }

        public ChannelLayout ChannelLayout { get; set; }

        /// <summary>
        /// framesize?
        /// </summary>
        public int SamplesPerChannel { get; set; }

        public override MediaStreamType Type => MediaStreamType.Audio;
    }
}

// Channels { L, R, C }