using System;
using FFmpeg.AutoGen;

namespace Carbon.Media.Formats
{
    public abstract class Format : IDisposable
    {
        private bool isDisposed = false;

        protected Format(FormatId id)
        {
            Id = id;
            Context = new FormatContext();
        }

        protected Format(FormatContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public FormatId Id { get; }

        public abstract FormatType Type { get; }

        public FormatContext Context { get; }

        public MediaStream[] Streams => Context.Streams;

        public MediaStream GetStream(MediaType type)
        {
            foreach (var stream in Streams)
            {
                if (stream.Type == type)
                {
                    return stream;
                }
            }

            return null;
        }

        public unsafe void Dump(int streamIndex)
        {
            ffmpeg.av_dump_format(Context.Pointer, streamIndex, null, Type == FormatType.Demuxer ? 1 : 0);
        }


        internal virtual void OnDisposing() { }

        // public void Probe() { }

        public virtual void Dispose()
        {
            if (isDisposed) return;

            Context?.Dispose();

            OnDisposing();

            isDisposed = true;
        }
    }
}