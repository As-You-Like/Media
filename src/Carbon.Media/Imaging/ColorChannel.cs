namespace Carbon.Media
{
    public readonly struct ColorChannel
    {
        public ColorChannel(ColorComponent component, byte bitCount)
        {
            Component = component;
            BitCount  = bitCount;
        }

        public ColorComponent Component { get; }

        public byte BitCount { get; }
        
        public static ColorChannel R(byte bitCount)       => new ColorChannel(ColorComponent.R,       bitCount);
        public static ColorChannel G(byte bitCount)       => new ColorChannel(ColorComponent.G,       bitCount);
        public static ColorChannel B(byte bitCount)       => new ColorChannel(ColorComponent.B,       bitCount);
        public static ColorChannel A(byte bitCount)       => new ColorChannel(ColorComponent.A,       bitCount);
        public static ColorChannel Y(byte bitCount)       => new ColorChannel(ColorComponent.Y,       bitCount);
        public static ColorChannel U(byte bitCount)       => new ColorChannel(ColorComponent.U,       bitCount);
        public static ColorChannel V(byte bitCount)       => new ColorChannel(ColorComponent.V,       bitCount);
        public static ColorChannel Cb(byte bitCount)      => U(bitCount);
        public static ColorChannel Cr(byte bitCount)      => V(bitCount);
        public static ColorChannel Cyan(byte bitCount)    => new ColorChannel(ColorComponent.Cyan,    bitCount);
        public static ColorChannel Magenta(byte bitCount) => new ColorChannel(ColorComponent.Magenta, bitCount);
        public static ColorChannel Yellow(byte bitCount)  => new ColorChannel(ColorComponent.Yellow,  bitCount);
        public static ColorChannel Key(byte bitCount)     => new ColorChannel(ColorComponent.Key,     bitCount);
    }
}
