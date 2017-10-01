using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Carbon.Media
{
    [DataContract]
    public class VideoProfile
    {
        public VideoProfile() { }

        public VideoProfile(string codec, BitRate bitRate, int width, int height)
        {
            Codec   = codec;
            BitRate = bitRate;
            Width   = width;
            Height  = height;
        }

        [DataMember(Name = "codec", Order = 1)]
        public string Codec { get; set; }

        [DataMember(Name = "width", Order = 2)]
        public int Width { get; set; }

        [DataMember(Name = "height", Order = 2)]
        public int Height { get; set; }

        [DataMember(Name = "bitRate", Order = 4)]
        public BitRate? BitRate { get; set; }

        [DataMember(Name = "minBitRate", Order = 5)]
        public BitRate? MinBitRate { get; set; } // -minrate

        [DataMember(Name = "maxBitRate", Order = 6)]
        public BitRate? MaxBitRate { get; set; } // -maxrate
        
        [DataMember(Name = "frameRate", Order = 8)]
        public double? FrameRate { get; set; } // Rational?

        /// <summary>
        /// A maximum framerate (if not fixed)
        /// </summary>
        [DataMember(Name = "maxFrameRate", Order = 9, EmitDefaultValue = false)]
        public double? MaxFrameRate { get; set; } // Rational?

        [DataMember(Name = "keyFrameDistance", Order = 10, EmitDefaultValue = false)]
        public TimeSpan? KeyFrameDistance { get; set; }

        [DataMember(Name = "upscale", Order = 11), DefaultValue(false)]
        public bool Upscale { get; set; }

        [DataMember(Name = "quality", Order = 12)]
        public int? Quality { get; set; }

        [DataMember(Name = "scaleMode", Order = 13), DefaultValue(ResizeFlags.Fit)]
        public ResizeFlags ScaleMode { get; set; }
    }
}


// avc1.42E01E (H264 Baseline)
// avc1.4D401E (H264 Main)
// theora
// vp8