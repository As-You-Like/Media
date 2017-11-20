namespace Carbon.Media.Codecs
{
    public class Vp9EncoderOptions : VideoEncodingParameters
    {  
        public int MaximiumKeyframeDistance { get; set; }

        public Vp9Quality Quality { get; set; }

        // undershoot
        // overshoot

        // skipthreshhold
        // maxRate
    }
}