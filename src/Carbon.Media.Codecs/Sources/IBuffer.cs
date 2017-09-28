using System;

namespace Carbon.Media
{
    public interface IBuffer : IDisposable
    {
        // Span

        int Length { get; }

        // MemoryHandle Retain(bool pin) { } // provides a pointer for accessing the memory
    }
}


// Replace with Memory

