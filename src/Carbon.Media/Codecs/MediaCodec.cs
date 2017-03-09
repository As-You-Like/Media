using System;

namespace Carbon.Media
{
    // https://www.ietf.org/rfc/rfc4281.txt

    public class MediaCodec : IEquatable<MediaCodec>
    {
        internal MediaCodec(string name, MediaCodecType type, MediaCodecProfile profile = null)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Type = type;
            Profile = profile;
            Format = type.ToString().ToLower();
        }

        public MediaCodecType Type { get; }

        public string Name { get; }

        public string Format { get; }

        public MediaCodecProfile Profile { get; }

        #region Equality

        public override int GetHashCode() => Name.GetHashCode();

        public bool Equals(MediaCodec other)
        {
            if (other == null) return this == null;

            return Name == other.Name
                && Type == other.Type;
        }

        public override bool Equals(object obj) =>
            (obj as MediaCodec)?.Equals(this) == true;

        #endregion

        public override string ToString() => Name;

        public static MediaCodec Parse(string name)
        {
            #region Preconditions

            if (name == null)
                throw new ArgumentNullException(nameof(name));

            #endregion

            switch (name.ToUpper())
            {
                // H264 Profiles
                case "AVC1.42E01E"  : return H264Baseline;
                case "AVC1.4D401E"  : return H264Main;
                case "AVC1.58A01E"  : return H264Extended;
                case "AVC1.64001E"  : return H264High;

                case "MP4V.20.9"    : return H264Level0Simple;
                case "MP4V.20.240"  : return H264Level0Advanced;

                // AAC Profiles
                case "AAC"          : return Aac;
                case "MP4A.40.2"    : return AacLC;

                case "VP6"          : return Vp6;
                case "VP7"          : return Vp7;
                case "VP8"          : return Vp8;
                case "VP9"          : return Vp9;
            }

            var type = name.ToEnum<MediaCodecType>(ignoreCase: true);

            return new MediaCodec(type.ToString().ToLower(), type);
        }


        // Audio --------------------------------------------------------------------------------------------------
        public static readonly MediaCodec Aac    = new MediaCodec("aac",       MediaCodecType.Aac);
        public static readonly MediaCodec AacLC  = new MediaCodec("mp4a.40.2", MediaCodecType.Aac);  // AAC-low complexity profile
        public static readonly MediaCodec AacHE  = new MediaCodec("mp4a.40.5", MediaCodecType.Aac);  // AAC-high efficiency profile (HE-AAC)

        public static readonly MediaCodec Alac   = new MediaCodec("alac",      MediaCodecType.Alac); // Apple Lossless (m4a)
        public static readonly MediaCodec Mp3    = new MediaCodec("mp3",       MediaCodecType.Mp3);
        public static readonly MediaCodec Wma    = new MediaCodec("wma",       MediaCodecType.Wma);
        public static readonly MediaCodec Opus   = new MediaCodec("opus",      MediaCodecType.Opus);
        public static readonly MediaCodec Vorbis = new MediaCodec("vorbis",    MediaCodecType.Vorbis);
        public static readonly MediaCodec Wav    = new MediaCodec("wav",       MediaCodecType.Wav);

        // Images --------------------------------------------------------------------------------------------------
        public static readonly MediaCodec Bmp    = new MediaCodec("bmp",       MediaCodecType.Bmp);
        public static readonly MediaCodec Gif    = new MediaCodec("gif",       MediaCodecType.Gif);
        public static readonly MediaCodec Heif   = new MediaCodec("heif",      MediaCodecType.Heif);
        public static readonly MediaCodec Jpeg   = new MediaCodec("jpeg",      MediaCodecType.Jpeg);
        public static readonly MediaCodec Jp2    = new MediaCodec("jp2",       MediaCodecType.Jp2);
        public static readonly MediaCodec Jxr    = new MediaCodec("jxr",       MediaCodecType.Jxr);
        public static readonly MediaCodec Png    = new MediaCodec("png",       MediaCodecType.Png);
        public static readonly MediaCodec Psd    = new MediaCodec("psd",       MediaCodecType.Psd);
        public static readonly MediaCodec Svg    = new MediaCodec("svg",       MediaCodecType.Svg);
        public static readonly MediaCodec Tiff   = new MediaCodec("tiff",      MediaCodecType.Tiff);
        public static readonly MediaCodec WebP   = new MediaCodec("webp",      MediaCodecType.WebP);

        // Video --------------------------------------------------------------------------------------------------
        public static readonly MediaCodec H264Baseline = new MediaCodec("avc1.42E01E", MediaCodecType.H264, H264Profile.Baseline);
        public static readonly MediaCodec H264Main     = new MediaCodec("avc1.4D401E", MediaCodecType.H264, H264Profile.Main);
        public static readonly MediaCodec H264Extended = new MediaCodec("avc1.58A01E", MediaCodecType.H264, H264Profile.Extended);
        public static readonly MediaCodec H264High     = new MediaCodec("avc1.64001E", MediaCodecType.H264, H264Profile.High);

        public static readonly MediaCodec H264Level0Simple   = new MediaCodec("mp4v.20.9",   MediaCodecType.H264, H264Profile.Level0Simple);
        public static readonly MediaCodec H264Level0Advanced = new MediaCodec("mp4v.20.240", MediaCodecType.H264, H264Profile.Level0Advanced);

        public static readonly MediaCodec Theora       = new MediaCodec("theora", MediaCodecType.Theora);
        public static readonly MediaCodec Dirac        = new MediaCodec("dirac", MediaCodecType.Dirac);

        public static readonly MediaCodec Vp3 = new MediaCodec("vp3", MediaCodecType.Vp3);
        public static readonly MediaCodec Vp4 = new MediaCodec("vp4", MediaCodecType.Vp4);
        public static readonly MediaCodec Vp5 = new MediaCodec("vp5", MediaCodecType.Vp5);
        public static readonly MediaCodec Vp6 = new MediaCodec("vp6", MediaCodecType.Vp6);
        public static readonly MediaCodec Vp7 = new MediaCodec("vp7", MediaCodecType.Vp7);
        
        public static readonly MediaCodec Vp8 = new MediaCodec("vp8", MediaCodecType.Vp8);
        public static readonly MediaCodec Vp9 = new MediaCodec("vp9", MediaCodecType.Vp9);


        public static readonly MediaCodec Vp9 = new MediaCodec("vp9", MediaCodecType.Vp9);
        public static readonly MediaCodec Vp9 = new MediaCodec("vp9", MediaCodecType.Vp9);


    }

    public abstract class MediaCodecProfile { }
}
