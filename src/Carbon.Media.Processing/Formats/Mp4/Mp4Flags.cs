using System;

namespace Carbon.Media.Formats
{
    [Flags]
    public enum Mp4Flags
    {
        // Start a new fragment at each video keyframe
        FragKeyFrame    = 1 << 0,
        FragCustom      = 1 << 1,
        EmptyMoov       = 1 << 2,
        SeperateMoof    = 1 << 3,
        FastStart       = 1 << 4,
        RtphHint        = 1 << 5,
        DisableChpl     = 1 << 6,
        OmitTfhdOffset  = 1 << 7,
        DefaultBaseMoof = 1 << 8
    }
}