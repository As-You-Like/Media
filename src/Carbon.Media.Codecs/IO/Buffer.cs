using System;
using System.Runtime.InteropServices;

namespace Carbon.Media
{
    public unsafe class Buffer : IDisposable
    {
        private IntPtr pointer;
        private int length;

        public Buffer(IntPtr pointer, int length)
        {
            this.pointer = pointer;
            this.length  = length;
        }

        public int Length => length;

        public Span<byte> Span => new Span<byte>((void*)pointer, length);

        public IntPtr Pointer => pointer;
        
        public static Buffer Allocate(int size)
        {
            // HGlobal = ProcessHeap

            return new Buffer(Marshal.AllocHGlobal(size), size);
        }
        
        public void Resize(int size)
        {
            if (size != Length)
            {
                // Reallocate the & update the pointer
                pointer = Marshal.ReAllocHGlobal(pointer, (IntPtr)size);

                this.length = size;
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);

            Dispose(true);
        }

        public void Dispose(bool disposing)
        {
            if (pointer != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(pointer); //  FreeCoTaskMem = COMHeap

                pointer = IntPtr.Zero;
            }
        }

        ~Buffer()
        {
            Dispose(false);
        }
    }
}