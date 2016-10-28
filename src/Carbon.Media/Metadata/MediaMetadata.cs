using System;

namespace Carbon.Media
{
    public class MediaMetadata
    {
        public string Type { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public MediaOrientation Orientation { get; set; }

        public ColorSpace ColorSpace { get; set; }

        public ColorProfile ColorProfile { get; set; }

        public DateTime? DateTime { get; set; }
    }

    // "/xmp/photoshop:ICCProfile : sRGB IEC61966-2.1"
}
