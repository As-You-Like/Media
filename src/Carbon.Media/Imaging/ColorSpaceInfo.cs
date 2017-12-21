using System;

namespace Carbon.Media
{
    using static ColorSpaceFlags;

    public readonly struct ColorSpaceInfo
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

        public readonly string Name;

        public readonly ColorModel Model;

        public readonly ColorSpaceFlags Flags;

        // WhitePoint

        // PrimaryColors

        // TODO: ColorTable (for indexed color spaces)

        // ICCData?
        public bool IsWideGamut => (Flags & WideGamut) != 0;

        public static readonly ColorSpaceInfo Cmyk     = new ColorSpaceInfo("CMYK",      ColorModel.CMYK);
        public static readonly ColorSpaceInfo Rgb      = new ColorSpaceInfo("RGB",       ColorModel.RGB);
        public static readonly ColorSpaceInfo AdobeRgb = new ColorSpaceInfo("Adobe RGB", ColorModel.RGB);
        public static readonly ColorSpaceInfo DciP3    = new ColorSpaceInfo("DCI-P3",    ColorModel.RGB, WideGamut);
    }
}