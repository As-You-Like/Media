using System;

namespace Carbon.Media
{
    // https://www.ietf.org/rfc/rfc4281.txt

    public class CodecInfo : IEquatable<CodecInfo>
    {
        internal CodecInfo(string name, CodecType type)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Type = type;
        }

        public string Name { get; }

        public CodecType Type { get; }

        #region Equality

        public override int GetHashCode() => Name.GetHashCode();

        public bool Equals(CodecInfo other) =>
            Name == other?.Name && 
            Type == other?.Type;

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

                case "VP6"         : return Vp6;
                case "VP7"         : return Vp7;
                case "VP8"         : return Vp8;
                case "VP9"         : return Vp9;
            }

            var type = name.ToEnum<CodecType>(ignoreCase: true);

            return new CodecInfo(type.ToString().ToLower(), type);
        }


        // Audio --------------------------------------------------------------------------------------------------
        public static readonly CodecInfo Aac    = new CodecInfo("aac",       CodecType.Aac);
        public static readonly CodecInfo AacLC  = new CodecInfo("mp4a.40.2", CodecType.Aac);  // AAC-low complexity profile
        public static readonly CodecInfo AacHE  = new CodecInfo("mp4a.40.5", CodecType.Aac);  // AAC-high efficiency profile (HE-AAC)
        public static readonly CodecInfo Alac   = new CodecInfo("alac",      CodecType.Alac); // Apple Lossless (m4a)
        public static readonly CodecInfo Aiff   = new CodecInfo("aiff",      CodecType.Aiff);
        public static readonly CodecInfo Mp3    = new CodecInfo("mp3",       CodecType.Mp3);
        public static readonly CodecInfo Wma    = new CodecInfo("wma",       CodecType.Wma);
        public static readonly CodecInfo Opus   = new CodecInfo("opus",      CodecType.Opus);
        public static readonly CodecInfo Vorbis = new CodecInfo("vorbis",    CodecType.Vorbis);
        public static readonly CodecInfo Wav    = new CodecInfo("wav",       CodecType.Wav);

        // Images --------------------------------------------------------------------------------------------------
        public static readonly CodecInfo Bmp    = new CodecInfo("bmp",       CodecType.Bmp);
        public static readonly CodecInfo Gif    = new CodecInfo("gif",       CodecType.Gif);
        public static readonly CodecInfo Heif   = new CodecInfo("heif",      CodecType.Heif);
        public static readonly CodecInfo Jpeg   = new CodecInfo("jpeg",      CodecType.Jpeg);
        public static readonly CodecInfo Jp2    = new CodecInfo("jp2",       CodecType.Jp2);
        public static readonly CodecInfo Jxr    = new CodecInfo("jxr",       CodecType.Jxr);
        public static readonly CodecInfo Png    = new CodecInfo("png",       CodecType.Png);
        public static readonly CodecInfo Psd    = new CodecInfo("psd",       CodecType.Psd);
        public static readonly CodecInfo Svg    = new CodecInfo("svg",       CodecType.Svg);
        public static readonly CodecInfo Tiff   = new CodecInfo("tiff",      CodecType.Tiff);
        public static readonly CodecInfo WebP   = new CodecInfo("webp",      CodecType.WebP);

        // Video --------------------------------------------------------------------------------------------------
        public static readonly CodecInfo H264Baseline       = new CodecInfo("avc1.42E01E", CodecType.H264); // baseline
        public static readonly CodecInfo H264Main           = new CodecInfo("avc1.4D401E", CodecType.H264); // main
        public static readonly CodecInfo H264Extended       = new CodecInfo("avc1.58A01E", CodecType.H264); // extended
        public static readonly CodecInfo H264High           = new CodecInfo("avc1.64001E", CodecType.H264); // high
        public static readonly CodecInfo H264Level0Simple   = new CodecInfo("mp4v.20.9",   CodecType.H264); // level 0 simple
        public static readonly CodecInfo H264Level0Advanced = new CodecInfo("mp4v.20.240", CodecType.H264); // level 0 advanced

        public static readonly CodecInfo Theora       = new CodecInfo("theora", CodecType.Theora);
        public static readonly CodecInfo Dirac        = new CodecInfo("dirac", CodecType.Dirac);

        public static readonly CodecInfo Vp3 = new CodecInfo("vp3", CodecType.Vp3);
        public static readonly CodecInfo Vp4 = new CodecInfo("vp4", CodecType.Vp4);
        public static readonly CodecInfo Vp5 = new CodecInfo("vp5", CodecType.Vp5);
        public static readonly CodecInfo Vp6 = new CodecInfo("vp6", CodecType.Vp6);
        public static readonly CodecInfo Vp7 = new CodecInfo("vp7", CodecType.Vp7);
        public static readonly CodecInfo Vp8 = new CodecInfo("vp8", CodecType.Vp8);
        public static readonly CodecInfo Vp9 = new CodecInfo("vp9", CodecType.Vp9);
    }
}