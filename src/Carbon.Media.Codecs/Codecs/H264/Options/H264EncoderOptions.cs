namespace Carbon.Media.Codecs
{
    public class H264EncoderOptions : VideoEncodingParameters
    {
        public EntropyCoder EntropyCoder { get; set; }

        public H264MotionEstimationMethod MotionEstimationMethod { get; set; }

        public H264Profile Profile { get; set; }

        public Rational? TimeBase { get; set; }
        
        // QuantitizerScale
        // QuantizerCurveBlur
        // ReferenceFrames
        // SceneChangeDetectionThreshhold
    }
}
