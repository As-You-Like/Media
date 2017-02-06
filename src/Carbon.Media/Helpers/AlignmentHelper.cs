namespace Carbon.Media
{
    public static class AnchorHelper
    {
        public static CropAnchor Parse(string text)
        {
            switch (text)
            {
                case "b":
                case "bottom": return CropAnchor.Bottom;

                case "bl": return CropAnchor.Bottom | CropAnchor.Left;
                case "br": return CropAnchor.Bottom | CropAnchor.Right;

                case "c":
                case "center": return CropAnchor.Center;

                case "l": return CropAnchor.Left;
                case "r": return CropAnchor.Right;

                case "t":
                case "top": return CropAnchor.Top;

                case "tl": return CropAnchor.Top | CropAnchor.Left;
                case "tr": return CropAnchor.Top | CropAnchor.Right;

                default: return CropAnchor.Unknown;
            }
        }
    }
}
