using System.Runtime.Serialization;

namespace Carbon.Media.Metadata
{
    [DataContract]
    public class GpsData
    {
        public GpsData() { }

        public GpsData(double latitude, double longitude)
        {
            Latitude  = latitude;
            Longitude = longitude;
        }

        // e.g. 35.89421911
        [DataMember(Name = "latitude", Order = 1, EmitDefaultValue = false)]
        public double Latitude { get; set; }

        // e.g. 139.94637467
        [DataMember(Name = "longitude", Order = 2, EmitDefaultValue = false)]
        public double Longitude { get; set; }

        [DataMember(Name = "altitude", Order = 3, EmitDefaultValue = false)]
        public Unit? Altitude { get; set; } 
        
        [DataMember(Name = "speed", Order = 4, EmitDefaultValue = false)]
        public Unit? Speed { get; set; }
    }
}

// ISO 6709
// Standard representation of geographic point location by coordinates is the international standard for 
// representation of latitude, longitude and altitude for geographic point locations.
// https://en.wikipedia.org/wiki/ISO_6709

// f32 accuracy: 2.4 meters	
// f64 accuracy: nanometer 