using System;

namespace Carbon.Media.Processing
{
    public class PresetFilter : IFilter
    {
        public PresetFilter(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public string Name { get; }
        
        public string Canonicalize() => "preset(" + Name + ")";

        public static PresetFilter Create(in CallSyntax syntax)
        {
            return new PresetFilter(syntax.Arguments[0].Value);
        }
    }
}
