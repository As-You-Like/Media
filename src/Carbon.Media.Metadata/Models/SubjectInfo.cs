using System.Runtime.Serialization;

namespace Carbon.Media.Metadata
{
    [DataContract]
    public class SubjectInfo
    {
        // Id = 1
        
        [DataMember(Name = "subject", Order = 2)]
        public string Type { get; set; }

        // in meters
        [DataMember(Name = "distance", Order = 3)] // TODO :Unit
        public Unit Distance { get; set; }
    }
}