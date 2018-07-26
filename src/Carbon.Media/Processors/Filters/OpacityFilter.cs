﻿using System;

namespace Carbon.Media.Processors
{
    public class OpacityFilter : IFilter
    {
        public OpacityFilter(double amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Must be >= 0", nameof(amount));
            }

            if (amount > 1) // clamp to 1
            {
                amount = 1;
            }

            Amount = amount;
        }

        // range: 0 (full effect) - 1 (unchanged)
        public double Amount { get; }

        public string Canonicalize() => $"opacity({Amount})";

        public override string ToString() => Canonicalize();

        public static OpacityFilter Create(in CallSyntax syntax)
        {
            return new OpacityFilter(Unit.Parse(syntax.Arguments[0].Value).Value);
        }
    }
}