namespace Carbon.Media.Codecs
{
    public sealed class HevcEncodingOptions : VideoEncodingParameters
    {
        public HevcPreset? Preset { get; set; }

        public HevcProfile? Profile { get; set; }

        public HevcTuning? Tuning { get; set; }
    }
}