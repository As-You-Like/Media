using System;

namespace Carbon.Media
{
    public interface IBuffer : IDisposable
    {
        // RefCount

        IntPtr Pointer { get; }

        int Length { get; }

        // Free
        // Unref
        // Ref
    }
    
    // GCHandle?

    // Provides a way to access a managed object from unmanaged memory
}