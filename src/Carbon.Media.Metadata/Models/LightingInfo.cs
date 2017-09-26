using System.Runtime.Serialization;

namespace Carbon.Media.Metadata
{
    [DataContract]
    public class LightingInfo
    {
        [DataMember(Name = "source")]
        public LightSource Source { get; set; }
    }
}