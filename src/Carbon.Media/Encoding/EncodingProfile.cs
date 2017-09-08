namespace Carbon.Media
{
    public class EncodingProfile
    {
        public EncodingProfile(ContainerId container, AudioProfile audio, VideoProfile video)
        {
            Container = container;
            Audio     = audio;
            Video     = video;
        }

        public ContainerId Container { get; }
        
        public AudioProfile Audio { get; }

        public VideoProfile Video { get; }
    }
}