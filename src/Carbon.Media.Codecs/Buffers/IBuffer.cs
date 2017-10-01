using System;

namespace Carbon.Media
{
    public interface IBuffer : IDisposable
    {
        int Length { get; }

        MemoryHandle Retain(bool pin);
    }
}