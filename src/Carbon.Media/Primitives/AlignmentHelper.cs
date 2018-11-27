namespace Carbon.Media
{
    using static Alignment;

    public static class AlignmentHelper
    {
        public static Alignment Parse(string text)
        {
            switch (text.ToLower())
            {
                case "top"    : return Top;
                case "right"  : return Right;
                case "bottom" : return Bottom;
                case "left"   : return Left;
                case "center" : return Center;
            }

            throw new InvalidValueException("alignment", text);
        }
    }
}