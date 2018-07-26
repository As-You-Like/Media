using System;

namespace Carbon.Media.Codecs
{
    public sealed class OpusEncodingParameters : AudioEncodingParameters
    {
        public OpusEncodingParameters()
        {
            this.SampleFormat = SampleFormat.Int16; // default to Int16
            this.SampleRate = 48000;
        }

        // Note: delays lower then 20ms will reduce quality
        public TimeSpan Delay { get; set; }
    }
}