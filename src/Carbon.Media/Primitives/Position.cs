namespace Carbon.Media.Processors
{
    public readonly struct Position
    {
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public readonly int X;

        public readonly int Y;
    }  
}

// Canvas(500,500, color: red)
// Padding is applied to the scale & becomes a margin in draw phase...