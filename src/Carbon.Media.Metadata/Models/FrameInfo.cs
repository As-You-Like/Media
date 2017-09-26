using System.Runtime.Serialization;

namespace Carbon.Media.Metadata
{
    [DataContract]
    public class FrameInfo
    {
        [DataMember(Name = "width", Order = 1)]
        public int Width { get; set; }

        [DataMember(Name = "height", Order = 2)]
        public int Height { get; set; }

        // Delay

        // Dts
        // Pts

        // Use base unit to convert to timespan

        [DataMember(Name = "duration")]
        public long Duration { get; set; }
    }
}