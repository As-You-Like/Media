﻿namespace Carbon.Media.Codecs
{
    public class CodecContext
    {
        public Codec Codec { get; set; }
        
        // MaxBFrames
        // QuantyFactor
        // FrameStategry
        // QuantyOffset
        // HasBFrames

        #region Audio

        public virtual int SampleRate { get; set; }

        public virtual SampleFormat SampleFormat { get; set; }

        public virtual int ChannelCount { get; set; }

        public virtual ChannelLayout ChannelLayout { get; set; }

        #endregion

        #region Image / Video

        public ColorSpace ColorSpace  { get; }

        public PixelFormat PixelFormat { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public int CodecWidth { get; set; }

        public int CodecHeight { get; set; }

        #endregion

        public virtual BitRate? BitRate { get; set; }
        
        public virtual BitRate? BitrateTolerance { get; set; }

        public virtual Rational TimeBase { get; set; }

        // FrameIndex
        // BlockAlign
        // FrameSize
        // SampleFormat

        // CodecWidth
        // CodedHeight

        // GopSize

        // Compression

        // ticksPerFrame
        // TimeBase
        // Delay

    }
}
