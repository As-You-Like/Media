using System.Runtime.Serialization;

namespace Carbon.Media
{
    [DataContract]
    public class CameraInfo
    {
        public CameraInfo() { }

        public CameraInfo(string make, string model)
        {
            Make = make;
            Model = model;
        }

        // Id = 1
        // e.g. Canon
        // aka Manfacturer
        [DataMember(Name = "make", Order = 2)]
        public string Make { get; set; }

        // e.g. EOS5
        [DataMember(Name = "model", Order = 3)]
        public string Model { get; set; }

        [DataMember(Name = "serialNumber", Order = 4, EmitDefaultValue = false)]
        public string SerialNumber { get; set; }
    }
}