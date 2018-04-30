﻿using System;

namespace Carbon.Media.Processors
{
    public class BrightnessFilter : IFilter
    {
        public BrightnessFilter(float amount)
        {
            if (amount < -10 || amount > 10)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), amount, "Must be between -10 and 10");
            }

            Amount = amount;
        }

        public float Amount { get; }

        public static BrightnessFilter Create(in CallSyntax syntax)
        {
            return new BrightnessFilter(float.Parse(syntax.Arguments[0].Value));
        }

        public string Canonicalize() => $"brightness({Amount})";

        public override string ToString() => Canonicalize();
    }
}