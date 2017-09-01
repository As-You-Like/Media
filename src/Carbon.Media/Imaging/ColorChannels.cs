using System;

namespace Carbon.Media
{
    public static class ColorChannels
    {
        public static readonly ColorChannel[] BGR  = { ColorChannel.B, ColorChannel.G, ColorChannel.R };
        public static readonly ColorChannel[] BGRA = { ColorChannel.B, ColorChannel.G, ColorChannel.R, ColorChannel.A };
        public static readonly ColorChannel[] RGB  = { ColorChannel.R, ColorChannel.G, ColorChannel.B };
        public static readonly ColorChannel[] RGBA = { ColorChannel.R, ColorChannel.G, ColorChannel.B, ColorChannel.A };
        public static readonly ColorChannel[] K    = { ColorChannel.K };

        public static readonly ColorChannel[] CMYK = { ColorChannel.C, ColorChannel.M, ColorChannel.Y, ColorChannel.K };
        public static readonly ColorChannel[] CMYKA = { ColorChannel.C, ColorChannel.M, ColorChannel.Y, ColorChannel.K };

    }

    [Flags]
    public enum ColorChannel : byte
    {
        Unknown = 0,

        R = 1,
        G = 2,
        B = 4,
        A = 8,
        C = 16,     // cyan
        M = 32,     // magenta
        Y = 64,     // yellow
        K = 128,    // key (black)

        // RGB = R | G | B,
        // RGBA = R | G | B | A,
        // CMYK = C | M | Y | K,
        // CMYKA = C | M | Y | K | A
    }
}
