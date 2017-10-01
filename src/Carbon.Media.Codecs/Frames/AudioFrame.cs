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
        public virtual int Stride { get; set; }

        public virtual SampleFormat Format { get; }

        public virtual int ChannelCount { get; set; }

        public virtual ChannelLayout ChannelLayout { get; set; }

        /// <summary>
        /// Audio sample count (per channel)
        /// </summary>
        public virtual int SampleCount { get; set; }

        // Duration?
    }
}
