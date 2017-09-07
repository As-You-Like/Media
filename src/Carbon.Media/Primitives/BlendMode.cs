namespace Carbon.Media
{
    public enum BlendMode : byte
    {
        Normal     = 0,
        Add        = 1, // addition
        Burn       = 2, 
        Color      = 3,
        ColorBurn  = 4,
        ColorDodge = 5,
        Darken     = 6,
        Difference = 7,
        Divide     = 8,
        Dodge      = 9,
        Exclusion  = 10,
        HardLight  = 11,
        HardMix    = 12,
        Hue        = 13,
        Lighten    = 14,
        LinearBurn = 15,
        Luminosity = 16,
        Multiply   = 17,
        Overlay    = 18,
        Saturation = 19,
        Screen     = 20,
        SoftLight  = 21,
        Subtract   = 22,
        VividLight = 23
    }

    // And
    // GrainMerge | GrainExtract
    // Freeze
    // ChromeKey (treshhold, smoothing)
    // Disolve (mix)
    // Pinlight
}

/*
‘addition’
‘grainmerge’
‘and’
‘average’
‘freeze’‘extremity’
‘glow’
‘heat’
‘linearlight’
‘multiply128’
‘negation’
‘or’
‘overlay’
‘phoenix’
‘pinlight’
‘reflect’
‘xor’
*/