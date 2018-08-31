namespace Carbon.Media.Codecs
{
    public class AudioEncodingParameters
    {
        public BitRate? BitRate { get; set; }

        public ChannelLayout ChannelLayout { get; set; } = ChannelLayout.Stereo;

        public SampleFormat SampleFormat { get; set; } = SampleFormat.F32p;

        public int SampleRate { get; set; } = 44100;

        public AudioFormatInfo GetFormatInfo()
        {
            return new AudioFormatInfo(
                sampleFormat  : SampleFormat,
                channelLayout : ChannelLayout,
                sampleRate    : SampleRate
            );
        }
    }
}