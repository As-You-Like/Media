using System.Runtime.Serialization;

namespace Carbon.Media.Metadata
{
    [DataContract]
    public class PageInfo
    {
        public PageInfo() { }

        public PageInfo(int width, int height, ExifOrientation orientation = ExifOrientation.None)
        {
            Width = width;
            Height = height;
            Orientation = orientation;
        }

        [DataMember(Name = "width", Order = 1)]
        public int Width { get; set; }

        [DataMember(Name = "height", Order = 2)]
        public int Height { get; set; }

        [DataMember(Name = "orientation", Order = 3, EmitDefaultValue = false)]
        public ExifOrientation Orientation { get; set; }

        [DataMember(Name = "rotation", Order = 4, EmitDefaultValue = false)]
        public int? Rotation { get; set; }

        #region Boxes

        [DataMember(Name = "mediaBox", Order = 10, EmitDefaultValue = false)]
        public BoundingBox? MediaBox { get; set; }

        [DataMember(Name = "bleedBox", Order = 11, EmitDefaultValue = false)]
        public BoundingBox? BleedBox { get; set; }

        [DataMember(Name = "trimBox", Order = 12, EmitDefaultValue = false)]
        public BoundingBox? TrimBox { get; set; }

        [DataMember(Name = "artBox", Order = 13, EmitDefaultValue = false)]
        public BoundingBox? ArtBox { get; set; }

        [DataMember(Name = "cropBox", Order = 14, EmitDefaultValue = false)]
        public BoundingBox? CropBox { get; set; }

        #endregion
    }
}


// [ MediaBox
//   [ Bleed Box 
//      [ Trim Box 
//         [ Art Box ]
//      ]
//   ]
// ]


// https://www.enfocus.com/en/blog/thinking-outside-the-page-box-a-guide-to-pdf-page-boxes


/*
{
    format: "pdf",
    pages: [ 
        {
            number: 1,
            width: 100,
            height: 100,
            cropBox: { x, y, width, height } 
            mediaBox:  { } 
       }
    ]
}

*/
