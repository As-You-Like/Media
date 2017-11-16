// Based on .NET Source code

namespace System.Text
{
    public static class StringBuilderCache
    {
        [ThreadStatic]
        static StringBuilder cachedInstance;

        public static StringBuilder Aquire()
        {
            var sb = cachedInstance;

            if (sb == null)
            {
                return new StringBuilder(100);
            }

            sb.Length = 0;

            cachedInstance = null;

            return sb;
        }

        public static void Free(StringBuilder sb)
        {
            cachedInstance = sb;
        }

        public static string ExtractAndRelease(StringBuilder sb)
        {
            var text = sb.ToString();

            cachedInstance = sb;

            return text;
        }
    }
}