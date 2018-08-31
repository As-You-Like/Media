using System;
using Carbon.Media.IO;
using FFmpeg.AutoGen;

namespace Carbon.Media.Formats
{
    public abstract class Format : IDisposable
    {
        private bool isDisposed = false;
        protected IOContext ioContext;

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

        public MediaStream GetStream(MediaStreamType type)
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

        // public void Probe() { }

        public void Dispose()
        {
            if (isDisposed) return;

            // Console.WriteLine("Disposing " + this.GetType().Name);
           
            Context?.Dispose();
            
            ioContext?.Dispose();

            ioContext = null;

            isDisposed = true;
        }
    }
}