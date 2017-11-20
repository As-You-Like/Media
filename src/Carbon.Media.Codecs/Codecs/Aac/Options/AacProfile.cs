namespace Carbon.Media.Codecs
{
    public enum AacProfile
    {
        Main = 1,

        /// <summary>
        /// Low Complexity
        /// </summary>
        LC   = 2,
        SSR  = 3,

        /// <summary>
        /// Long Term Prediction
        /// </summary>
        LTP  = 4, 

        /// <summary>
        /// High Efficiency
        /// </summary>
        HE   = 5,
        HEv2 = 6,


        /// <summary>
        /// Low Delay
        /// </summary>
        LD   = 7,

        /// <summary>
        /// Enhanced Low Delay
        /// </summary>
        ELD  = 8
    }
}