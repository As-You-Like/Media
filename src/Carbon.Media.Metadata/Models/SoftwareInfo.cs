using System.Runtime.Serialization;

namespace Carbon.Media.Metadata
{
    [DataContract]
    public class SoftwareInfo
    {
        // e.g. Photoshop
        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}