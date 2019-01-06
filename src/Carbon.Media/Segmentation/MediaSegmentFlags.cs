using System;

namespace Carbon.Media.Segmentation
{
    [Flags]
    public enum MediaSegmentFlags
    {
        None           = 0,
        Initialization = 1 << 0,
    }
}