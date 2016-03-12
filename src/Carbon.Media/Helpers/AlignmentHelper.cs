namespace Carbon.Media
{
    public static class AlignmentHelper
    {
        public static Alignment ParseAlignment(string text)
        {
            switch (text)
            {
                case "b":
                case "bottom": return Alignment.Bottom;

                case "bl": return Alignment.BottomLeft;
                case "br": return Alignment.BottomRight;

                case "c":
                case "center": return Alignment.Center;

                case "l": return Alignment.Left;
                case "r": return Alignment.Right;

                case "t":
                case "top": return Alignment.Top;

                case "tl": return Alignment.TopLeft;
                case "tr": return Alignment.TopRight;

                default: return Alignment.Unknown;
            }
        }
    }
}
