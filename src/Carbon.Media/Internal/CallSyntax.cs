using System;

namespace Carbon.Media
{
    public readonly struct CallSyntax
    {
        public CallSyntax(string name, Argument[] arguments)
        {
            Name      = name;
            Arguments = arguments;
        }

        public string Name { get; }

        public Argument[] Arguments { get; }

        public static CallSyntax Parse(string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            int argStart = text.IndexOf('(') + 1;

            if (argStart == 0)
            {
                return new CallSyntax(text, Array.Empty<Argument>());
            }

            var name = text.Substring(0, argStart - 1);

            return new CallSyntax(name, ArgumentList.Parse(text.Substring(argStart, text.Length - argStart - 1)));
        }
    }
}