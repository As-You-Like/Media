using System;
using System.Runtime.Serialization;

namespace Carbon.Media.Metadata
{
    [DataContract]
    public class AudioMetadata
    {
        // e.g. aac, mp3
        [DataMember(Name = "format", Order = 1)] 
        public AudioFormat Format { get; set; }

        // e.g. mp4a.40.2 (AACLC)
        [DataMember(Name = "codecs", Order = 2)]
        public string[] Codecs { get; set; }

        [DataMember(Name = "duration", Order = 7)]
        public TimeSpan Duration { get; set; }

        [DataMember(Name = "channelLayout")]
        public ChannelLayout ChannelLayout { get; set; }

        [DataMember(Name = "channelCount")]
        public int ChannelCount { get; set; }

        // Channels
    }
}