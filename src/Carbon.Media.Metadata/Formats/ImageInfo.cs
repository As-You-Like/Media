using System;
using System.Runtime.Serialization;

namespace Carbon.Media.Metadata
{
    [DataContract]
    public class ImageResolution
    {
        [DataMember(Name = "x", Order = 1)]
        public double X { get; set; }

        [DataMember(Name = "y", Order = 2)]
        public double Y { get; set; }
    }

    [DataContract]
    public class ImageInfo
    {
        [DataMember(Name = "format", Order = 1)]
        public string Format { get; set; }
        
        // 2 = Codec

        [DataMember(Name = "pixelFormat", Order = 3, EmitDefaultValue = false)]
        public PixelFormat PixelFormat { get; set; }

        [DataMember(Name = "width", Order = 4, EmitDefaultValue = false)]
        public int Width { get; set; }

        [DataMember(Name = "height", Order = 5, EmitDefaultValue = false)]
        public int Height { get; set; }

        [DataMember(Name = "orientation", Order = 6, EmitDefaultValue = false)]
        public ExifOrientation Orientation { get; set; }

        [DataMember(Name = "colorSpace", Order = 7, EmitDefaultValue = false)]
        public ColorSpace ColorSpace { get; set; }

        [DataMember(Name = "resolution", Order = 8, EmitDefaultValue = false)]
        public ImageResolution Resolution { get; set; }

        // Duration = 10

        [DataMember(Name = "frames", Order = 11, EmitDefaultValue = false)]
        public ImageFrameInfo[] Frames { get; set; }
        
        #region Timestamps (20)

        [DataMember(Name = "created", Order = 20, EmitDefaultValue = false)]
        public DateTime? Created { get; }

        [DataMember(Name = "modified", Order = 21, EmitDefaultValue = false)]
        public DateTime? Modified { get; }

        #endregion

        #region Ownership & Rights (30)

        [DataMember(Name = "copyright", Order = 30, EmitDefaultValue = false)]
        public string Copyright { get; set; }

        [DataMember(Name = "creator", Order = 31, EmitDefaultValue = false)]
        public ActorInfo Creator { get; set; }

        [DataMember(Name = "owner", Order = 32, EmitDefaultValue = false)]
        public ActorInfo Owner { get; set; }

        #endregion

        #region Exif Metadata (40)

        [DataMember(Name = "camera", Order = 40, EmitDefaultValue = false)]
        public CameraInfo Camera { get; set; }
        
        [DataMember(Name = "exposure", Order = 41, EmitDefaultValue = false)]
        public ExposureInfo Exposure { get; set; }

        [DataMember(Name = "lens", Order = 42, EmitDefaultValue = false)]
        public LensInfo Lens { get; set; }

        [DataMember(Name = "lighting", Order = 43, EmitDefaultValue = false)]
        public LightingInfo Lighting { get; set; }

        [DataMember(Name = "location", Order = 44, EmitDefaultValue = false)]
        public GpsData Location { get; set; }
   
        [DataMember(Name = "sensing", Order = 45, EmitDefaultValue = false)]
        public SensingInfo Sensing { get; set; }

        [DataMember(Name = "software", Order = 46, EmitDefaultValue = false)]
        public SoftwareInfo Software { get; set; }

        [DataMember(Name = "subject", Order = 47, EmitDefaultValue = false)]
        public SubjectInfo Subject { get; set; }
        
        [DataMember(Name = "whiteBalance", Order = 48, EmitDefaultValue = false)]
        public ExifWhiteBalance WhiteBalance { get; set; }

        #endregion
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
