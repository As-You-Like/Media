using System.Runtime.Serialization;

namespace Carbon.Media.Metadata
{
    [DataContract]
    public class SensorInfo
    {
        [DataMember(Name = "type", Order = 1)]
        public SensingMethod Type { get; set; }
    }
}