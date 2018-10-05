namespace Carbon.Media.Drawing
{
    public sealed class Circle : Shape
    {
        public Circle(Unit radius)
        {
            Radius = radius;
        }

        public Unit Radius { get; }


        public override string ToString()
        {
            return "circle(" + Radius + ")";
        }

        public static Circle Create(in CallSyntax syntax)
        {
            var radius = Unit.Parse(syntax.Arguments[0].Value.ToString());

            return new Circle(radius);
        }
    }
}