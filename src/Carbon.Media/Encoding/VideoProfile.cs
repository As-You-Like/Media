using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Carbon.Media
{
    [DataContract]
    public class VideoProfile
    {
        [DataMember(Name = "bitRate")]
        public BitRate? BitRate { get; set; }

        [DataMember(Name = "minBitRate")]
        public BitRate? MinBitRate { get; set; } // -minrate

        [DataMember(Name = "maxBitRate")]
        public BitRate? MaxBitRate { get; set; } // -maxrate

        [DataMember(Name = "bufferSize")]
        public long? BufferSize { get; set; } // -bufsize

        [DataMember(Name = "codec")]
        public string Codec { get; set; }

        [DataMember(Name = "width")]
        public int Width { get; set; }

        [DataMember(Name = "height")]
        public int Height { get; set; }

        [DataMember(Name = "frameRate")]
        public double? FrameRate { get; set; } // Rational?

        /// <summary>
        /// A maximum framerate (if not fixed)
        /// </summary>
        [DataMember(Name = "maxFrameRate", EmitDefaultValue = false)]
        public double? MaxFrameRate { get; set; } // Rational?

        [DataMember(Name = "keyFrameDistance", EmitDefaultValue = false)]
        public TimeSpan? KeyFrameDistance { get; set; }

        [DataMember(Name = "upscale"), DefaultValue(false)]
        public bool Upscale { get; set; }

        [DataMember(Name = "quality")]
        public int? Quality { get; set; }

        [DataMember(Name = "scaleMode"), DefaultValue(ResizeFlags.Fit)]
        public ResizeFlags ScaleMode { get; set; }
    }
}


// avc1.42E01E (H264 Baseline)
// avc1.4D401E (H264 Main)
// theora
// vp8