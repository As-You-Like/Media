using System.Runtime.Serialization;

namespace Carbon.Media.Metadata
{
    [DataContract]
    public class CameraInfo
    {
        public CameraInfo() { }

        public CameraInfo(Make make, Model model, string serialNumber = null)
        {
            Make         = make;
            Model        = model;
            SerialNumber = serialNumber;
        }

        [DataMember(Name = "id", Order = 1, EmitDefaultValue = false)]
        public long Id { get; set; }

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