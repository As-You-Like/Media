namespace Carbon.Media.Codecs.Resampling
{
    public class ResamplerParameters
    {
        public SampleFormat InSampleFormat { get; set; }

        public ChannelLayout InChannelLayout { get; set; }

        public int InSampleRate { get; set; }

        public SampleFormat OutSampleFormat { get; set; }

        public ChannelLayout OutChannelLayout { get; set; }

        public int OutSampleRate { get; set; }
    }
}
