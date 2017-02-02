using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Carbon.Media
{
    public class VideoProfile
    {
        public int? Quality { get; set; }

        public int? Bitrate { get; set; }

        public int? MaxBitrate { get; set; }

        // avc1.42E01E (H264 Baseline)
        // avc1.4D401E (H264 Main)
        // theora
        // vp8
        public MediaCodec Codec { get; set; }

        /// <summary>
        /// Should be divisible by 16
        /// </summary>
        // [DivisibleBy(4)]
        public int Width { get; set; }

        /// <summary>
        /// Should be divisible by 16
        /// </summary>
        // [DivisibleBy(4)]
        public int Height { get; set; }

        /// <summary>
        /// A fixed frame rate
        /// </summary>
        public double? FrameRate { get; set; }

        /// <summary>
        /// A maximum framerate
        /// </summary>
        public double? MaxFrameRate { get; set; }

        public TimeSpan KeyFrameDistance { get; set; }

        [DefaultValue(false)]
        public bool Upscale { get; set; }

        [DefaultValue(ScaleMode.Fit)]
        public ScaleMode ScaleMode { get; set; }

        #region Helpers

        [IgnoreDataMember]
        public Size Size
        {
            get { return new Size(Width, Height); }
            set
            {
                Width = value.Width;
                Height = value.Height;
            }
        }

        #endregion
    }
}