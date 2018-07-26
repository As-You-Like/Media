namespace Carbon.Media.Codecs
{
    public sealed class Mp3EncodingParameters : AudioEncodingParameters
    {
        // supported channels (Mono, Stereo)

        internal AvDictionary ToOptions()
        {
            // CBR mode = -b:a
            // VBR

            // Constant Bitrate
            // -b:a

            var options = new AvDictionary();

            // options.Set("codec", "libmp3lame");

            if (BitRate != null)
            {
                // Activate CBR mode
                // defaults to 128kbs
                options.Set("b", BitRate.Value.Value); // in bits per second

                // setting this activated the bitrate mode
            }
            
            return options;
        }
    }
}