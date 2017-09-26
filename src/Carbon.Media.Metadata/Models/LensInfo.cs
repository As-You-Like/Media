using System.Runtime.Serialization;

namespace Carbon.Media
{
    [DataContract]
    public class LensInfo
    {
        // e.g. Canon
        [DataMember(Name = "make", Order = 1)]
        public string Make { get; set; }

        [DataMember(Name = "model", Order = 2)]
        public string Model { get; set; }

        [DataMember(Name = "serialNumber", Order = 3)]
        public string SerialNumber { get; set; }
    }
}