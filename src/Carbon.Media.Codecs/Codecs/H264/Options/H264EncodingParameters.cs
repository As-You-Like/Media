namespace Carbon.Media.Codecs
{
    public sealed class H264EncodingParameters : VideoEncodingParameters
    {
        public EntropyEncoding EntropyCoder { get; set; }

        public H264MotionEstimationMethod MotionEstimationMethod { get; set; }

        public H264Profile Profile { get; set; }

        public Rational? TimeBase { get; set; }
        
        // QuantitizerScale
        // QuantizerCurveBlur
        // ReferenceFrames
        // SceneChangeDetectionThreshhold
    }
}