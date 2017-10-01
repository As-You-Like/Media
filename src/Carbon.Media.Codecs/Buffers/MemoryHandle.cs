using System;
using System.Runtime.InteropServices;

namespace Carbon.Media
{
    public unsafe struct MemoryHandle : IDisposable
    {
        private IRetainable owner;
        private void* pointer;
        private readonly GCHandle handle;

        public MemoryHandle(IRetainable owner, void* pointer, GCHandle handle = default)
        {
            this.owner   = owner ?? throw new ArgumentNullException(nameof(owner));
            this.handle  = handle;
            this.pointer = pointer;
        }

        public void* Pointer => pointer;

        public void Dispose()
        {
            if (handle.IsAllocated)
            {
                handle.Free();
            }

            if (owner != null)
            {
                owner.Release();
                owner = null;
            }

            pointer = null;
        }
    }
}