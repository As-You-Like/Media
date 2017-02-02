namespace Carbon.Media
{
    public static class AlignmentHelper
    {
        public static CropAnchor ParseAlignment(string text)
        {
            switch (text)
            {
                case "b":
                case "bottom": return CropAnchor.Bottom;

                case "bl": return CropAnchor.BottomLeft;
                case "br": return CropAnchor.BottomRight;

                case "c":
                case "center": return CropAnchor.Center;

                case "l": return CropAnchor.Left;
                case "r": return CropAnchor.Right;

                case "t":
                case "top": return CropAnchor.Top;

                case "tl": return CropAnchor.TopLeft;
                case "tr": return CropAnchor.TopRight;

                default: return CropAnchor.Unknown;
            }
        }
    }
}
