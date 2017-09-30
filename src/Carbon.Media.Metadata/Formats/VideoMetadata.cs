using System;
using System.Runtime.Serialization;

namespace Carbon.Media.Metadata
{
    [DataContract]
    public class VideoMetadata : IFormatMetadata
    {
        [DataMember(Name = "format", Order = 1)]
        public string Format { get; set; }

        [DataMember(Name = "codec", Order = 2, EmitDefaultValue = false)]
        public string Codec { get; set; }

        [DataMember(Name = "width", Order = 4, EmitDefaultValue = false)]
        public int Width { get; set; }

        [DataMember(Name = "height", Order = 5, EmitDefaultValue = false)]
        public int Height { get; set; }

        [DataMember(Name = "pixelFormat", Order = 6, EmitDefaultValue = false)]
        public PixelFormat PixelFormat { get; set; }

        [DataMember(Name = "duration", Order = 11, EmitDefaultValue = false)]
        public TimeSpan Duration { get; set; }

        // [DataMember(Name = "frameSize", Order = 12, EmitDefaultValue = false)]
        // public Size FrameSize { get; set; }

        // FrameWidth
        // FrameHeight

        [DataMember(Name = "frameRate", Order = 13, EmitDefaultValue = false)]
        public Rational FrameRate { get; set; }
    }
}

/*
{ 
    format        : "mp4",
    codec         : "h265",
    duration      : "00:30:00"
}
*/