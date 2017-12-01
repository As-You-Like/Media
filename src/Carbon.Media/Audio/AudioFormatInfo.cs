using System;

namespace Carbon.Media
{
    public class AudioFormatInfo : IEquatable<AudioFormatInfo>
    {
        private readonly SampleFormatInfo a;

        public AudioFormatInfo(
            SampleFormat sampleFormat, 
            ChannelLayout channelLayout, 
            int sampleRate)
        {
            #region Preconditions

            if (sampleFormat == SampleFormat.Unknown)
                throw new ArgumentException("Must not be unknown", nameof(sampleFormat));

            if (sampleRate <= 0)
                throw new ArgumentException("Must be > 0", nameof(sampleRate));

            if (channelLayout == default)
                throw new ArgumentException("Must not be unknown", nameof(channelLayout));

            #endregion

            SampleFormat  = sampleFormat;
            SampleRate    = sampleRate;
            ChannelLayout = channelLayout;

            a = SampleFormatInfo.Get(sampleFormat);
        }
        
        // bitCount, isPlanar, ..
        public SampleFormat SampleFormat { get; }
        
        public int SampleRate { get; }
        
        public ChannelLayout ChannelLayout { get; }
        
        public int ChannelCount => ChannelLayout.GetChannelCount();

        #region Helpers

        public int BitsPerSample => a.BitCount;

        public bool IsPlanar => a.IsPlanar;
        
        public int LineCount => a.IsPlanar ? ChannelCount : 1; // PlaneCount?

        public int LineSize => a.IsPlanar ? (BitsPerSample >> 3) : (BitsPerSample >> 3) * ChannelCount;

        #endregion

        public override string ToString()
        {
            return string.Join(" ", SampleFormat, ChannelLayout, SampleRate);
        }

        #region Equality

        public bool Equals(AudioFormatInfo other) =>
            SampleFormat  == other.SampleFormat &&
            SampleRate    == SampleRate &&
            ChannelLayout == ChannelLayout;

        #endregion
    }
}

/// 8,000 Hz     : Telephone
/// 44,100 Hz    : Audio CD, most popular MPEG-1 (VCD, SVCD, MP3) sampling rate
/// 48,000 Hz    : TV, DVD, and films. 
/// 96,000 Hz    : DVD-Audio, BD-ROM (Blu-ray Disc)/HD-DVD audio tracks
/// 192,000 Hz   : DVD-Audio, BD-ROM (Blu-ray Disc)/HD-DVD audio tracks
/// 2,822,400 Hz : SACD
// Channels { L, R, C }