using System.ComponentModel.DataAnnotations;

namespace Carbon.Media
{
    public class AudioProfile
    {
        public BitRate Bitrate { get; set; }

        public string Codec { get; set; }

        [Range(0, 48000)]
        public int? SampleRate { get; set; }
        
        [Range(0, 32)]
        public SampleFormat SampleFormat { get; set; }
    }
}