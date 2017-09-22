using System;

namespace Carbon.Media.Codecs
{
    public abstract class Decoder : Codec
    {
        public virtual bool IsEof { get; }

        // returns the number of decoded frames
        public virtual int Decode(Packet packet) => throw new NotImplementedException();

        public virtual bool TryGetFrame(Frame frame) => throw new NotImplementedException();
    }


    public abstract class VideoDecoder : Decoder
    {
    }

    public abstract class AudioDecoder : Decoder
    {
    }
}