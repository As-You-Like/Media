using System;
using System.Runtime.Serialization;

namespace Carbon.Media.Metadata
{
    [DataContract]
    public class ImageMetadata
    {
        [DataMember(Name = "format", Order = 1)]
        public string Format { get; set;}

        [DataMember(Name = "codecs", Order = 2, EmitDefaultValue = false)]
        public string Codec { get; set; }
        
        // Codecs = 3?

        [DataMember(Name = "width", Order = 3)]
        public int Width { get; set; }

        [DataMember(Name = "height", Order = 4)]
        public int Height { get; set; }

        [DataMember(Name = "orientation", Order = 5, EmitDefaultValue = false)]
        public ExifOrientation? Orientation { get; set; }

        [DataMember(Name = "pixelFormat", Order = 6, EmitDefaultValue = false)]
        public PixelFormat PixelFormat { get; set; }

        [DataMember(Name = "colorSpace", Order = 7, EmitDefaultValue = false)]
        public ColorSpace ColorSpace { get; set; }

        [DataMember(Name = "frames", Order = 20, EmitDefaultValue = false)]
        public FrameInfo[] Frames { get; set; }
        
        [DataMember(Name = "camera", Order = 30, EmitDefaultValue = false)]
        public CameraInfo Camera { get; set; }

        [DataMember(Name = "exposure", Order = 31, EmitDefaultValue = false)]
        public ExposureInfo Exposure { get; set; }

        [DataMember(Name = "lens", Order = 32, EmitDefaultValue = false)]
        public LensInfo Lens { get; set; }

        [DataMember(Name = "lighting", Order = 33, EmitDefaultValue = false)]
        public LightingInfo Lighting { get; set; }

        [DataMember(Name = "location", Order = 34, EmitDefaultValue = false)]
        public GpsData Location { get; set; }

        [DataMember(Name = "sensor", Order = 35, EmitDefaultValue = false)] // sensing?
        public SensorInfo Sensor { get; set; }

        [DataMember(Name = "software", Order = 36, EmitDefaultValue = false)]
        public SoftwareInfo Software { get; set; }

        [DataMember(Name = "subject", Order = 27, EmitDefaultValue = false)]
        public SubjectInfo Subject { get; set; }    

        [DataMember(Name = "whiteBalance", Order = 28, EmitDefaultValue = false)]
        public WhiteBalance WhiteBalance { get; set; }

        [DataMember(Name = "created", Order = 40, EmitDefaultValue = false)]
        public DateTime? Created { get; }

        [DataMember(Name = "modified", Order = 41, EmitDefaultValue = false)]
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
