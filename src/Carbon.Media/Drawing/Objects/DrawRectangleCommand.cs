namespace Carbon.Media.Drawing
{
    public sealed class Rect : Shape
    {
        public Rect(
           Unit width,
           Unit height)
        {
            Width = width;
            Height = height;
        }
        
        public Unit Width { get; }

        public Unit Height { get; }

        public override string ToString()
        {
            return "rectangle(" + Width + "," + Height + ")";

        }

        public static Rect Create(in CallSyntax syntax)
        {
          

            var box = new UnboundBox();

            var i = 0;

            foreach (var (k, v) in syntax.Arguments)
            {
                if (k is null) // positional
                {
                    switch (i)
                    {
                        case 0: box.Width = Unit.Parse(v);  break;
                        case 1: box.Height = Unit.Parse(v); break;
                    }

                    i++;

                    continue;
                }

           
            }

            return new Rect(box.Width.Value, box.Height.Value);
        }

    }
}

/*
rectangle(100,100,red,mode:burn)
*/
