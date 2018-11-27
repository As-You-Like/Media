using System.Runtime.Serialization;
using Carbon.Media.Metadata.Exif;

namespace Carbon.Media.Metadata
{
    [DataContract]
    public class LightingInfo
    {
        [DataMember(Name = "source", Order = 1)]
        public ExifLightSource Source { get; set; }
    }
}