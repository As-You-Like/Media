using System;
using System.Text;

namespace Carbon.Media.Processing
{
    public class SepiaFilter : IFilter, ICanonicalizable
    {
        public SepiaFilter(float amount)
        {
            if (amount < 0) throw new ArgumentException("Must be >= 0", nameof(amount));

            if (amount > 1)  // clamped to 1
            {
                amount = 1;
            }

            Amount = amount;            
        }

        // range: 0 (unchanged) - 1 (full effect)
        public float Amount { get; }

        #region ICanonicalizable

        public string Canonicalize()
        {
            var sb = StringBuilderCache.Aquire();

            WriteTo(sb);

            return StringBuilderCache.ExtractAndRelease(sb);
        }
        
        public void WriteTo(StringBuilder sb)
        {
            sb.Append("sepia(");
            sb.Append(Amount);
            sb.Append(')');
        }

        public override string ToString() => Canonicalize();

        #endregion

        public static SepiaFilter Create(in CallSyntax syntax)
        {
            return new SepiaFilter(Unit.Parse(syntax.Arguments[0].Value.ToString()));
        }
    }
}

// CSS: sepia(0.5)