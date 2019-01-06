using System;
using System.Collections.Generic;

using Carbon.Media.Internal;

namespace Carbon.Media
{
    internal static class ArgumentList
    {
        public static Argument[] Parse(ReadOnlySpan<char> text)
        {
            var reader = new ArgumentReader(text);

            var args = new List<Argument>();

            while (reader.TryRead(out var arg))
            {
                args.Add(arg);
            }

            return args.ToArray();
        }
    }
}