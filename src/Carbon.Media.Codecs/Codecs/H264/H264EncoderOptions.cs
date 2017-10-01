namespace Carbon.Media.Codecs
{
    public class H264EncoderOptions
    {
        /// <summary>
        /// Average bitrate
        /// </summary>
        public BitRate BitRate { get; set; }

        public BitRate? MaxBitRate { get; set; }

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
