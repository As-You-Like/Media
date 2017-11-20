namespace Carbon.Media
{
    public unsafe class VideoFrame : Frame
    {
        public int Width => pointer->width;

        public int Height => pointer->height;

        /// <summary>
        /// The order the frame is encoded within the bitstream (coded picture number)
        /// </summary>
        public long CodedIndex => pointer->coded_picture_number;

        /// <summary>
        /// The order the frame is presented (e.g. display picture number)
        /// </summary>
        public long PresentationIndex => pointer->display_picture_number;

        public Rational? AspectRatio { get; set; }

        public PixelFormat Format { get; set; }

        public ColorSpace ColorSpace { get; set; }

        public PictureType PictureType => (PictureType)pointer->pict_type;

        public Buffer[] Planes { get; } // AKA picture lines?

        /// <summary>
        /// The length (size) of each picture line (plane?)
        /// </summary>
        public int[] Strides { get; }

        public int Quality { get; set; }

        // MotionVectors

        // IsInterlaced

        // IsKeyFrame

        public new void Dispose()
        {
            foreach (var plane in Planes)
            {
                plane.Dispose();
            }

            base.Dispose();
        }
    }
}