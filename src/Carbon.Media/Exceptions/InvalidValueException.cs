using System;

namespace Carbon.Media
{
    public class InvalidValueException : Exception
    {
        public InvalidValueException(string name, string value)
            : base($"Invalid {name} value. Was '{value}'.")
        {
            Name = name;
            Value = value; 
        }
        
        public string Name { get; }

        public string Value { get; }

        // TODO: Documentation on valid valids
    }
}