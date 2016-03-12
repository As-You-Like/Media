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

        public string Camera { get; set; }  // Canon/EOS5

        public string Software { get; set; }

        public float? Longitude { get; set; }

        public float? Latitude { get; set; }

        public string PixelFormat { get; set; } // rgba

        public DateTime? DateTime { get; set; }
    }

    public class CameraInfo
    {
        // Canon
        public string Make { get; set; }

        // EOS5
        public string Model { get; set; }

        // TODO: Canonicalize
    }

    // "/xmp/photoshop:ICCProfile : sRGB IEC61966-2.1"
}
