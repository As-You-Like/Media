using System;

namespace Carbon.Media
{
    public interface IAudioInfo
    {
        int ChannelCount { get; }

        CodecInfo Codec { get; }

        TimeSpan Duration { get; }

        /// <summary>
        /// The sampling rate defines the number of samples per second
        /// taken from a continuous signal to make a discrete signal.
        /// Measured in hertz (Hz), or samples per second
        /// 8,000 Hz     : Telephone
        /// 44,100 Hz    : Audio CD, most popular MPEG-1 (VCD, SVCD, MP3) sampling rate
        /// 48,000 Hz    : TV, DVD, and films. 
        /// 96,000 Hz    : DVD-Audio, BD-ROM (Blu-ray Disc)/HD-DVD audio tracks
        /// 192,000 Hz   : DVD-Audio, BD-ROM (Blu-ray Disc)/HD-DVD audio tracks
        /// 2,822,400 Hz : SACD
        /// </summary>
        int SampleRate { get; }
        
        // The format determines the sample bit count & whether it is planal
        SampleFormat Format { get; }
        
        ChannelLayout ChannelLayout { get; }
    }

    // Channels { L, R, C }
}