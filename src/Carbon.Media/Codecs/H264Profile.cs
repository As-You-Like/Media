using System;

namespace Carbon.Media
{
    public class H264Profile : MediaCodecProfile, IEquatable<H264Profile>
    {
        private readonly string name;

        public H264Profile(string name, H264ProfileType type)
        {
            this.name = name ?? throw new ArgumentNullException(nameof(name));
            Type = type;
        }

        public H264ProfileType Type { get; }

        public override string ToString() => name;

        #region Equality

        public override int GetHashCode() => name.GetHashCode();

        public bool Equals(H264Profile other) =>
            other?.name == name;

        public override bool Equals(object obj)
        {
            return (obj as H264Profile)?.Equals(this) == true;
        }

        #endregion

        // MPEG-4 Visual Simple Profile Level 0: mp4v.20.9
        // MPEG-4 Visual Advanced Simple Profile Level 0: mp4v.20.240
        public static readonly H264Profile Level0Simple   = new H264Profile("mp4v.20.9",   H264ProfileType.Baseline);
        public static readonly H264Profile Level0Advanced = new H264Profile("mp4v.20.240", H264ProfileType.Baseline);

        public static readonly H264Profile Baseline = new H264Profile("avc1.42E01E", H264ProfileType.Baseline);
        public static readonly H264Profile Main     = new H264Profile("avc1.4D401E", H264ProfileType.Main);
        public static readonly H264Profile Extended = new H264Profile("avc1.58A01E", H264ProfileType.Extended);
        public static readonly H264Profile High     = new H264Profile("avc1.64001E", H264ProfileType.High);
    }

    public enum H264ProfileType
    {
        /// <summary>
        /// avc1.42E01E
        /// </summary>
        Baseline = 1,

        /// <summary>
        /// avc1.4D401E
        /// </summary>
        Main = 2,

        /// <summary>
        /// avc1.58A01E
        /// </summary>
        Extended = 3,

        /// <summary>
        /// avc1.64001E
        /// </summary>
        High = 4
    }
}