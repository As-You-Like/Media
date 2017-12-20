using System;
using System.Text;

namespace Carbon.Media.Processors
{
    public class SepiaFilter : IFilter, ICanonicalizable
    {
        public SepiaFilter(float amount)
        {
            #region Preconditions

            if (amount < 0)
            {
                throw new ArgumentException("Must be >= 0", nameof(amount));
            }

            #endregion

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

        public static SepiaFilter Parse(string segment)
        {
            int argStart = segment.IndexOf('(') + 1;

            segment = segment.Substring(argStart, segment.Length - argStart - 1);
            
            return new SepiaFilter((float)Unit.Parse(segment).Value);
        }
    }
}

// CSS: sepia(0.5)