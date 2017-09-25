using System;
using System.Runtime.InteropServices;

namespace Carbon.Media
{
    public class Buffer : IBuffer
    {
        private IntPtr pointer;
        private int length;

        private Buffer(IntPtr pointer, int length)
        {
            this.pointer = pointer;
            this.length = length; // aka capasity
        }

        public IntPtr Pointer => pointer;

        public int Length => length;

        public void Resize(int newSize)
        {
            if (pointer == IntPtr.Zero)
            {
                pointer = Marshal.AllocHGlobal(newSize);
                length = newSize;
            }
            else if (length < newSize)
            {
                pointer = Marshal.ReAllocHGlobal(pointer, (IntPtr)(newSize));
                length = newSize;
            }
        }

        public void Dispose()
        {
            Free();
        }

        public static Buffer Allocate(int size)
        {
            return new Buffer(Marshal.AllocHGlobal(size), size);
        }

        public void Free()
        {
            Marshal.FreeHGlobal(pointer);
        }
    }
}
