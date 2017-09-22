using System;

namespace Carbon.Media.Codecs
{
    public class OpusEncoder : Encoder
    {
        public override CodecId Id => CodecId.Opus;
    }

    public class OpusEncoderOptions
    {
        public BitRate BitRate { get; set; }

        // Note: delays lower then 20ms will reduce quality
        public TimeSpan Delay { get; set; }
    }
}