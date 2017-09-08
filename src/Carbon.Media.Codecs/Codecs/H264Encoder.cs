using System;

namespace Carbon.Media.Codecs
{
    public class H264Encoder : Encoder
    {
        private readonly H264EncoderOptions options;

        public H264Encoder(H264EncoderOptions options)
        {
            this.options = options ?? throw new ArgumentNullException(nameof(options));
        }

        public override CodecId Id => CodecId.H264;
    }

    public class H264EncoderOptions
    {
        public BitRate BitRate { get; set; }
        
        public EntropyCoder EntropyCoder { get; set; }

        public MotionEstimationMethod MotionEstimationMethod { get; set; }

        public string Profile { get; set; }

        // QuantitizerScale
        // QuantizerCurveBlur
        // ReferenceFrames
        // SceneChangeDetectionThreshhold
    }

    public enum EntropyCoder
    {
        Ac,
        Vlc
    }
    public enum MotionEstimationMethod
    {
        Dia,
        Epzs,
        Hex,
        Uhm,
        Esa,
        Tesa
    }
}
