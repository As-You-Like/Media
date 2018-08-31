using System.Runtime.Serialization;

namespace Carbon.Media.Metadata
{
    [DataContract]
    public struct ImageResolution
    {
        [DataMember(Name = "x", Order = 1)]
        public double X { get; set; }

        [DataMember(Name = "y", Order = 2)]
        public double Y { get; set; }
    }
}

/*
 format      : "jpeg",
 width       : 100,
 height      : 100,
 pixelFormat : "Rgba32",
 creator     : { name: "Dave" }												
 owner       : "x"															
 licences    : [ "1", "2" ]
 camera      : { make: "Nikon", model: "D5" },
 created     : "2012-05-15T15:01:19Z"
 modified    : "2012-05-15T15:01:19Z" 
 location    : { longitude: "x", latitude: "x", name: "New York, NY" }
*/
