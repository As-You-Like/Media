using System.Runtime.Serialization;

namespace Carbon.Media.Metadata
{
    [DataContract]
    public class PageInfo
    {
        [DataMember(Name = "width", Order = 1)]
        public int Width { get; set; }

        [DataMember(Name = "height", Order = 2)]
        public int Height { get; set; }

        public MediaOrientation Orientation { get; set; }
    }

    [DataContract]
    public class FrameInfo
    {
        [DataMember(Name = "width", Order = 1)]
        public int Width { get; set; }

        [DataMember(Name = "height", Order = 2)]
        public int Height { get; set; }

        [DataMember(Name = "pixelFormat", Order = 3, EmitDefaultValue = false)]
        public PixelFormat? PixelFormat { get; set; }

        [DataMember(Name = "delay", EmitDefaultValue = false)]
        public long Delay { get; set; }

        [DataMember(Name = "dts", EmitDefaultValue = false)]
        public long Dts { get; set; }

        [DataMember(Name = "pts", EmitDefaultValue = false)]
        public long Pts { get; set; }

        [DataMember(Name = "duration", EmitDefaultValue = false)]
        public long Duration { get; set; }

        [DataMember(Name = "disposalMethod", EmitDefaultValue = false)]
        public DisposalMethod? DisposalMethod { get; set; }
    }

    // NOTE: Use a base unit to covert

    public enum DisposalMethod
    {
        Unspecified         = 0,
        NotDisposed         = 1,
        RestoreToBackground = 2,
        RestoreToPrevious   = 3
    }

}