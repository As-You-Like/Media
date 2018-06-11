using System.Drawing;
using System.Runtime.Serialization;

namespace Carbon.Media
{
    [DataContract]
    public readonly struct Box
    {
        public Box(Rectangle rectangle)
            : this(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height) { }

        public Box(double x, double y, double width, double height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        [DataMember(Name = "x", Order = 1)]
        public double X { get; }

        [DataMember(Name = "y", Order = 2)]
        public double Y { get; }

        [DataMember(Name = "width", Order = 3)]
        public double Width { get; }

        [DataMember(Name = "height", Order = 4)]
        public double Height { get; }
    }
}

/*
PageBox ArtBox { get; }

PageBox BleedBox { get; }

PageBox CropBox { get; }

PageBox MediaBox { get; }

PageBox TrimBox { get; }
*/

// { 
//   boxes: [ 
//     { type: "media", ... },
//     { type: "bleed", ... },
//     { type: "trim",  ... },
//     { type: "art",   ... },
// ]

// [ MediaBox
//   [ Bleed Box 
//      [ Trim Box 
//         [ Art Box ]
//      ]
//   ]
// ]