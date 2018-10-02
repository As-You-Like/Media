namespace Carbon.Media.Metadata.Exif
{
    public enum ExifPhotometricInterpretation : ushort
    {
        WhiteIsZero      = 0,
        BlackIsZero      = 1,
        RGB              = 2,
        RGBPalette       = 3,
        TransparencyMask = 4,
        CMYK             = 5,
        YCbCr            = 6,
        CIELab           = 8,
        ICCLab           = 9,
        ITULab           = 10,
        ColorFilterArray = 32803,
        PixarLogL        = 32844,
        PixarLogLuv      = 32845,
        LinearRaw        = 34892
    }
}
