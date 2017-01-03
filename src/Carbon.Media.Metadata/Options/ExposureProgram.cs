namespace Carbon.Media.Metadata
{
    public enum ExposureProgram
    {
        NotDefined = 0,
        Manual = 1,
        NormalProgram = 2,
        AperturePriority = 3,
        ShutterPriority = 4,
        CreativeProgram = 5,    // (biased toward depth of field)
        ActionProgram = 6,      // (biased toward fast shutter speed)
        PortraitMode = 7,       // (for closeup photos with the background out of focus)
        LandscapeMode = 8,      // (for landscape photos with the background in focus)
        Bulb = 9                // Non-standard, used by Canon
    }
}
