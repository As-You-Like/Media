using System;

namespace Carbon.Media.Processors
{
    public class OpacityFilter : IFilter
    {
        public OpacityFilter(float amount)
        {
            #region Validation

            if (amount < 0)
            {
                throw new ArgumentException("Must be >= 0", nameof(amount));
            }

            #endregion

            if (amount > 1) // clamp to 1
            {
                amount = 1;
            }

            Amount = amount;
        }

        // range: 0 (full effect) - 1 (unchanged)
        public float Amount { get; }

        public string Canonicalize() => $"opacity({Amount})";

        public override string ToString() => Canonicalize();

        public static OpacityFilter Create(CallSyntax syntax)
        {
            return new OpacityFilter((float)Unit.Parse(syntax.Arguments[0].Value).Value);
        }
    }
}