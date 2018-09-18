using System;
using System.Runtime.Serialization;

namespace Carbon.Media.Processing
{
    [DataContract]
    public readonly struct Position : IEquatable<Position>
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

        public bool Equals(Position other) => X == other.X && Y == other.Y;
    }
}