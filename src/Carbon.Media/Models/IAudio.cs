using System;

namespace Carbon.Media
{
    public interface IAudio
    {
        ICodec Codec { get; }

        TimeSpan? Duration { get; }

        int ChannelCount { get; }

        ChannelLayout ChannelLayout { get; }

        SampleFormat SampleFormat { get; }

        int SampleRate { get; } 
    }
}