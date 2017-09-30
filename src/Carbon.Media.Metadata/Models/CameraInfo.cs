using System.Runtime.Serialization;

namespace Carbon.Media
{
    [DataContract]
    public class CameraInfo
    {
        public CameraInfo() { }

        public CameraInfo(string make, string model)
        {
            Make  = make;
            Model = model;
        }

        // e.g. Canon
        [DataMember(Name = "make", Order = 1)]
        public string Make { get; set; }

        // e.g. EOS5
        [DataMember(Name = "model", Order =2)]
        public string Model { get; set; }

        [DataMember(Name = "serialNumber", Order = 3, EmitDefaultValue = false)]
        public string SerialNumber { get; set; }
    }
}