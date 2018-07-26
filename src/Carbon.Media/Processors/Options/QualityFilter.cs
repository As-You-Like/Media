using System;

namespace Carbon.Media.Processors
{
    public sealed class QualityFilter : IProcessor
    {
        public QualityFilter(int value)
        {
            if (value < 0 && value > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(value), value, "Must be between 0 & 100");
            }

            Value = value;
        }

        public int Value { get; }

        #region ToString()

        public string Canonicalize()
        {
            return $"quality({Value})";
        }

        public override string ToString() => Canonicalize();

        #endregion

        public static QualityFilter Create(in CallSyntax syntax)
        {
            return new QualityFilter(int.Parse(syntax.Arguments[0].Value));
        }
    }
}