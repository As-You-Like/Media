namespace Carbon.Media.Codecs
{
    public class Mp3EncodingParameters : AudioEncodingParameters
    {
        internal Options ToOptions()
        {
            // CBR mode = -b:a
            // VBR

            // Constant Bitrate
            // -b:a

            var options = new Options();

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