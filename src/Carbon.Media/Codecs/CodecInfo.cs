using System;

namespace Carbon.Media
{
    public class CodecInfo : IEquatable<CodecInfo>, ICodec
    {
        internal CodecInfo(CodecId id, string name)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public CodecId Id { get; }

        public string Name { get; }

        // Profile?

        // Profile(s)

        #region Equality

        public override int GetHashCode() => Name.GetHashCode();

        public bool Equals(CodecInfo other) =>
            Id == other?.Id &&
            Name == other?.Name; 

        public override bool Equals(object obj) =>
            (obj as CodecInfo)?.Equals(this) == true;

        #endregion

        public override string ToString() => Name;

        public static CodecInfo Parse(string name)
        {
            #region Preconditions

            if (name == null)
                throw new ArgumentNullException(nameof(name));

            #endregion

            switch (name.ToUpper())
            {
                // H264 Profiles
                case "AVC1.42E01E" : return H264Baseline;
                case "AVC1.4D401E" : return H264Main;
                case "AVC1.58A01E" : return H264Extended;
                case "AVC1.64001E" : return H264High;

                case "MP4V.20.9"   : return H264Level0Simple;
                case "MP4V.20.240" : return H264Level0Advanced;

                // AAC Profiles
                case "AAC"         : return Aac;
                case "MP4A.40.2"   : return AacLC;

                case "VP8"         : return Vp8;
                case "VP9"         : return Vp9;
            }

            var type = name.ToEnum<CodecId>(ignoreCase: true);

            return new CodecInfo(type, type.ToString().ToLower());
        }

        // Audio --------------------------------------------------------------------------------------------------
        public static readonly CodecInfo Aac    = new CodecInfo(CodecId.Aac,    "aac");
        public static readonly CodecInfo AacLC  = new CodecInfo(CodecId.Aac,    "mp4a.40.2");  // AAC-low complexity
        public static readonly CodecInfo AacHE  = new CodecInfo(CodecId.Aac,    "mp4a.40.5");  // AAC-high efficiency
        public static readonly CodecInfo Alac   = new CodecInfo(CodecId.Alac,   "alac");      // Apple Lossless
        public static readonly CodecInfo Mp3    = new CodecInfo(CodecId.Mp3,    "mp3");
        public static readonly CodecInfo Wma    = new CodecInfo(CodecId.Wma1,   "wma");
        public static readonly CodecInfo Opus   = new CodecInfo(CodecId.Opus,   "opus");
        public static readonly CodecInfo Vorbis = new CodecInfo(CodecId.Vorbis, "vorbis");

        // Video --------------------------------------------------------------------------------------------------
        public static readonly CodecInfo H264Baseline       = new CodecInfo(CodecId.H264, "avc1.42E01E"); // baseline
        public static readonly CodecInfo H264Main           = new CodecInfo(CodecId.H264, "avc1.4D401E"); // main
        public static readonly CodecInfo H264Extended       = new CodecInfo(CodecId.H264, "avc1.58A01E"); // extended
        public static readonly CodecInfo H264High           = new CodecInfo(CodecId.H264, "avc1.64001E"); // high
        public static readonly CodecInfo H264Level0Simple   = new CodecInfo(CodecId.H264, "mp4v.20.9");   // level 0 simple
        public static readonly CodecInfo H264Level0Advanced = new CodecInfo(CodecId.H264, "mp4v.20.240"); // level 0 advanced

        public static readonly CodecInfo Theora = new CodecInfo(CodecId.Theora, "theora");
        public static readonly CodecInfo Dirac  = new CodecInfo(CodecId.Dirac, "dirac");

        public static readonly CodecInfo Vp8 = new CodecInfo(CodecId.Vp8, "vp8");
        public static readonly CodecInfo Vp9 = new CodecInfo(CodecId.Vp9, "vp9");
    }
}

// https://www.ietf.org/rfc/rfc4281.txt
// type='video/mp4; codecs="avc1.42E01E, mp4a.40.2"