using System;

namespace Carbon.Media.Processors
{
    public class BackgroundFilter : IFilter
    {
        public BackgroundFilter(string color)
        {
            Color = color ?? throw new ArgumentNullException(nameof(color));
        }

        public string Color { get; }

        public string Canonicalize() => $"background({Color})";

        public override string ToString() => Canonicalize();

        public static BackgroundFilter Parse(string text)
        {
            int argStart = text.IndexOf('(') + 1;

            text = text.Substring(argStart, text.Length - argStart - 1);

            return new BackgroundFilter(text);
        }
    }
}