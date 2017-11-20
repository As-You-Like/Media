namespace Carbon.Media.Codecs
{
    public class AudioEncodingParameters
    {
        public BitRate? BitRate { get; set; }
        
        public ChannelLayout ChannelLayout { get; set; }
        
        public SampleFormat SampleFormat { get; set; }

        public int SampleRate { get; set; }
    }
}