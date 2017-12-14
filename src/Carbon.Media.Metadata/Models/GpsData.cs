using System.Runtime.Serialization;

namespace Carbon.Media.Metadata
{
    [DataContract]
    public class GpsData
    {
        [DataMember(Name = "longitude", Order = 1, EmitDefaultValue = false)]
        public double Longitude { get; set; }

        [DataMember(Name = "latitude", Order = 2, EmitDefaultValue = false)]
        public double Latitude { get; set; }

        [DataMember(Name = "altitude", Order = 3, EmitDefaultValue = false)]
        public Unit Altitude { get; set; } 
        
        [DataMember(Name = "speed", Order = 4, EmitDefaultValue = false)]
        public Unit Speed { get; set; }
    }
}


// f32 accuracy: 2.4 meters	
// f64 accuracy: nanometer 