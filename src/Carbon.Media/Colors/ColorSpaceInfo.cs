namespace Carbon.Media.Colors
{
    public class ColorSpaceInfo
    {
        public ColorSpaceInfo(
            string name,
            ColorModel model,
            ColorComponent[] components, 
            ColorSpaceFlags flags = ColorSpaceFlags.None)
        {
            Name       = name;
            Components = components;
            Model      = model;
            Flags      = flags;
        }

        public string Name { get; }

        public ColorComponent[] Components { get; }

        public ColorModel Model { get; }

        public ColorSpaceFlags Flags { get; }
    }

    public enum ColorSpaceFlags
    {
        None      = 0,
        WideGamut = 1 << 0
    }

    // ICCData?

    // ColorTable for indexed color spaces
    // IsWideGamut?

}
