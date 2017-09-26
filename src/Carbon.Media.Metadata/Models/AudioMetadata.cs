using System;
using System.Runtime.Serialization;

namespace Carbon.Media.Metadata
{
    [DataContract]
    public class AudioMetadata
    {
        // [DataMember(Name = "container", Order = 1)]
        // public ContainerId? Container { get; set; }

        // e.g. mp4a.40.2 (AACLC)
        [DataMember(Name = "codec", Order = 2)]
        public string Codec { get; set; }

        [DataMember(Name = "duration", Order = 7)]
        public TimeSpan Duration { get; set; }

        // ChannelLayout

        public int ChannelCount { get; set; }

        // Channels
    }
}