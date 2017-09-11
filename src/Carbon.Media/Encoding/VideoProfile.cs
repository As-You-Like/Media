using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.Serialization;

namespace Carbon.Media
{
    public class VideoProfile
    {
        public int? Quality { get; set; }

        public BitRate? BitRate { get; set; }

        public BitRate? MinBitRate { get; set; } // -minrate

        public BitRate? MaxBitRate { get; set; } // -maxrate

        public long? BufferSize { get; set; } // -bufsize

        // avc1.42E01E (H264 Baseline)
        // avc1.4D401E (H264 Main)
        // theora
        // vp8
        public string Codec { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        /// <summary>
        /// A fixed frame rate
        /// </summary>
        public double? FrameRate { get; set; }

        /// <summary>
        /// A maximum framerate
        /// </summary>
        public double? MaxFrameRate { get; set; }

        public TimeSpan? KeyFrameDistance { get; set; }

        [DefaultValue(false)]
        public bool Upscale { get; set; }

        [DefaultValue(ResizeFlags.Fit)]
        public ResizeFlags ScaleMode { get; set; }

        #region Helpers

        [IgnoreDataMember]
        public Size Size
        {
            get => new Size(Width, Height);
            set
            {
                Width = value.Width;
                Height = value.Height;
            }
        }

        #endregion
    }
}