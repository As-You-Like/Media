using System;

namespace Carbon.Media
{
    public class H264Profile : MediaCodecProfile
    {
        private readonly string name;

        public H264Profile(string name, H264ProfileType type)
        {
            #region Preconditions

            if (name == null) throw new ArgumentNullException(nameof(name));

            #endregion

            this.name = name;
            Type = type;
        }

        public H264ProfileType Type { get; }

        public override string ToString() => name;

        #region Equality

        public override int GetHashCode() => name.GetHashCode();

        public override bool Equals(object obj)
        {
            var other = obj as H264Profile;

            if (other == null) return false;

            return other.name == this.name;
        }

        #endregion

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