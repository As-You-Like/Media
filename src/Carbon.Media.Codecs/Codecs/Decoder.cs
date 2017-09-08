using System;

namespace Carbon.Media.Codecs
{
    public abstract class Decoder : Codec
    {
        // returns the number of decoded frames
        public virtual int Decode(Packet packet) => throw new NotImplementedException();

        public virtual bool TryGetFrame(Frame frame) => throw new NotImplementedException();
    }
}