using System;

namespace Carbon.Media.Codecs
{
    public abstract class Encoder : Codec
    {
        // returns the number of encoded packets in the queue
        public virtual int Encode(Frame frame)
        {
            throw new NotImplementedException();
        }

        public virtual bool TryGetPacket(Packet packet)
        {
            throw new NotImplementedException();
        }
    }
}