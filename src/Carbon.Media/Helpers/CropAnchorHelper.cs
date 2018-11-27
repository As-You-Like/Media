using System;

namespace Carbon.Media
{
    using static CropAnchor;

    public static class CropAnchorHelper
    {
        public static CropAnchor Parse(string text)
        {
            if (text is null) throw new ArgumentNullException(nameof(text));


            if (text.Length == 1)
            {
                return Parse(text[0]);
            }

            if (text.Length == 2)
            {
                return Parse(text[0]) | Parse(text[1]);   
            }

            switch (text)
            {
                case "bottom" : return Bottom;
                case "center" : return Center;
                case "left"   : return Left;
                case "right"  : return Right;
                case "top"    : return Top;
            }
            
            throw new Exception("Invalid anchor :" + text);
        }

        private static CropAnchor Parse(char code)
        {
            switch (code)
            {
                case 't': return Top;
                case 'r': return Right;
                case 'b': return Bottom;
                case 'l': return Left;
                case 'c': return Center;

                default: throw new Exception("Invalid anchor:" + code);
            }
        }
    }
}