using System;

namespace Carbon.Media
{
    public interface IBuffer : IDisposable
    {
        // RefCount

        IntPtr Pointer { get; }

        long Length { get; }

        // Free


        // Unref
        // Ref

    }
    
    // GCHandle?

    // Provides a way to access a managed object from unmanaged memory.


    // For FFMPEG, this should be an AVBuffer
}