using System;
using System.Runtime.Serialization;

namespace Carbon.Media.Metadata
{
    [DataContract]
    public class AudioInfo
    {
        // e.g. aac, mp3 
        [DataMember(Name = "format", Order = 1)]
        public string Format { get; set; }

        [DataMember(Name = "codec", Order = 2)]
        public string Codec { get; set; }

        [DataMember(Name = "blob", Order = 3, EmitDefaultValue = false)]
        public BlobInfo Blob { get; set; }

        [DataMember(Name = "sampleFormat", Order = 5, EmitDefaultValue = false)]
        public SampleFormat SampleFormat { get; set; }

        [DataMember(Name = "duration", Order = 10, EmitDefaultValue = false)]
        public TimeSpan Duration { get; set; }

        [DataMember(Name = "channelLayout", Order = 12, EmitDefaultValue = false)]
        public ChannelLayout ChannelLayout { get; set; }

        // Frames = 11
    }
}

/*
{ 
    format        : "aac",
    codec         : "mp4a.40.2",
    duration      : "00:30:00",
    channels      : [ 
        { "name": "FrontLeft"  },
        { "name": "FrontRight" }
    ]
}
*/
