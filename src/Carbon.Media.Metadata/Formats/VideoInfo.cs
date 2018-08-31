using System;
using System.Runtime.Serialization;

namespace Carbon.Media.Metadata
{
    [DataContract]
    public class VideoInfo
    {
        [DataMember(Name = "type", Order = 1, EmitDefaultValue = false)]
        public string Type { get; set; }

        [DataMember(Name = "format", Order = 2)]
        public string Format { get; set; }

        // h265
        [DataMember(Name = "codec", Order = 3, EmitDefaultValue = false)]
        public string Codec { get; set; }

        [DataMember(Name = "size", Order = 4, EmitDefaultValue = false)]
        public long Size { get; set; }

        [DataMember(Name = "pixelFormat", Order = 5, EmitDefaultValue = false)]
        public PixelFormat PixelFormat { get; set; }

        [DataMember(Name = "width", Order = 6, EmitDefaultValue = false)]
        public int Width { get; set; }

        [DataMember(Name = "height", Order = 7, EmitDefaultValue = false)]
        public int Height { get; set; }
        
        [DataMember(Name = "orientation", Order = 8, EmitDefaultValue = false)]
        public ExifOrientation? Orientation { get; set; }

        [DataMember(Name = "colorSpace", Order = 9, EmitDefaultValue = false)]
        public ColorSpace ColorSpace { get; set; }

        // Image Resolution = 10

        [DataMember(Name = "duration", Order = 11, EmitDefaultValue = false)]
        public TimeSpan Duration { get; set; }

        [DataMember(Name = "frameRate", Order = 13, EmitDefaultValue = false)]
        public Rational FrameRate { get; set; }

        [DataMember(Name = "aspectRatio", Order = 14, EmitDefaultValue = false)]
        public Rational? AspectRatio { get; set; }
    }
}

/*
{ 
    type          : "mp4",
    codec         : "h265",
    duration      : "00:30:00"
}
*/