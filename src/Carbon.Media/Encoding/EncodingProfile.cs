namespace Carbon.Media
{
    public class EncodingProfile
    {
        public EncodingProfile(FormatId format, AudioProfile audio, VideoProfile video)
        {
            Format = format;
            Audio  = audio;
            Video  = video;
        }

        public FormatId Format { get; }
        
        public AudioProfile Audio { get; }

        public VideoProfile Video { get; }
    }
}