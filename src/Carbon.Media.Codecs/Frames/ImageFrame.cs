using System;

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

        public PixelFormat Format { get; }

        /// <summary>
        /// the size of each picture line 
        /// </summary>
        public int[] Strides { get; }

        public int Quality { get; set; }

        // MotionVectors

        // IsInterlaced
        // IsKeyFrame
    }

    public enum FrameFlags
    {
        KeyFrame = 1,
        Interlaced = 2,

        // Picture types
        Intra,
        Predicted,
        BiDirectionalPredicted,
        VOP,
        SwitchingIntra,
        SwitchingPredicted,
        BiType
    }
}
