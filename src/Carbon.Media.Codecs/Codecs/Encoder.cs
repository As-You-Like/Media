using System;

namespace Carbon.Media.Codecs
{
    public abstract class Encoder : Codec
    {
        public Encoder(CodecId id)
            : base(id) { }

        public virtual bool Encode(Frame frame)
        {
            throw new NotImplementedException();
        }

        public virtual bool TryGetPacket(Packet packet)
        {
            throw new NotImplementedException();
        }
    }

    public abstract class VideoEncoder : Encoder
    {
        public VideoEncoder(CodecId id)
            : base(id) { }
    }

    public abstract class AudioEncoder : Encoder
    {
        public AudioEncoder(CodecId id)
            : base(id) { }

    }

    // VIDEO
    // maxBFrames
    // BQuantFactor
    // BQuantOffset
    // IQuantFactor
    // IQuantOffset
    // LumiMasking
    // temporalCplxMasking
    // SpacialCplxMasking
    // PMasking
    // DarkMasking
    // PreditionMode
    // AspectRatio
    // DiaSize
    // LastPredicaators
    // PreMe
    // MePreComparision
    // PreDiaSize
    // MeSubpelQuality
    // MeRange
    // IntraQuantBias
    // InterQuantBias
    // ColorRange
    // ColorSpace

    // FrameRate
    // TimeBase
    // Compression
    // Quality
    // BitRate (Average)
    // MaxBitRate
    // BitRateTolerance
}