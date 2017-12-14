using System.Runtime.Serialization;

namespace Carbon.Media
{
    [DataContract]
    public class LensInfo
    {
        public LensInfo() { }

        public LensInfo(string make, string model)
        {
            Make  = make;
            Model = model;
        }

        // Id = 1

        // e.g. Canon
        [DataMember(Name = "make", Order = 2, EmitDefaultValue = false)]
        public string Make { get; set; }

        [DataMember(Name = "model", Order = 3, EmitDefaultValue = false)]
        public string Model { get; set; }

        [DataMember(Name = "serialNumber", Order = 4, EmitDefaultValue = false)]
        public string SerialNumber { get; set; }

        // FocalLength
        // MaximumAperture
        // DiagonalAngleOfView
    }
}