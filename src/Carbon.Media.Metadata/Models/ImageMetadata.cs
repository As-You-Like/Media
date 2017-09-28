using System;
using System.Runtime.Serialization;

namespace Carbon.Media.Metadata
{
    [DataContract]
    public class DocumentMetadata
    {

        FrameInfo[] Pages { get; set; }
    }

    [DataContract]
    public class ImageMetadata
    {
        [DataMember(Name = "format", Order = 1)]
        public ImageFormat Format { get; set;}

        [DataMember(Name = "codecs", Order = 2)]
        public string[] Codecs { get; set; }

        [DataMember(Name = "width", Order = 3)]
        public int Width { get; set; }

        [DataMember(Name = "height", Order = 4)]
        public int Height { get; set; }

        [DataMember(Name = "orientation", Order = 5)]
        public ExifOrientation? Orientation { get; set; }

        [DataMember(Name = "pixelFormat", Order = 6)]
        public PixelFormat PixelFormat { get; set; }

        [DataMember(Name = "colorSpace")]
        public ColorSpace ColorSpace { get; set; }

        [DataMember(Name = "subject")]
        public SubjectInfo Subject { get; set; }

        [DataMember(Name = "exposure")]
        public ExposureInfo Exposure { get; set; }

        [DataMember(Name = "shutter")] // speed
        public string Shutter { get; set; }

        [DataMember(Name = "sensor")]
        public SensorInfo Sensor { get; set; }

        [DataMember(Name = "whiteBalance")]
        public WhiteBalance WhiteBalance { get; set; }
        

        [DataMember(Name = "location")]
        public LocationDetails? Location { get; set; }

        [DataMember(Name = "lighting")]
        public LightingInfo Lighting { get; set; }

        [DataMember(Name = "camera")]
        public CameraInfo Camera { get; set; }

        [DataMember(Name = "created")]
        public DateTime? Created { get; }
        
        [DataMember(Name = "frames")]
        public FrameInfo[] Frames { get; set; }
        
        // RepeatCount ?

        // TODO: Pages?

        // Taken

        [DataMember(Name = "modified")]
        public DateTime? Modified { get; }
    }
}

/*
 creator    : { name: "Dave" }												
 owner      : "x"															
 licences   : [ "1", "2" ]
 camera     : { make: "Nikon", model: "D5" },
 created    : "2012-05-15T15:01:19Z"
 modified   : "2012-05-15T15:01:19Z" 
 location   : { longitude: "x", latitude: "x", name: "New York, NY" }
*/
