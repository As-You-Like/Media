using System;

namespace Carbon.Media
{
    public class AudioProfile
    {
        public AudioProfile() { }

        public AudioProfile(string codec, BitRate bitRate)
        {
            Codec    = codec ?? throw new ArgumentNullException(nameof(codec));
            BitRate  = bitRate;
        }

        public BitRate BitRate { get; set; }

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