using System;

namespace Carbon.Media.Drawing
{
    public abstract class Shape
    {
        public static Shape Parse(string text)
        {
            var syntax = CallSyntax.Parse(text);

            switch (syntax.Name)
            {
                case "circle"       : return Circle.Create(syntax);
                case "image"        : return ImageSource.Create(syntax);
                case "path"         : return PathShape.Create(syntax);
                case "rectangle"    : return Rect.Create(syntax);
                case "square"       : return Rect.Create(syntax);
                case "text"         : return TextObject.Create(syntax);
            }

            throw new Exception("Invalid Command:" + syntax.Name);
        }
    }
}

// draw(circle(100), fill: red, stroke: black, mode: burn)
