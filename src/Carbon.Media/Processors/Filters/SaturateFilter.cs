﻿using System;
using System.Text;

namespace Carbon.Media.Processors
{
    public class SaturateFilter : IFilter, ICanonicalizable
    {
        public SaturateFilter(double amount)
        {
            if (amount < -2 || amount > 2)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), amount, "Must be between -2 and 2");
            }

            Amount = amount;
        }

        public double Amount { get; }

        public static SaturateFilter Create(in CallSyntax syntax)
        {
            return new SaturateFilter(Unit.Parse(syntax.Arguments[0].Value).Value);
        }

        #region ToString()

        public string Canonicalize()
        {
            var sb = StringBuilderCache.Aquire();

            WriteTo(sb);

            return StringBuilderCache.ExtractAndRelease(sb);
        }

        public void WriteTo(StringBuilder sb)
        {
            sb.Append("saturate(");
            sb.Append(Amount);
            sb.Append(')');
        }

        public override string ToString() => Canonicalize();

        #endregion
    }
}