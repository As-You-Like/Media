namespace Carbon.Media
{
    public class EncodingProfile
    {
        public EncodingProfile(MediaContainerType container, AudioProfile audio, VideoProfile video)
        {
            Container = container;
            Audio     = audio;
            Video     = video;
        }

        public MediaContainerType Container { get; }
        
        public AudioProfile Audio { get; }

        public VideoProfile Video { get; }
    }
}