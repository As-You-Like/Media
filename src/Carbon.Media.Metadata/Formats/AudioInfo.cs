﻿using System;
using System.Runtime.Serialization;

namespace Carbon.Media.Metadata
{
    [DataContract]
    public class AudioInfo
    {
        // e.g. aac, mp3 
        [DataMember(Name = "format", Order = 1)]
        public string Format { get; set; }

        // e.g. mp4a.40.2 (AACLC)
        [DataMember(Name = "codec", Order = 2)]
        public string Codec { get; set; }

        [DataMember(Name = "duration", Order = 11, EmitDefaultValue = false)]
        public TimeSpan Duration { get; set; }

        [DataMember(Name = "channelCount", Order = 12, EmitDefaultValue = false)]
        public int ChannelCount { get; set; }

        [DataMember(Name = "channelLayout", Order = 13, EmitDefaultValue = false)]
        public ChannelLayout ChannelLayout { get; set; }
    }
}

/*
{ 
    format        : "aac",
    codec         : "mp4a.40.2",
    duration      : "00:30:00",
    channelLayout : "Stereo" 
}
*/