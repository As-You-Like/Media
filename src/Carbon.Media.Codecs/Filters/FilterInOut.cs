using System;
using System.Runtime.InteropServices;
using FFmpeg.AutoGen;

namespace Carbon.Media
{
    public unsafe struct FilterInOut : IDisposable
    {
        public FilterInOut(string name, FilterContext filterContext)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Required", nameof(name));
            }

            FilterContext = filterContext;

            Pointer = ffmpeg.avfilter_inout_alloc();

            if (Pointer == null)
            {
                throw new Exception("FilterInOut was not allocated");
            }

            Pointer->name = ffmpeg.av_strdup(name);
            Pointer->filter_ctx = filterContext.Pointer;
            Pointer->pad_idx = 0;
            Pointer->next = null;
        }

        public string Name => Marshal.PtrToStringAnsi((IntPtr)Pointer->name);

        public AVFilterInOut* Pointer;

        public FilterContext FilterContext;

        // Next

        public void Dispose()
        {
            Dispose(true);
        }

        public void Dispose(bool disposing)
        {
            if (Pointer == null) return;

            fixed (AVFilterInOut** p = &Pointer)
            {
                ffmpeg.avfilter_inout_free(p);
            }

            Pointer = null;
        }
    }
}