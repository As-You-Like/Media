namespace Carbon.Media.Codecs
{
    public class AacEncoderOptions : AudioEncodingParameters
    {
        public AacQuality? Quality { get; set; }

        public int Cutoff { get; set; }
        
        public AacProfile Profile { get; set; }
    }
}