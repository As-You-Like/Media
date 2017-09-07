namespace Carbon.Media
{
    public enum ChannelLayout
    {
        FrontLeft           = 1 << 1,
        FrontRight          = 1 << 2,
        FrontCenter         = 1 << 3,
        LowFrequency        = 1 << 4,
        BackLeft            = 1 << 5,
        BackRight           = 1 << 6,
        FrontLeftOfCenter   = 1 << 7,
        FrontRightOfCenter  = 1 << 8,
        BackCenter          = 1 << 9,
        SideLeft            = 1 << 10,
        SideRight           = 1 << 11,
        TopCenter           = 1 << 12,
        TopFrontLeft        = 1 << 13,
        TopFrontCenter      = 1 << 14,
        TopFrontRight       = 1 << 15,
        TopBackLeft         = 1 << 16,
        TopBackCenter       = 1 << 17,
        TopBackRight        = 1 << 18,
        DownmixLeft         = 1 << 19,
        DownmixRight        = 1 << 20,
        WideLeft            = 1 << 21,
        WideRight           = 1 << 22,
        SurroundDirectLeft  = 1 << 23,
        DirectDirectRight   = 1 << 24,
        LowFrequency2       = 1 << 25,

        Mono   = FrontCenter,
        Stereo = FrontLeft | FrontRight,
        _2P1   = Stereo | LowFrequency,                            // 2.1
        _3P0   = Stereo | FrontCenter,                             // 3.0
        _3P1   = Stereo | FrontCenter | LowFrequency,              // 3.1
        _4P0   = Stereo | FrontCenter | BackCenter,                // 4.0
        _4P1   = Stereo | FrontCenter | BackCenter | LowFrequency, // 4.1
        _5P0   = Stereo | FrontCenter | SideLeft | SideRight,      // 5.0
        _5P1   = _5P0 | LowFrequency,                              // 5.1
        _7P0   = _5P0 | BackLeft | BackRight,
        _2_2   = Stereo | SideLeft | SideRight,
        Quad   = Stereo | BackLeft | BackRight,

        Downmix = DownmixLeft | DownmixRight
    }

    // Sync w/ FFMPEG?
}
