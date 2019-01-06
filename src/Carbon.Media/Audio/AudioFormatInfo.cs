using System;
using Carbon.Media.Processing;

namespace Carbon.Media
{
    public class AudioFormatInfo : IEquatable<AudioFormatInfo>
    {
        public AudioFormatInfo(
          SampleFormat sampleFormat,
          int sampleRate,
          ChannelLayout channelLayout)
            : this(sampleFormat, sampleRate, ChannelLayoutHelper.GetChannelCount(channelLayout), channelLayout)
        {
        }

        public AudioFormatInfo(
            SampleFormat sampleFormat,
            int sampleRate,
            int channelCount,
            ChannelLayout channelLayout = default)
        {
            if (sampleFormat == SampleFormat.Unknown)
            {
                throw new ArgumentException("Must not be Unknown", nameof(sampleFormat));
            }

            if (sampleRate <= 0 || sampleRate > Constants.MaxSampleRate)
            {
                throw ExceptionHelper.OutOfRange(nameof(sampleRate), 1, Constants.MaxSampleRate, sampleRate);
            }

            if (channelCount <= 0 || channelCount > Constants.MaxChannelCount)
            {
                throw ExceptionHelper.OutOfRange(nameof(sampleRate), 1, Constants.MaxChannelCount, sampleRate);
            }

            SampleFormat = sampleFormat;
            SampleRate = sampleRate;
            ChannelCount = channelCount;
            ChannelLayout = channelLayout;
        }

        public SampleFormat SampleFormat { get; }

        public int SampleRate { get; }

        public int ChannelCount { get; }

        public ChannelLayout ChannelLayout { get; }

        #region Helpers

        public int BitsPerSample => SampleFormatInfo.Get(SampleFormat).BitCount;

        public bool IsPlanar => SampleFormatHelper.IsPlanar(SampleFormat);

        public int LineCount => IsPlanar ? ChannelCount : 1;

        #endregion

        public int GetLineSize(int sampleCount)
        {
            if (sampleCount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(sampleCount), "Must be > 0");
            }

            var info = SampleFormatInfo.Get(SampleFormat);

            int lineSize = info.IsPlanar ? (info.BitCount >> 3) : (info.BitCount >> 3) * ChannelCount;

            return lineSize * sampleCount;
        }

        public override string ToString() => string.Join(" ", SampleFormat, SampleRate, ChannelCount, ChannelLayout);

        #region Equality

        public bool Equals(AudioFormatInfo other) =>
            SampleFormat == other.SampleFormat &&
            SampleRate == other.SampleRate &&
            ChannelCount == other.ChannelCount &&
            ChannelLayout == other.ChannelLayout;

        #endregion
    }
}

/// 8,000 Hz     : Telephone
/// 44,100 Hz    : Audio CD, most popular MPEG-1 (VCD, SVCD, MP3) sampling rate
/// 48,000 Hz    : TV, DVD, and films. 
/// 96,000 Hz    : DVD-Audio, BD-ROM (Blu-ray Disc)/HD-DVD audio tracks
/// 192,000 Hz   : DVD-Audio, BD-ROM (Blu-ray Disc)/HD-DVD audio tracks
/// 2,822,400 Hz : SACD
/// 
// Channels { L, R, C }