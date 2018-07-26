namespace Carbon.Media.Codecs
{
    public sealed class AacEncodingParameters : AudioEncodingParameters
    {
        public AacEncodingParameters() { }

        public AacEncodingParameters(AudioFormatInfo format)
        {
            ChannelLayout = format.ChannelLayout;
            SampleFormat  = format.SampleFormat;
            SampleRate    = format.SampleRate;
        }

        public AacQuality? Quality { get; set; }

        public int? CutoffFrequency { get; set; }
        
        public AacProfile Profile { get; set; }

        public AacCoder? Coder { get; set; }

        internal AvDictionary ToOptions()
        {
            // CBR mode = -b:a
            // VBR

            // Constant Bitrate
            // -b:a

            var options = new AvDictionary();

            if (BitRate != null)
            {
                // Activate CBR mode
                // defaults to 128kbs
                options.Set("b", BitRate.Value.Value); // in bits per second

                // setting this activated the bitrate mode
            }
            else if (Quality != null)
            {
                // options.Set("q", (int)Quality.Value);
            }

            if (CutoffFrequency != null)
            {
                // If unspecified will allow the encoder to dynamically adjust the cutoff to improve clarity on low bitrates.
                options.Set("cutoff", CutoffFrequency.Value);
            }

            if (Coder != null)
            {
                options.Set("aac_coder", Coder.ToString().ToLower());
            }

            // aac_ms
            // aac_is
            // aac_pns
            // aac_tns
            // aac_ltp
            // aac_pred

   
            switch (Profile)
            {
                case AacProfile.LC   : options.Set("profile", "aac_low"); break;
                case AacProfile.LTP  : options.Set("profile", "aac_ltp"); break;
                case AacProfile.Main : options.Set("profile", "aac_main"); break;
            }

            return options;
        }
    }

    /*
   
    profile
    Sets the encoding profile, possible values:

    ‘aac_low’
    The default, AAC "Low-complexity" profile. Is the most compatible and produces decent quality.

    ‘mpeg2_aac_low’
    Equivalent to -profile:a aac_low -aac_pns 0. PNS was introduced with the MPEG4 specifications.

    ‘aac_ltp’
    Long term prediction profile, is enabled by and will enable the aac_ltp option. Introduced in MPEG4.

    ‘aac_main’
    Main-type prediction profile, is enabled by and will enable the aac_pred option. Introduced in MPEG2.

    If this option is unspecified it is set to ‘aac_low’.
    */

 


    // Cbr Mode
    // -b:a


    // sample frequencies: 8 - 96 kHz
}
 