namespace Carbon.Media
{
    using static Alignment;

    public enum Alignment
    {
        Top     = 1,
        Left    = 2,
        Bottom  = 3,
        Right   = 4,
        Center  = 5
    }

    public static class AlignmentHelper
    {
        public static Alignment Parse(string text)
        {
            switch (text.ToLower())
            {
                case "top": return Top;
                case "left": return Left;
                case "bottom": return Bottom;
                case "right": return Right;
                case "center": return Center;
            }

            throw new InvalidValueException("alignment", text);
        }
    }

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
                case Center : return "center";
                default     : return "unknown";
            }
        }
    }
}