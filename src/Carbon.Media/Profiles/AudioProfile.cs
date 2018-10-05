using System;
using System.Runtime.Serialization;

namespace Carbon.Media
{
    public class AudioProfile
    {
        public AudioProfile(
            string codec, 
            BitRate bitRate,
            SampleFormat sampleFormat = default, 
            int? sampleRate = null)
        {
            if (string.IsNullOrEmpty(codec))
                throw new ArgumentException("Required", nameof(codec));

            if (sampleRate != null && sampleRate.Value <= 0)
            {
                throw new ArgumentOutOfRangeException("Must be > 0", sampleRate.Value, nameof(sampleRate));
            }

            Codec        = codec;
            BitRate      = bitRate;
            SampleFormat = sampleFormat;
            SampleRate   = sampleRate;
        }

        [DataMember(Name = "codec", Order = 1)]
        public string Codec { get; }

        [DataMember(Name = "bitRate", Order = 2)]
        public BitRate BitRate { get; }

        [DataMember(Name = "sampleFormat", Order = 3)]
        public SampleFormat SampleFormat { get; }

        // 0...48000
        [DataMember(Name = "sampleRate", Order = 4)]
        public int? SampleRate { get; }        
    }
}

// Bitrate          | -b:a
// Codec            | -acodec
// Audio Frequency  | -af
// Audio Quality    | -aq