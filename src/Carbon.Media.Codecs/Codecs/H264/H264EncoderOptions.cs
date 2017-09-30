namespace Carbon.Media.Codecs
{
    public class H264EncoderOptions
    {
        public BitRate BitRate { get; set; }
        
        public EntropyCoder EntropyCoder { get; set; }

        public H264MotionEstimationMethod MotionEstimationMethod { get; set; }

        public string Profile { get; set; }

        // QuantitizerScale
        // QuantizerCurveBlur
        // ReferenceFrames
        // SceneChangeDetectionThreshhold
    }
}
