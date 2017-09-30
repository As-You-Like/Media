namespace Carbon.Media.Codecs
{
    public class AacEncoderOptions
    {
        public BitRate BitRate { get; set; }

        public int Quality { get; set; }

        public int Cutoff { get; set; }
        
        public string Codec { get; set; }

        public string Profile { get; set; }
    }
}