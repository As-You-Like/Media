using System;

namespace Carbon.Media.Formats
{
    public abstract class Format : IDisposable
    {

        public Format(FormatId id)
        {
            Id = id;


        }

        public FormatId Id { get; }

        public void Probe() { }


        public FormatContext Context { get; }

        public virtual void Dispose()
        {
            
        }

        
    }
}