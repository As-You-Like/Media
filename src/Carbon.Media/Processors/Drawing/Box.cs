namespace Carbon.Media
{
    public class Box
    {
        public Unit? X       { get; set; }  
        public Unit? Y       { get; set; }
        public Unit? Width   { get; set; } // e.g. 50% || 50px
        public Unit? Height  { get; set; }
        public Unit? Padding { get; set; } // TODO: Breakout sides
    }
}