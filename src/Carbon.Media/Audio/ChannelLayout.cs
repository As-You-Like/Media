using System;

namespace Carbon.Media
{
    [Flags]
    public enum ChannelLayout : long
    {
        Unknown             = 0,
        FrontLeft           = 1 << 0,  // FL
        FrontRight          = 1 << 1,  // FR
        FrontCenter         = 1 << 2,  // FC
        LowFrequency        = 1 << 3,  // LFE
        BackLeft            = 1 << 4,  // BL
        BackRight           = 1 << 5,  // BR
        FrontLeftOfCenter   = 1 << 6,  // FLC
        FrontRightOfCenter  = 1 << 7,  // FRC
        BackCenter          = 1 << 8,  // BC
        SideLeft            = 1 << 9,  // SL
        SideRight           = 1 << 10, // SR
        TopCenter           = 1 << 11, // TC
        TopFrontLeft        = 1 << 12, // TFL
        TopFrontCenter      = 1 << 13, // TFC
        TopFrontRight       = 1 << 14, // TFR
        TopBackLeft         = 1 << 15, // TBL
        TopBackCenter       = 1 << 16, // TBC
        TopBackRight        = 1 << 17, // TBR
        WideLeft            = 1 << 20, // WL
        WideRight           = 1 << 21, // WR
        SurroundDirectLeft  = 1 << 22, // SDL
        DirectDirectRight   = 1 << 23, // SDR
        LowFrequency2       = 1 << 24, // LF2
        DownmixLeft         = 1 << 29, // DL?
        DownmixRight        = 1 << 30, // DR?

        Mono                = FrontCenter,                                             // 1.0 | FC
        Stereo              = FrontLeft | FrontRight,                                  // 2.0 | FL | FR
        _2_1                = Stereo | LowFrequency,                                   // 2.1 | FL | FR | LFE
        _3_0                = Stereo | FrontCenter,                                    // 3.0 | FL | FR | FC
        _3_1                = _3_0 | LowFrequency,                                     // 3.1 | FL | FR | FC | LFE
        _4_0                = _3_0 | BackCenter,                                       // 4.0 | FL | FR | FC | BC
        _4_1                = _4_0 | LowFrequency,                                     // 4.1 | FL | FR | FC | LFE | BC
        _5_0                = _3_0 | SideLeft | SideRight,                             // 5.0 | FL | FR | FC | BL | BR
        _5_1                = _5_0 | LowFrequency,                                     // 5.1 | FL | FR | FC | LFE | BL | BR
        _6_0                = _5_0 | BackCenter,                                       // 6.0 | FL | FR | FC | BC | SL | SR
        _6_1                = _3_0 | LowFrequency | BackCenter | SideLeft | SideRight, // 6.1 | FL | FR | FC | LFE | BC | SL | SR
        _7_0                = _5_0 | BackLeft | BackRight,                             // 7.0 | FL | FR | FC | BL | BR | SL | SR     
        _7_1                = _5_0 | BackLeft | BackRight | LowFrequency,              // 7.1 | FL | FR | FC | LFE | BL | BR | SL | SR
        _2_2                = Stereo | SideLeft | SideRight,                           //     | FL | FR | SL | SR
        Quad                = Stereo | BackLeft | BackRight,                           //     | FL | FR | BL | BR
        Hexagonal           = _6_0,                                                    //     | 
        Octagonal           = _7_0 | BackCenter,                                       //     | FL | FR | FC | BL | BR | BC | SL | SR

        StereoDownmix       = DownmixLeft | DownmixRight                               //     | DL | DR

        // 6.0 front
        // 7.1 wide
        // 7.1 wide back
    }
}