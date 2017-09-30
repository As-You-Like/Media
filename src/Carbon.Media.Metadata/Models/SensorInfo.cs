using System.Runtime.Serialization;

namespace Carbon.Media.Metadata
{
    [DataContract]
    public class SensingInfo
    {
        [DataMember(Name = "method", Order = 1)]
        public SensingMethod Method { get; set; }
    }
}