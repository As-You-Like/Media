using System;

namespace Carbon.Media
{
    public abstract class MediaSource : IDisposable
    {
        public long Position { get; set; }

        // Probed if not specified

        // Stream Open

        public virtual void Dispose()
        {
        }
    }
}
