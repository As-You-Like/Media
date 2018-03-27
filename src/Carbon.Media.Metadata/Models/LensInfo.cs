using System.Runtime.Serialization;

namespace Carbon.Media.Metadata
{
    [DataContract]
    public class LensInfo
    {
        public LensInfo() { }

        public LensInfo(Make make, string model)
        {
            Make  = make;
            Model = model;
        }

        [DataMember(Name = "id", Order = 1, EmitDefaultValue = false)]
        public long Id { get; set; }

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