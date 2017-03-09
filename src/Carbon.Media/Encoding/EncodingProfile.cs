namespace Carbon.Media
{
    public class EncodingProfile
    {
        public EncodingProfile() { }

        public EncodingProfile(MediaContainerType containerType)
        {
            Container = containerType;
        }

        public MediaContainerType Container { get; set; }

        public AudioProfile Audio { get; set; }

        public VideoProfile Video { get; set; }
    }
}