using System;

namespace Carbon.Media
{
    [Flags]
    public enum ColorComponent : byte
    {
        Unknown = 0,

        R       = 1, // Red
        G       = 2, // Green
        B       = 3, // Blue
        A       = 4, // Alpha
        Y       = 5, // Luma
        U       = 6, // Alias for Cb
        V       = 7, // Alias for Cr

        Cyan    = 10, // Cyan
        Magenta = 11, // Magenta
        Yellow  = 12, // Yellow
        Key     = 13, // Key (black)
    }
}
