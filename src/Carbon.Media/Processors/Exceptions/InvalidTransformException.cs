using System;

namespace Carbon.Media
{
    public class InvalidTransformException : Exception
    {
        public InvalidTransformException(int index, string message)
            : base(message)
        {
            Index = index;
        }

        public InvalidTransformException(int index, string message, Exception innerException)
            : base(message, innerException)
        {
            Index = index;
        }
        

        // Invalid Argument?

        public string Name { get; set; }

        public int Index { get; }
    }

    // ArgumentOutOfRange
}