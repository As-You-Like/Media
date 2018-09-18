using System;

namespace Carbon.Media.Processing
{
    public class ProfileFilter : IFilter
    {
        public ProfileFilter(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public string Name { get; }

        public string Canonicalize() => "profile(" + Name + ")";

        public static ProfileFilter Create(in CallSyntax syntax)
        {
            return new ProfileFilter(syntax.Arguments[0].Value);
        }
    }
}
