using System;

namespace Carbon.Media.Drawing
{
    public sealed class PathShape : Shape
    {
        public PathShape(string content)
        {
            Content = content ?? throw new ArgumentNullException(nameof(content));

        }

        // M150 0 L75 200 L225 200 Z

        public string Content { get; }


        public override string ToString()
        {
            return "path(" + Content + ")";
        }

        public static PathShape Create(in CallSyntax syntax)
        {
            string content = null;


            int i = 0;

            foreach (var (k, v) in syntax.Arguments)
            {
                if (i == 0)
                {
                    content = v.ToString();

                    continue;
                }



                i++;
            }

            return new PathShape(content);
        }
    }
}

/*
path(M150 0 L75 200 L225 200 Z)
*/
