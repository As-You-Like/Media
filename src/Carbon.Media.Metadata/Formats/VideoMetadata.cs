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

        /// <summary>
        /// The frame width
        /// </summary>
        [DataMember(Name = "width", Order = 4, EmitDefaultValue = false)]
        public int Width { get; set; }

        /// <summary>
        /// The frame height
        /// </summary>
        [DataMember(Name = "height", Order = 5, EmitDefaultValue = false)]
        public int Height { get; set; }

        [DataMember(Name = "pixelFormat", Order = 6, EmitDefaultValue = false)]
        public PixelFormat PixelFormat { get; set; }

        [DataMember(Name = "duration", Order = 11, EmitDefaultValue = false)]
        public TimeSpan Duration { get; set; }

        [DataMember(Name = "frameRate", Order = 13, EmitDefaultValue = false)]
        public Rational FrameRate { get; set; }

        [DataMember(Name = "aspectRatio", Order = 14, EmitDefaultValue = false)]
        public Rational? AspectRatio { get; set; }
        
        [DataMember(Name = "created", Order = 20, EmitDefaultValue = false)]
        public DateTime? Created { get; }

        [DataMember(Name = "modified", Order = 21, EmitDefaultValue = false)]
        public DateTime? Modified { get; }
    }
}

/*
{ 
    format        : "mp4",
    codec         : "h265",
    duration      : "00:30:00"
}
*/