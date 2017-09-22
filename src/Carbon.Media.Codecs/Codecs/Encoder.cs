using System;

namespace Carbon.Media.Codecs
{
    public abstract class Encoder : Codec
    {
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
    }

    public abstract class AudioEncoder : Encoder
    {
    }
}