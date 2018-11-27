namespace Carbon.Media.Processing
{
    public sealed class GrayscaleFilter : IFilter
    {
        public GrayscaleFilter(float amount)
        {
            if (amount < 0 || amount > 1)
            {
                throw ExceptionHelper.OutOfRange(nameof(amount), 0, 1, amount);
            }

            // CSS clamps to 1

            Amount = amount;
        }

        public float Amount { get; }

        public string Canonicalize() => $"grayscale({Amount})";

        public override string ToString() => Canonicalize();

        public static GrayscaleFilter Create(in CallSyntax syntax)
        {
            return new GrayscaleFilter(Unit.Parse(syntax.Arguments[0].Value.ToString()));
        }
    }
}

// grayscale(1)
