namespace Carbon.Media.Codecs
{
    public enum CodecCapabilities : long
    {
        None                 = 0,
        Dr1                  = 1 << 1,
        Truncated            = 1 << 3,  // 8
        HardwareAcceleration = 1 << 4,  // 16
        /// Encoder or decoder requires flushing with NULL input at the end in order to give the complete and correct output.
        Delay                = 1 << 5,  // 32
        Subframes            = 1 << 8, 
        Experimental         = 1 << 9,
        FrameThreading       = 1 << 12,
        IntraOnly            = 0x40000000,
        Lossless             = 0x80000000, // 2147483648
    }
}