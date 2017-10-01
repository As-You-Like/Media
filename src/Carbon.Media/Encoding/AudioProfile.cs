using System;

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
            #region Preconditions

            if (string.IsNullOrEmpty(codec))
                throw new ArgumentException("Required", nameof(codec));

            if (sampleRate != null && sampleRate.Value <= 0)
                throw new ArgumentOutOfRangeException("Must be > 0", sampleRate.Value, nameof(sampleRate));

            #endregion

            Codec        = codec;
            BitRate      = bitRate;
            SampleFormat = sampleFormat;
            SampleRate   = sampleRate;
        }

        public string Codec { get; }

        public BitRate BitRate { get; }

        public SampleFormat SampleFormat { get; }

        // 0...48000
        public int? SampleRate { get; }        
    }
}

// Bitrate              // -b:a
// Codec                // -acodec
// Audio Frequency      // -af
// Audio Quality        // -aq