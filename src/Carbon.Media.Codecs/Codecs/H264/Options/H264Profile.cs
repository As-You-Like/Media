using System;

namespace Carbon.Media.Codecs
{
    public readonly struct H264Profile : IEquatable<H264Profile>
    {
        public H264Profile(string name, H264ProfileType type)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Type = type;
        }

        public readonly string Name;

        public readonly H264ProfileType Type;

        // Level

        public override string ToString() => Name;

        #region Equality

        public override int GetHashCode() => Name.GetHashCode();

        public bool Equals(H264Profile other) => other.Name == Name;

        public override bool Equals(object obj)
        {
            return obj is H264Profile other && Equals(other);
        }

        #endregion

        public static readonly H264Profile Level0Simple   = new H264Profile("mp4v.20.9",   H264ProfileType.BP);  // Visual Simple Profile Level 0
        public static readonly H264Profile Level0Advanced = new H264Profile("mp4v.20.240", H264ProfileType.BP);  // Visual Advanced Simple Profile Level 0
        public static readonly H264Profile Baseline       = new H264Profile("avc1.42E01E", H264ProfileType.BP);  // Baseline
        public static readonly H264Profile Main           = new H264Profile("avc1.4D401E", H264ProfileType.MP);  // Main
        public static readonly H264Profile Extended       = new H264Profile("avc1.58A01E", H264ProfileType.XP);  // Extended
        public static readonly H264Profile High           = new H264Profile("avc1.64001E", H264ProfileType.HiP); // High

        public static H264Profile FromCodec(CodecInfo codec)
        {
            switch(codec.Name)
            {
                case "mp4v.20.9"   : return Level0Simple;
                case "mp4v.20.240" : return Level0Advanced;
                case "avc1.42E01E" : return Baseline;
                case "avc1.4D401E" : return Main;
                case "avc1.58A01E" : return Extended;
                case "avc1.64001E" : return High;
                default            : throw new Exception("unexpected profile: " + codec.Name);
            }
        }
    }

    // LEVEL 1 - 5.2

    public enum H264ProfileType : byte
    {   
        BP       = 1, // avc1.42E01E | Baseline 66
        MP       = 2, // avc1.4D401E | Main     77
        XP       = 3, // avc1.58A01E | Extended 88
        HiP      = 4, // avc1.64001E | High     100
        PHiP     = 5, // ?
        Hi10P    = 6, // ?
        Hi422P   = 7, // ?
        Hi444PP  = 8, // ?
    }

    /*
    High,
	High10,
	High10Intra,
	High422,
	High422Intra,
	High444,
	High444Predictive,
	High444Intra,
	CAVLC444,
    */
    // Constrained
    // Baseline
    // Constrained Baseline
}

// https://en.wikipedia.org/wiki/H.264/MPEG-4_AVC#Profiles

/*
High 10 (Hi10P)                  : + 10 bits per sample of decoded picture precision.
High 4:2:2 (Hi422P)              : + 4:2:2 chroma sampling format while using up to 10 bits per sample of decoded picture precision.
High 4:4:4 Predictive (Hi444PP)  : + 4:4:4 chroma sampling and up to 14 bits per sample
*/
