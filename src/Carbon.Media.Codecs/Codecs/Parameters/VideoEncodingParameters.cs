namespace Carbon.Media.Codecs
{
    public class VideoEncodingParameters
    {
        /// <summary>
        /// Average bitrate
        /// </summary>
        public BitRate? BitRate { get; set; }

        public BitRate? MinimumBitRate { get; set; }

        public BitRate? MaximumBitRate { get; set; }
    }
}