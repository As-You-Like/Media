using System.Runtime.Serialization;

namespace Carbon.Media.Processing
{
    [DataContract]
    public readonly struct Position
    {
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        [DataMember(Name = "x", Order = 1)]
        public int X { get; }

        [DataMember(Name = "y", Order = 2)]
        public int Y { get; }
    }  
}

// Canvas(500,500, color: red)
// Padding is applied to the scale & becomes a margin in draw phase...