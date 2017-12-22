using System;
using System.IO;
using System.Text;

namespace Carbon.Media.Drawing
{
    public class CommandReader : IDisposable
    {
        private readonly StringReader reader;

        private int currentCode;
        private char currentChar = '0';

        private const char eof = '\0';

        public CommandReader(string text)
        {
            this.reader = new StringReader(text);

            Next();
        }

        public bool TryRead(out DrawCommand shape)
        {
            while (currentChar == ',')
            {
                Next();
            }

            switch (currentChar)
            {
                case eof : shape = null; return false;
                default  : shape = ReadShape(); return true;
            }
        }

        public DrawCommand ReadShape()
        {
            var sb = StringBuilderCache.Aquire();

            do
            {
                sb.Append(currentChar);
            }
            while ((currentChar = Next()) != ')' && currentChar != eof);

            sb.Append(Next()); // read )

            return DrawCommand.Parse(StringBuilderCache.ExtractAndRelease(sb));
        }

        private char Next()
        {
            if (currentChar == eof)
            {
                throw new EndOfStreamException();
            }

            currentCode = reader.Read();

            currentChar = currentCode == -1 ? eof : (char)currentCode;

            return currentChar;
        }

        public void Dispose()
        {
            reader.Dispose();
        }
    }
}

