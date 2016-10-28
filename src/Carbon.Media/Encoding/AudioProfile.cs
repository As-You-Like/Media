using System.ComponentModel.DataAnnotations;

namespace Carbon.Media
{
    public class AudioProfile
    {
        // audio_bitrate_in_kbps
        public int Bitrate { get; set; }

        // TODO: Channels

        public MediaCodec Codec { get; set; }

        [Range(0, 48000)]
        public int? SampleRate { get; set; }

        [Range(0, 32)]
        public int? BitsPerSample { get; set; }
    }
}