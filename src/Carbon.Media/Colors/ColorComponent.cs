using System;

namespace Carbon.Media
{
    [Flags]
    public enum ColorComponent : byte
    {
        Unknown = 0,

        R = 1,
        G = 2,
        B = 3,
        A = 4,
        C = 5, // cyan
        M = 6, // magenta
        Y = 7, // yellow
        K = 8, // key (black)

        // Y  = 9, // Luma
        Cb = 10, // Blur chrome Difference
        Cr = 11, // Red Chroma difference

        // Y, U, V
    }
}
