namespace Carbon.Media
{
    public class EncodingProfile
    {
        public EncodingProfile() { }

        public EncodingProfile(MediaContainer container)
        {
            Container = container;
        }

        public MediaContainer Container { get; set; }

        public AudioProfile Audio { get; set; }

        public VideoProfile Video { get; set; }
    }
}