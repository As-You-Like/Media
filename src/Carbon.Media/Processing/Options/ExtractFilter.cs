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
                case ExtractFilterType.Frame      : return "frame(" + Value + ")";
                case ExtractFilterType.Page       : return "page(" + Value + ")";
                case ExtractFilterType.Timestamp  : return "timestamp(" + Value + ")";
            }

            throw new Exception("Unexpected extract type:" + Type);
        }
    }

    // time(5.456)/

    public enum ExtractFilterType
    {
        Frame = 1,
        Timestamp = 2,
        Page = 3
    }
}