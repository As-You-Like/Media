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

        [DataMember(Name = "orientation", Order = 3, EmitDefaultValue = false)]
        public MediaOrientation Orientation { get; set; }
    }

}