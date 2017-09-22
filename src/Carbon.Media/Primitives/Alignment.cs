namespace Carbon.Media
{
    using static Alignment;

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

    public static class AlignmentExtensions
    {
        public static string ToLower(this Alignment alignment)
        {
            switch (alignment)
            {
                case Top    : return "top";
                case Left   : return "left";
                case Bottom : return "bottom";
                case Right  : return "right";
                case Middle : return "middle";
                case Center : return "center";
                default     : return "unknown";
            }
        }
    }
}