using System;

namespace Carbon.Media.Drawing
{
    public ref struct DrawArgumentReader
    {
        private int position;
        private ReadOnlySpan<char> text;

        public DrawArgumentReader(ReadOnlySpan<char> text)
        {
            this.text = text;
            this.position = 0;
        }

        public bool TryRead(out Argument argument)
        {
            if (!IsEof && text[position] == ',')
            {
                position++;
            }

            if (IsEof)
            {
                argument = default;

                return false;
            }


            argument = ReadArgument();

            return true;
        }

        public bool IsEof => text.Length <= position;

        public Argument ReadArgument()
        {
            var start = position;
            int count = 0;

            string name = null;
            string value;

            // circle(radius:10)
            
            do
            {
                if (text[position] == '(')
                {
                    ReadConstructorArgs(out int read);

                    count += read;
                }
                else if (text[position] == ':')
                {
                    name = text.Slice(start, count).Trim().ToString();

                    start = position + 1;
                    count = -1;
                }

                count++;
                position++;
            }
            while (!IsEof && text[position] != ',');

            value = text.Slice(start, count).Trim().ToString();

            return new Argument(name, value);
        }

        private void ReadConstructorArgs(out int read)
        {
            read = 0;

            // (radius:10)

            do
            {
                read++;
                position++;
            }
            while (text[position] != ')' && !IsEof);

         
        }
    }

    // draw(circle(100), x: 0, y: 0)


}

