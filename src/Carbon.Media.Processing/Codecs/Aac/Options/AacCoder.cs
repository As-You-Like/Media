namespace Carbon.Media.Codecs
{
    public enum AacCoder
    {
        /// <summary>
        /// Two loop searching (TLS) method.
        /// </summary>
        TwoLoop = 1,

        /// <summary>
        /// Average noise to mask ratio (ANMR) trellis-based solution.
        /// </summary>
        Anmr = 2,

        /// <summary>
        /// Constant quantizer method.
        /// </summary>
        Fast = 3
    }
}