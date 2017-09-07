namespace Carbon.Media
{
    public struct ColorChannel
    {
        public ColorChannel(ColorComponent component, byte bitCount)
        {
            Component = component;
            BitCount  = bitCount;
        }

        public ColorComponent Component { get; }

        public byte BitCount { get; }
        
        public static ColorChannel R(byte bitCount) => new ColorChannel(ColorComponent.R, bitCount);
        public static ColorChannel G(byte bitCount) => new ColorChannel(ColorComponent.G, bitCount);
        public static ColorChannel B(byte bitCount) => new ColorChannel(ColorComponent.B, bitCount);
        public static ColorChannel A(byte bitCount) => new ColorChannel(ColorComponent.A, bitCount);
        public static ColorChannel C(byte bitCount) => new ColorChannel(ColorComponent.C, bitCount);
        public static ColorChannel M(byte bitCount) => new ColorChannel(ColorComponent.M, bitCount);
        public static ColorChannel Y(byte bitCount) => new ColorChannel(ColorComponent.Y, bitCount);
        public static ColorChannel K(byte bitCount) => new ColorChannel(ColorComponent.K, bitCount);
    }
}
