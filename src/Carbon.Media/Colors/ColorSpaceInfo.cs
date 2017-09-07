namespace Carbon.Media.Colors
{
    public class ColorSpaceInfo
    {
        public string Name { get; set; }

        public ColorComponent[] Components { get; set; }

        public ColorModel Model { get; set; }

        // ICCData?

        // ColorTable for indexed color spaces
        // IsWideGamut?
    }
}
