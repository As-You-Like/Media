namespace Carbon.Media.Processing
{
    public sealed class BitRateFilter : IProcessor
    {
        public BitRateFilter(BitRate value)
        {
            Value = value;
        }

        public BitRate Value { get; }

        #region ToString()

        // https://en.wikipedia.org/wiki/Bit_rate
        // NOTE: Commonly lowercased

        public string Canonicalize()
        {
            return $"bitrate({Value.Value})";
        }

        public override string ToString() => Canonicalize();

        #endregion

        public static BitRateFilter Create(in CallSyntax syntax)
        {
            return new BitRateFilter(BitRate.Parse(syntax.Arguments[0].Value));
        }
    }
}

// e.g. bitrate(500kbs)



// volume(0.5)
