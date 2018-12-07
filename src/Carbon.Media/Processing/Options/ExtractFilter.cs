using System;

namespace Carbon.Media.Processing
{
    public readonly struct ExtractFilter
    {
        public ExtractFilter(ExtractFilterType type, double value)
        {
            Type = type;
            Value = value;
        }

        public ExtractFilterType Type { get; }

        public double Value { get; }

        public override string ToString()
        {
            switch (Type)
            {
                case ExtractFilterType.Poster   : return "poster";
                case ExtractFilterType.Frame    : return "frame(" + Value + ")";
                case ExtractFilterType.Page     : return "page(" + Value + ")";
                case ExtractFilterType.Time     : return "time(" + Value + ")";
            }

            throw new Exception("Unexpected extract type:" + Type);
        }
    }

    // time(5.456)/

    public enum ExtractFilterType
    {
        Frame     = 1,
        Page      = 2,
        Poster    = 3,
        Time      = 4,

    }
}