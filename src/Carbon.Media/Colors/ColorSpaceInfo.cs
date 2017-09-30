using System;

namespace Carbon.Media.Colors
{
    using static ColorModel;
    using static ColorSpaceFlags;

    public class ColorSpaceInfo
    {
        public ColorSpaceInfo(
            string name,
            ColorModel model,
            ColorSpaceFlags flags = default)
        {
            Name  = name ?? throw new ArgumentNullException(nameof(name));
            Model = model;
            Flags = flags;
        }

        public string Name { get; }

        // public ColorComponent[] Components { get; }

        public ColorModel Model { get; }

        public ColorSpaceFlags Flags { get; }
        
        // WhitePoint

        // PrimaryColors

        // TODO: ColorTable (for indexed color spaces)

        public bool IsWideGamut => Flags.HasFlag(WideGamut);

        public static readonly ColorSpaceInfo Rgb      = new ColorSpaceInfo("RGB",       RGB);
        public static readonly ColorSpaceInfo AdobeRgb = new ColorSpaceInfo("Adobe RGB", RGB);
        public static readonly ColorSpaceInfo DciP3    = new ColorSpaceInfo("DCI-P3",    RGB, WideGamut);

    }

    // ICCData?
}
