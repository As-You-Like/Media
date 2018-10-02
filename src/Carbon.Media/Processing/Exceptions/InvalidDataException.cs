namespace Carbon.Media.Processing
{
    public sealed class InvalidDataException : ProcessingException
    {
        public InvalidDataException(string message)
            : base(message)
        {
        }

    }
}