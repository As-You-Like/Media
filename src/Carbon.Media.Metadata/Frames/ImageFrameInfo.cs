using System;
using System.Runtime.Serialization;

namespace Carbon.Media.Metadata
{
    [DataContract]
    public class ImageFrameInfo
    {
        [DataMember(Name = "width", Order = 1)]
        public int Width { get; set; }

        [DataMember(Name = "height", Order = 2)]
        public int Height { get; set; }

        [DataMember(Name = "orientation", Order = 3, EmitDefaultValue = false)]
        public MediaOrientation Orientation { get; set; }

        [DataMember(Name = "pixelFormat", Order = 4, EmitDefaultValue = false)]
        public PixelFormat? PixelFormat { get; set; }

        // /grctlext/Delay (in 100th of a millisecond)
        [DataMember(Name = "delay", EmitDefaultValue = false)]
        public TimeSpan Delay { get; set; }

        [DataMember(Name = "decodeTime", EmitDefaultValue = false)] // dts
        public TimeSpan DecodeTime { get; set; }

        [DataMember(Name = "presentTime", EmitDefaultValue = false)] // pts
        public TimeSpan PresentTime { get; set; }

        [DataMember(Name = "duration", EmitDefaultValue = false)]
        public long Duration { get; set; }

        // /grctlext/Disposal
        [DataMember(Name = "disposalMethod", EmitDefaultValue = false)]
        public FrameDisposalMethod? DisposalMethod { get; set; }

        // /imgdesc/Left
        [DataMember(Name = "left", EmitDefaultValue = false)]
        public int Left { get; set; }

        // /imgdesc/Top
        [DataMember(Name = "top", EmitDefaultValue = false)]
        public int Top { get; set; }
    }
}

// TODO: Match image....