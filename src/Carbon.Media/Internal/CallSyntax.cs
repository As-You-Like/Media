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

        public bool TryGetValue(string name, out string value)
        {
            for (int i = 0; i < Arguments.Length; i++)
            {
                ref Argument arg = ref Arguments[i];

                if (arg.Name == name)
                {
                    value = arg.Value;

                    return true;
                }
            }

            value = null;

            return false;
        }

        public static CallSyntax Parse(string text)
        {
            if (text is null)
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