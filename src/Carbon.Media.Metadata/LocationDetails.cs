namespace Carbon.Media.Metadata
{
    public struct LocationDetails
    {
        public double Longitude { get; set; }

        public double Latitude { get; set; }

        public double Altitude { get; set; } // TODO, use a unit
                                             // Name
    }
}

// http://msdn.microsoft.com/en-us/library/windows/desktop/ee719904(v=vs.85).aspx

// http://nicholasarmstrong.com/2010/02/exif-quick-reference/

// http://www.sno.phy.queensu.ca/~phil/exiftool/TagNames/EXIF.html
/*
 creator: "x"																// Dave Gorum <dave@carbonmade.com>			// EMAIL FORMAT
 owner: "x"																	// Dave Gorum <dave@carbonmade.com>			(Rights Holder)?
 licences: [ "1", "2" ]
 camera: "Nikon D5"															// Combine Make & Model
 created: "2012-05-15T15:01:19Z"
 modified: "2012-05-15T15:01:19Z" 
 location: { longitude: "x", latitude: "x", name: "New York, NY" }
*/
