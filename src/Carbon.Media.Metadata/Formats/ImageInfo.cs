using System.Runtime.Serialization;
using Carbon.Media.Metadata.Exif;

namespace Carbon.Media.Metadata
{
    [DataContract]
    public class ImageInfo
    {
        public ImageInfo() { }

        public ImageInfo(string format, int width, int height)
        {
            Format = format;
            Width  = width;
            Height = height;
        }

        [DataMember(Name = "format", Order = 1)]
        public string Format { get; set; }

        [DataMember(Name = "codec", Order = 2, EmitDefaultValue = false)]
        public string Codec { get; set; }

        [DataMember(Name = "blob", Order = 3, EmitDefaultValue = false)]
        public BlobInfo Blob { get; set; }

        [DataMember(Name = "pixelFormat", Order = 4, EmitDefaultValue = false)]
        public PixelFormat PixelFormat { get; set; }

        [DataMember(Name = "width", Order = 5, EmitDefaultValue = false)]
        public int Width { get; set; }

        [DataMember(Name = "height", Order = 6, EmitDefaultValue = false)]
        public int Height { get; set; }

        [DataMember(Name = "colorSpace", Order = 9, EmitDefaultValue = false)]
        public ColorSpace ColorSpace { get; set; }

        [DataMember(Name = "resolution", Order = 10, EmitDefaultValue = false)]
        public ImageResolution Resolution { get; set; }

        // Duration = 10

        [DataMember(Name = "frames", Order = 11, EmitDefaultValue = false)]
        public ImageFrameInfo[] Frames { get; set; }

        #region Ownership & Rights (30)

        [DataMember(Name = "copyright", Order = 30, EmitDefaultValue = false)]
        public string Copyright { get; set; }

        [DataMember(Name = "creator", Order = 31, EmitDefaultValue = false)]
        public ActorInfo Creator { get; set; }

        [DataMember(Name = "owner", Order = 32, EmitDefaultValue = false)]
        public ActorInfo Owner { get; set; }

        #endregion

        #region Exif Metadata (40)

        [DataMember(Name = "exif", Order = 40, EmitDefaultValue = false)]
        public ExifMetadata Exif { get; set; }

        [DataMember(Name = "camera", Order = 41, EmitDefaultValue = false)]
        public CameraInfo Camera { get; set; }
        
        [DataMember(Name = "exposure", Order = 42, EmitDefaultValue = false)]
        public ExposureInfo Exposure { get; set; }

        [DataMember(Name = "lens", Order = 43, EmitDefaultValue = false)]
        public LensInfo Lens { get; set; }

        [DataMember(Name = "lighting", Order = 44, EmitDefaultValue = false)]
        public LightingInfo Lighting { get; set; }

        [DataMember(Name = "location", Order = 45, EmitDefaultValue = false)]
        public GpsData Location { get; set; }
   
        [DataMember(Name = "software", Order = 47, EmitDefaultValue = false)]
        public SoftwareInfo Software { get; set; }

        [DataMember(Name = "subject", Order = 48, EmitDefaultValue = false)]
        public SubjectInfo Subject { get; set; }
       
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
