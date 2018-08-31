using System;
using System.Runtime.Serialization;

namespace Carbon.Media
{
    public class MediaStreamInfo
    {
        [DataMember(Name = "type", Order = 1)]
        public virtual MediaStreamType Type => MediaStreamType.Unknown;

        // e.g. aac, mp4a.40.2
        [DataMember(Name = "codec", Order = 2)]
        public string Codec { get; set; }

        [DataMember(Name = "duration", Order = 3, EmitDefaultValue = false)]
        public TimeSpan Duration { get; set; }

        [DataMember(Name = "startTime", EmitDefaultValue = false)]
        public TimeSpan StartTime { get; set; }

        [DataMember(Name = "frameCount", Order = 5, EmitDefaultValue = false)]
        public int? FrameCount { get; set; }

        [DataMember(Name = "timeBase", Order = 20, EmitDefaultValue = false)]
        public Rational? TimeBase { get; set; }
    }
}
