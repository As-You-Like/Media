using System;
using System.Runtime.InteropServices;

namespace Carbon.Media
{
    // AudioBuffer
    // FrameBuffer
    // ...

    public unsafe class Buffer : IBuffer, IRetainable
    {
        private bool isDisposed = false;
        private IntPtr pointer;
        private int length;
        int referenceCount = 0;

        public Buffer(IntPtr pointer, int length)
        {
            this.pointer = pointer;
            this.length = length;
        }

        public int Length => length;

        public Span<byte> Span => new Span<byte>((void*)pointer, length);

        public MemoryHandle Retain(bool pin = true)
        {
            referenceCount++;

            return new MemoryHandle(this, (void*)pointer);
        }

        #region IRetainable

        public void Retain()
        {
            referenceCount++;
        }

        public bool Release()
        {
            referenceCount--;

            return true;
        }

        #endregion

        public static Buffer Allocate(int size)
        {
            // HGlobal = ProcessHeap
            // AllocCoTaskMem = COMHeap

            return new Buffer(Marshal.AllocHGlobal(size), size);
        }

        public void Free()
        {
            // todo: ensure there are not oustanding references...

            if (pointer != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(pointer);

                // FreeCoTaskMem = COMHeap
                pointer = IntPtr.Zero;
            }
        }

        public void Dispose()
        {
            if (!isDisposed)
            {
                Dispose(true);
                GC.SuppressFinalize(this);
                isDisposed = true;
            }
        }

        public void Dispose(bool disposing)
        {
            Free();
        }

        ~Buffer()
        {
            Dispose(true);
        }
    }
}