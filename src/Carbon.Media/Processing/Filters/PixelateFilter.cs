using System;

namespace Carbon.Media.Processing
{
    public class PixelateFilter : IFilter
    {
        public PixelateFilter(int amount)
        {
            if (amount < 0 || amount > 10_000)
            {
                throw ExceptionHelper.OutOfRange(nameof(amount), 0, 10_000, amount);
            }

            Amount = amount;
        }

        public int Amount { get; }

        public string Canonicalize() => $"pixelate({Amount})";

        public override string ToString() => Canonicalize();

        public static PixelateFilter Create(in CallSyntax syntax)
        {
            return new PixelateFilter(int.Parse(syntax.Arguments[0].Value.ToString()));
        }
    }
}