namespace Carbon.Media
{
    public class VideoFrame : Frame
    {
        public VideoFrame(IBuffer data, PixelFormat format, int width, int height, int[] strides)
            : base(data)
        {
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

        /// <summary>
        /// the size of each picture line (plane?)
        /// </summary>
        public int[] Strides { get; }

        public int Quality { get; set; }

        // MotionVectors

        // IsInterlaced
        // IsKeyFrame
    }
}
