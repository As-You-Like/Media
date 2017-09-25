namespace Carbon.Media
{
    public class AudioProfile
    {
        public BitRate Bitrate { get; set; }

        public string Codec { get; set; }

        // [Range(0, 48000)]
        public int? SampleRate { get; set; }
        
        public SampleFormat SampleFormat { get; set; }

        // ChannelCount
    }
}

// Bitrate              // -b:a
// Codec                // -acodec
// Audio Frequency      // -af
// Audio Quality        // -aq