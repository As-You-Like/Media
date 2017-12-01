﻿using System;
using System.Runtime.InteropServices;
using FFmpeg.AutoGen;

namespace Carbon.Media
{
    public unsafe class FilterContext
    {
        public FilterContext(AVFilterContext* pointer)
        {
            #region Preconditions

            if (pointer == null)
            {
                throw new ArgumentNullException(nameof(pointer));
            }

            #endregion

            Pointer = pointer;
        }

        public AVFilterContext* Pointer { get; }

        public string Name => Marshal.PtrToStringAnsi((IntPtr)Pointer->name);

        public void SetOption(string name, int value)
        {
            ffmpeg.av_opt_set_bin(Pointer, name, (byte*)&value, 4, ffmpeg.AV_OPT_SEARCH_CHILDREN);   
        }

        public void SetOption(string name, ulong value)
        {
            ffmpeg.av_opt_set_bin(Pointer, name, (byte*)&value, 8, ffmpeg.AV_OPT_SEARCH_CHILDREN);
        }

        public void SetOption(string name, long value)
        {
            ffmpeg.av_opt_set_int(Pointer, name, value, ffmpeg.AV_OPT_SEARCH_CHILDREN);
        }
    }
}