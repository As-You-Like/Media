namespace Carbon.Media
{
    public interface ICodec
    {
        CodecId Id { get; }
    }
}

// A codec determines syntax and semantics of a bitstream.