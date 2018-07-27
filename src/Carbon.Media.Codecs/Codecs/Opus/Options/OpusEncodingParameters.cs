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

        // NOTE: delays lower then 20ms will reduce quality
        public TimeSpan Delay { get; set; }
        
        internal AvDictionary ToOptions()
        {
            var options = new AvDictionary();
            
            if (BitRate != null)
            {
                options.Set("b", BitRate.Value.Value); // in bits per second
            }

            return options;
        }
    }
}