using System;

namespace Carbon.Media
{
    [Flags]
    public enum ColorComponent : byte
    {
        Unknown = 0,

        R       = 1,
        G       = 2,
        B       = 3,
        A       = 4,
        Cb      = 5, // Blur chroma difference
        Cr      = 6, // Red chroma difference
        Y       = 7, // Luma
        U       = 8,
        V       = 9,

        Cyan    = 10, // cyan
        Magenta = 11, // magenta
        Yellow  = 12, // yellow
        Key     = 13, // key (black)
    }
}
