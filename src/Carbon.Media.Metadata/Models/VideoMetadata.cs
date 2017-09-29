using System;
using System.Runtime.Serialization;

namespace Carbon.Media.Metadata
{
    [DataContract]
    public class VideoMetadata
    {
        [DataMember(Name = "format", Order = 1)]
        public string Format { get; set; }

        [DataMember(Name = "codec", Order = 2, EmitDefaultValue = false)]
        public string Codec { get; set; }

        [DataMember(Name = "duration", Order = 7, EmitDefaultValue = false)]
        public TimeSpan Duration { get; set; }
        
        [DataMember(Name = "pixelFormat", Order = 10, EmitDefaultValue = false)]
        public PixelFormat PixelFormat { get; set; }
    }
}

/*
{ 
    format        : "mp4",
    codec         : "h265",
    duration      : "00:30:00"
}
*/
