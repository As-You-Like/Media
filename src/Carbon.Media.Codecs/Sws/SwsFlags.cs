using System;

namespace Carbon.Media
{
    [Flags]
    public enum SwsFlags
    {
        FastBilinear = 1,
        Bilinear = 2,
        Bicubic = 4,
        X = 8,
        Point = 0x10,
        Area = 0x20,
        Bicublin = 0x40,
        Gauss = 0x80,
        Sinc = 0x100,
        Lanczos = 0x200,
        Spline = 0x400,
        SrcVChrDropMask = 0x30000,
        SrcVChrDropShift = 16,
        ParamDefault = 123456,
        PrintInfo = 0x1000,
        FullChrHInt = 0x2000,
        FullChrHInp = 0x4000,
        DirectBGR = 0x8000,
        AccurateRnd = 0x40000,
        BitExact = 0x80000,
        ErrorDiffusion = 0x800000
    }
}