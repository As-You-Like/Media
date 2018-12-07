using System.Text;

namespace Carbon.Media.Processing
{
    public sealed class PaletteFilter : IProcessor, ICanonicalizable
    {
        public PaletteFilter(int count, string format = null)
        {
            if (count <= 0 || count > 256)
            {
                throw ExceptionHelper.OutOfRange(nameof(count), 1, 256, count);
            }

            Count = count;
            Format = format;
        }


        // Type (Warm, Cool, Brown... )
        public int Count { get; }

        public string Format { get; }

        #region ICanonicalizable

        public string Canonicalize()
        {
            var sb = StringBuilderCache.Aquire();

            WriteTo(sb);

            return StringBuilderCache.ExtractAndRelease(sb);
        }

        public void WriteTo(StringBuilder sb)
        {
            sb.Append("palette(");

            sb.Append(Count);

            if (Format != null)
            {
                sb.Append(',');
                sb.Append(Format);
            }

            sb.Append(')');
        }

        #endregion

        public override string ToString() => Canonicalize();

        public static PaletteFilter Create(in CallSyntax syntax)
        {
            var args = syntax.Arguments;

            int count = int.Parse(args[0].Value.ToString());

            return new PaletteFilter(count, args.Length == 2 ? args[1].Value.ToString() : null);
        }
    }
}