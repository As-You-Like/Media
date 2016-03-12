using System;

namespace Carbon.Media
{
    public struct MediaCodec
    {
        private readonly string name;
        private readonly MediaCodecType type;
        private readonly MediaCodecProfile profile;

        internal MediaCodec(string name, MediaCodecType type, MediaCodecProfile profile = null)
        {
            #region Preconditions

            if (name == null)
                throw new ArgumentNullException("name");

            #endregion

            this.name = name;
            this.type = type;
            this.profile = profile;
        }

        public MediaCodecType Type => type;

        public string Format => type.ToString().ToLower();

        public MediaCodecProfile Profile => profile;

        #region Equality

        public override int GetHashCode()
        {
            return name.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is MediaCodec)
            {
                var other = (MediaCodec)obj;

                return other.name == this.name;
            }

            return false;
        }

        #endregion

        public override string ToString() => name;

        public static MediaCodec Parse(string name)
        {
            #region Preconditions

            if (name == null)
                throw new ArgumentNullException("name");

            #endregion

            switch (name.ToUpper())
            {
                // H264 Profiles
                case "AVC1.42E01E": return H264Baseline;
                case "AVC1.4D401E": return H264Main;
                case "AVC1.58A01E": return H264Extended;
                case "AVC1.64001E": return H264High;

                // AAC Profiles
                case "mp4a.40.2": return AacLC;
            }

            var type = name.ToEnum<MediaCodecType>(ignoreCase: true);

            return new MediaCodec(type.ToString().ToLower(), type);
        }


        // Audio --------------------------------------------------------------------------------------------------
        public static readonly MediaCodec Aac = new MediaCodec("aac", MediaCodecType.Aac);
        public static readonly MediaCodec AacLC = new MediaCodec("mp4a.40.2", MediaCodecType.Aac);  // AAC-low complexity profile
        public static readonly MediaCodec AacHE = new MediaCodec("mp4a.40.5", MediaCodecType.Aac);  // AAC-high efficiency profile   (HE-AAC)
        public static readonly MediaCodec Alac = new MediaCodec("alac", MediaCodecType.Alac);   // Apple Lossless (m4a)
        public static readonly MediaCodec Mp3 = new MediaCodec("mp3", MediaCodecType.Mp3);
        public static readonly MediaCodec Wma = new MediaCodec("wma", MediaCodecType.Wma);
        public static readonly MediaCodec Opus = new MediaCodec("opus", MediaCodecType.Opus);
        public static readonly MediaCodec Vorbis = new MediaCodec("vorbis", MediaCodecType.Vorbis);
        public static readonly MediaCodec Wav = new MediaCodec("wav", MediaCodecType.Wav);

        // Video --------------------------------------------------------------------------------------------------
        public static readonly MediaCodec H264Baseline = new MediaCodec("avc1.42E01E", MediaCodecType.H264, H264Profile.Baseline);
        public static readonly MediaCodec H264Main = new MediaCodec("avc1.4D401E", MediaCodecType.H264, H264Profile.Main);
        public static readonly MediaCodec H264Extended = new MediaCodec("avc1.58A01E", MediaCodecType.H264, H264Profile.Extended);
        public static readonly MediaCodec H264High = new MediaCodec("avc1.64001E", MediaCodecType.H264, H264Profile.High);

        public static readonly MediaCodec Vp8 = new MediaCodec("vp8", MediaCodecType.Vp8);

        // Images --------------------------------------------------------------------------------------------------
        public static readonly MediaCodec Bmp = new MediaCodec("bmp", MediaCodecType.Bmp);
        public static readonly MediaCodec Gif = new MediaCodec("gif", MediaCodecType.Gif);
        public static readonly MediaCodec Jpeg = new MediaCodec("jpeg", MediaCodecType.Jpeg);
        public static readonly MediaCodec Png = new MediaCodec("jp2", MediaCodecType.Jpeg2000);
        public static readonly MediaCodec Tiff = new MediaCodec("tiff", MediaCodecType.Tiff);
        public static readonly MediaCodec Jxr = new MediaCodec("jxr", MediaCodecType.Jxr);
        public static readonly MediaCodec WebP = new MediaCodec("webp", MediaCodecType.WebP);
    }

    public abstract class MediaCodecProfile { }
}
