using System.Runtime.Serialization;

namespace Carbon.Media.Metadata
{
    [DataContract]
    public class SubjectInfo
    {
        [DataMember(Name = "subject")]
        public string Type { get; set; }

        // in meters
        [DataMember(Name = "distance")]
        public double Distance { get; set; }
    }
}