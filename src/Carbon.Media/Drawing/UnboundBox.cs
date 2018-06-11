namespace Carbon.Media.Drawing
{
    public class UnboundBox
    {
        public UnboundBox() { }

        public UnboundBox(Unit x, Unit y, Unit width, Unit height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        // Alignment?
        
        public Unit? X { get; set; }
        public Unit? Y { get; set; }
        public Unit? Width { get; set; } // 50% || 50px
        public Unit? Height { get; set; }
        public UnboundPadding Padding { get; set; }
    }
}

// A box with raw units...