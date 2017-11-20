using System;

namespace Carbon.Media.Codecs
{
    public class OpusEncodingParameters
    {
        // ChannelCount

        public BitRate? BitRate { get; set; }

        // Note: delays lower then 20ms will reduce quality
        public TimeSpan Delay { get; set; }
    }
}