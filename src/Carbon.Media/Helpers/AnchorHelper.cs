namespace Carbon.Media
{
    public static class AnchorHelper
    {
        public static CropAnchor Parse(string text)
        {
            switch (text)
            {
                case "b":
                case "s":
                case "bottom": return CropAnchor.Bottom;

                case "bl": return CropAnchor.Bottom | CropAnchor.Left;
                case "sw": return CropAnchor.Bottom | CropAnchor.Left;
                case "br": return CropAnchor.Bottom | CropAnchor.Right;
                case "se": return CropAnchor.Bottom | CropAnchor.Right;

                case "c":
                case "center": return CropAnchor.Center;

                case "w":
                case "west":
                case "l":
                case "left":  return CropAnchor.Left;

                case "e":
                case "east":
                case "r":
                case "right": return CropAnchor.Right;

                case "n":
                case "north":
                case "t":
                case "top": return CropAnchor.Top;

                case "nw":
                case "tl": return CropAnchor.Top | CropAnchor.Left;

                case "ne":
                case "tr": return CropAnchor.Top | CropAnchor.Right;

                default: throw new System.Exception("Unexpected anchor:" + text);
            }
        }
    }
}
