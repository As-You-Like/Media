using System.Runtime.Serialization;

namespace Carbon.Media.Metadata
{
    public class VideoStreamInfo : MediaStreamInfo
    {
        [DataMember(Name = "type", Order = 1)]
        public override MediaStreamType Type => MediaStreamType.Video;

        [DataMember(Name = "height", Order = 10)]
        public int Height { get; set; }

        [DataMember(Name = "width", Order = 11)]
        public int Width { get; set; }

        [DataMember(Name = "pixelFormat", Order = 12, EmitDefaultValue = false)]
        public PixelFormat PixelFormat { get; set; }

        [DataMember(Name = "aspect", Order = 13, EmitDefaultValue = false)]
        public Rational? Aspect { get; set; }

        [DataMember(Name = "rotate", EmitDefaultValue = false)]
        public int? Rotate { get; set; }
        
    }
}