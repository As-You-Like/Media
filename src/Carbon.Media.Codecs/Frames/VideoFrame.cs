namespace Carbon.Media
{
    public class VideoFrame : Frame
    {
        public VideoFrame(PixelFormat format, int width, int height, IBuffer[] planes, int[] strides)
        {
            Planes  = planes;
            Width   = width;
            Height  = height;
            Format  = format;
            Strides = strides;
        }

        public int Width { get; }

        public int Height { get; }

        public Rational? AspectRatio { get; set; }

        public PixelFormat Format { get; set; }

        public ColorSpace ColorSpace { get; set; }
        
        public PictureType PictureType { get; set; }

        public IBuffer[] Planes { get; } // AKA picture lines?

        /// <summary>
        /// The length (size) of each picture line (plane?)
        /// </summary>
        public int[] Strides { get; }

        public int Quality { get; set; }

        // MotionVectors

        // IsInterlaced

        // IsKeyFrame

        public override void Dispose()
        {
            foreach (var plane in Planes)
            {
                plane.Dispose();
            }
        }
    }
}