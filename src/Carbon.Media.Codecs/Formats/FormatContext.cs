﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Carbon.Media.IO;
using FFmpeg.AutoGen;

namespace Carbon.Media
{
    public unsafe class FormatContext : IDisposable
    {
        private AVFormatContext* pointer;
        private Rational timebase = Timebases.Ffmpeg;

        public FormatContext()
        {
            this.pointer = ffmpeg.avformat_alloc_context();

            if (pointer == null)
            {
                throw new Exception("Unable to allocate format context");
            }
        }

        public AVFormatContext* Pointer => pointer;
        
        public MediaStream[] Streams { get; internal set; }

        // public Chapter[] Chapters { get; }

        public BitRate? BitRate => new BitRate(pointer->bit_rate);
        
        public TimeSpan? MaxAnalyzeDuration { get; }

        public TimeSpan? Duration => new Timestamp(pointer->duration, Timebases.DotNetTicks).TimeSpan;
        
        public Dictionary<string, string> Metadata { get; }

        // public object A => pointer->iformat;

        public OutputFormat OutputFormat => new OutputFormat(pointer->oformat);
        
        internal FormatFlags Flags
        {
            get => (FormatFlags)pointer->flags;
            set => pointer->flags = (int)value;
        }

        // Input Format
        // Output Format

        public void Open(IOContext source)
        {
            pointer->pb = source.Pointer;
            
            Console.WriteLine(pointer->flags);

            pointer->flags |= ffmpeg.AVFMT_FLAG_CUSTOM_IO;

            AVInputFormat* inputFormat = null;
            // Console.WriteLine("probings");

            ffmpeg.av_probe_input_buffer(source.Pointer, &inputFormat, null, null, 0, 0).EnsureSuccess();

            Console.WriteLine("probed ->"  + Marshal.PtrToStringAnsi((IntPtr)inputFormat->name));

            fixed (AVFormatContext** ps = &pointer)
            {
                ffmpeg.avformat_open_input(ps, "", inputFormat, null).EnsureSuccess();
            }

            ffmpeg.avformat_find_stream_info(pointer, null).EnsureSuccess(); // populate the streams

            var streams = new MediaStream[pointer->nb_streams];

            for (int i = 0; i < pointer->nb_streams; i++)
            {
                var stream = MediaStream.Create(pointer->streams[i]);

                streams[i] = stream;
            }

            // Note: the codecs still need intilized

            Streams = streams;
        }

        public void Open(Uri url)
        {
            fixed (AVFormatContext** c = &pointer)
            {
                ffmpeg.avformat_open_input(c, url.ToString(), null, null).EnsureSuccess();
            }
            
            ffmpeg.avformat_find_stream_info(pointer, null).EnsureSuccess(); // populate the streams

            // note: the codec still needs to be initilized

            var streams = new MediaStream[pointer->nb_streams];

            for (int i = 0; i < pointer->nb_streams; i++)
            {
                var stream = MediaStream.Create(pointer->streams[i]);

                streams[i] = stream;
            }

            Streams = streams;
        }
        
        public void Seek(long streamIndex, long position)
        {
            var time = new Timestamp(position, Streams[0].TimeBase);

             // ffmpeg.avformat_seek_file(pointer, streamIndex, time )
        }

        public bool CanSeek => pointer->pb->seekable == 1;

        public void Dispose()
        {
            fixed (AVFormatContext** p = &pointer)
            {
                ffmpeg.avformat_close_input(p);
            }
        }
    }
}