using System;

namespace Carbon.Media
{
    public class AudioFrame : Frame
    {
        public AudioFrame(IBuffer data, SampleFormat format)
        {
            Buffer = data ?? throw new ArgumentNullException(nameof(data));
            Format = format;
        }

        public IBuffer Buffer { get; }

        public virtual int Stride { get; set; }

        public virtual SampleFormat Format { get; }

        public virtual int ChannelCount { get; set; }

        public virtual ChannelLayout ChannelLayout { get; set; }

        /// <summary>
        /// Audio sample count (per channel)
        /// </summary>
        public virtual int SampleCount { get; set; }

        public override void Dispose()
        {
            Buffer.Dispose();
        }
    }
}
