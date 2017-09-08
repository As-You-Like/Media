using System;

namespace Carbon.Media.Containers
{
    public abstract class Container : IDisposable
    {
        // public abstract ContainerId Id { get; }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}