using System;

namespace Carbon.Media
{
    public unsafe class AudioFrame : Frame
    {
        public AudioFrame(Buffer data, SampleFormat format)
        {
            Buffer = data ?? throw new ArgumentNullException(nameof(data));
            Format = format;
        }

        public Buffer Buffer { get; }

        public virtual int Stride { get; set; }

        public virtual SampleFormat Format { get; }

        public int ChannelCount => pointer->channels;

        public virtual ChannelLayout ChannelLayout { get; set; }

        /// <summary>
        /// Audio sample count (per channel)
        /// </summary>
        public int SampleCount => pointer->nb_samples;

        public new void Dispose()
        {
            Buffer.Dispose();
        }
    }
}
