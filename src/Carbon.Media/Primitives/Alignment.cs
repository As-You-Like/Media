namespace Carbon.Media
{
    // TextAlignment?

    public enum Alignment
    {
        Top     = 1,
        Left    = 2,
        Bottom  = 3,
        Right   = 4,
        Middle  = 5,
        Center  = 6
    }

    // Justify?

    public static class AlignExtensions
    {
        public static string ToLower(this Alignment alignment)
        {
            switch (alignment)
            {
                case Alignment.Top    : return "top";
                case Alignment.Left   : return "left";
                case Alignment.Bottom : return "bottom";
                case Alignment.Right  : return "right";
                case Alignment.Middle : return "middle";
                case Alignment.Center : return "center";
                default               : return "unknown";
            }
        }
    }
}