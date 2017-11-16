using System;
using System.IO;
using System.Text;

namespace Carbon.Media.Drawing
{
    public class CommandReader : IDisposable
    {
        private StringBuilder sb = new StringBuilder();

        private readonly StringReader reader;

        private int currentCode;
        private char currentChar = '0';

        private const char eof = '\0';

        public CommandReader(string text)
        {
            this.reader = new StringReader(text);

            Next();
        }

        public bool TryRead(out Shape shape)
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

        public Shape ReadShape()
        {
            do
            {
                sb.Append(currentChar);
            }
            while ((currentChar = Next()) != ')' && currentChar != eof);

            sb.Append(Next()); // read )

            return Shape.Parse(sb.Extract());
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


    internal static class StringBuilderExtensions
    {
        public static string Extract(this StringBuilder sb)
        {
            var text = sb.ToString();

            sb.Clear();

            return text;
        }
    }
}

