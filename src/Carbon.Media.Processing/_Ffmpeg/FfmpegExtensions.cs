using System.Runtime.CompilerServices;

namespace Carbon.Media
{
    internal static class FfmpegExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void EnsureSuccess(this int result)
        {
            if (result < 0)
            {
                throw new FFmpegException(result);
            }
        }
    }
}