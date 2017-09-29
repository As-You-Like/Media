using System.Runtime.Serialization;

namespace Carbon.Media.Metadata
{
    [DataContract]
    public struct LocationDetails
    {
        [DataMember(Name = "longitude", Order = 1, EmitDefaultValue = false)]
        public double Longitude { get; set; }

        [DataMember(Name = "latitude", Order = 2, EmitDefaultValue = false)]
        public double Latitude { get; set; }

        [DataMember(Name = "altitude", Order = 3, EmitDefaultValue = false)]
        public double Altitude { get; set; } 
    }
}

// http://msdn.microsoft.com/en-us/library/windows/desktop/ee719904(v=vs.85).aspx

// http://nicholasarmstrong.com/2010/02/exif-quick-reference/

// http://www.sno.phy.queensu.ca/~phil/exiftool/TagNames/EXIF.html