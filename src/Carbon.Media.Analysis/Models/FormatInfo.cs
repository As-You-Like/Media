using System;
using System.Runtime.Serialization;
using Carbon.Media.Metadata;

namespace Carbon.Media.Analysis
{
    [DataContract]
    public class FormatInfo
    {
        // audio/mp3
        [DataMember(Name = "type", Order = 1)]
        public string Type { get; set; }

        [DataMember(Name = "format", Order = 2)]
        public string Format { get; set; }

        [DataMember(Name = "size", Order = 3)]
        public long Size { get; set; }

        [DataMember(Name = "width", Order = 4, EmitDefaultValue = false)]
        public int Width { get; set; }

        [DataMember(Name = "height", Order = 5, EmitDefaultValue = false)]
        public int Height { get; set; }

        [DataMember(Name = "rotate", Order = 6, EmitDefaultValue = false)]
        public int? Rotate { get; set; }

        [DataMember(Name = "duration", Order = 11)]
        public TimeSpan? Duration { get; set; }

        [DataMember(Name = "streams", Order = 12)]
        public MediaStreamInfo[] Streams { get; set; }
    }
}

/*
{   
    type     : "video/mp4",
    duration : "00:30:00",
    streams  : [ ]
}
*/
