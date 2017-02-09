using System;
using System.Runtime.Serialization;

namespace Carbon.Media
{
    public class ImageMetadata
    {
        [DataMember(Name = "type")]
        public string Type { get; set; }

        [DataMember(Name = "width")]
        public int Width { get; set; }

        [DataMember(Name = "height")]
        public int Height { get; set; }

        [DataMember(Name = "orientation", EmitDefaultValue = false)]
        public ImageOrientation Orientation { get; set; }

        // [DataMember(Name = "colorSpace", EmitDefaultValue = false)]
       //  public ColorSpace ColorSpace { get; set; }

        // TODO: what if it has mutiple profiles?
        // [DataMember(Name = "colorProfile", EmitDefaultValue = false)]
        // public ColorProfile ColorProfile { get; set; }

        [DataMember(Name = "dateTime")]
        public DateTime? DateTime { get; set; } // Timestamp?
    }

    // "/xmp/photoshop:ICCProfile q: sRGB IEC61966-2.1"
}