namespace Carbon.Media
{
    public class AudioFrame : Frame
    {
        public AudioFrame(IBuffer data)
            : base(data)
        {
        }

        /// <summary>
        /// The size of each plane
        /// </summary>
        public int Stride { get; set; }

        public SampleFormat Format { get; }

        public int ChannelCount { get; set; }

        public ChannelLayout ChannelLayout { get; set; }

        /// <summary>
        /// Audio sample count (per channel)
        /// </summary>
        public int SampleCount { get; set; }

        // Duration?

    }
}
