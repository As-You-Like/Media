
using System;

namespace Carbon.Media
{
    public sealed class VideoResampler : IDisposable
    {
        public VideoResampler(VideoFormatInfo source, VideoFormatInfo target, SwsFlags flags = SwsFlags.FastBilinear)
        {
            Source = source ?? throw new ArgumentNullException(nameof(source));
            Target = target ?? throw new ArgumentNullException(nameof(target));
            Context = SwsContext.Create(source, target, flags);
        }

        public VideoFormatInfo Source { get; }

        public VideoFormatInfo Target { get; }

        public SwsContext Context { get; }

        public void Resample(VideoFrame source, VideoFrame target)
        {
            Context.Scale(source, target).EnsureSuccess();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);

            Dispose(true);
        }

        public void Dispose(bool disposing)
        {
            Context.Dispose();
        }

        ~VideoResampler()
        {
            Dispose(false);
        }
    }
}