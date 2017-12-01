namespace Carbon.Media.Metadata
{
    public enum ExifContrast
    {
        Normal = 0,
        Low    = 1,
        High   = 2
    }

    public enum ExifSharpness
    {
        Normal = 0,
        Soft    = 1,
        Hard   = 2
    }

    public enum ExifColorSpace
    {
        sRGB         = 1,
        AdobeRGB     = 2,
        WideGamutRGB = 4093,
        ICCProfile   = 65534,
        Uncalibrated = 65535
    }
}
