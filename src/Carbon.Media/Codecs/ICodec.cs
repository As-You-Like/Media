namespace Carbon.Media
{
    /// <summary>
    /// A codec determines syntax and semantics of a bitstream
    /// </summary>
    public interface ICodec
    {
        CodecId Id { get; }
    }
}