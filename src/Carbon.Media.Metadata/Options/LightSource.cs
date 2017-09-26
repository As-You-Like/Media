namespace Carbon.Media.Metadata
{
    public enum LightSource
    {
        Unknown              = 0,
        Daylight             = 1,
        Fluorescent          = 2,
        Tungsten             = 3,  // Incandescent light
        Flash                = 4,
        FineWeather          = 9,
        CloudyWeather        = 10,
        Shade                = 11,
        DaylightFluorescent  = 12, // (D 5700 - 7100K)
        DayWhiteFluorescent  = 13, // (N 4600 - 5400K)
        CoolWhiteFluorescent = 14, // (W 3900 - 4500K)
        WhiteFluorescent     = 15, // (WW 3200 - 3700K)
        StandardLightA       = 17,
        StandardLightB       = 18,
        StandardLightC       = 19,
        D55                  = 20,
        D65                  = 21,
        D75                  = 22,
        D50                  = 23,
        IsoStudioTungsten    = 24,
        OtherLightSource     = 255
    }
}
