namespace Carbon.Media.Processors
{
    public struct Position
    {
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }

        public int Y { get; }
    }  
}

// Canvas(500,500, color: red)
// Padding is applied to the scale & becomes a margin in draw phase...