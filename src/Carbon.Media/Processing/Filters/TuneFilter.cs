using System;

namespace Carbon.Media.Processing
{
    public sealed class TuneFilter : IFilter
    {
        public TuneFilter(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public string Name { get; }

        public string Canonicalize() => "tune(" + Name + ")";

        public static TuneFilter Create(in CallSyntax syntax)
        {
            return new TuneFilter(syntax.Arguments[0].Value.ToString());
        }
    }
}
