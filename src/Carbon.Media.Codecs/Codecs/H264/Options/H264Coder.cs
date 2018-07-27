namespace Carbon.Media.Codecs
{
    public enum H264Coder
    {
        /// <summary>
        /// Enable CABAC.
        /// </summary>
        AC = 1,

        /// <summary>
        /// Enable CAVLC and disable CABAC. It generates the same effect as x264’s --no-cabac option.
        /// </summary>
        VLC = 2
    }
}