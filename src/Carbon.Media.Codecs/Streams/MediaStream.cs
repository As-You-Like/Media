using System;
using Carbon.Media.Codecs;
using FFmpeg.AutoGen;

namespace Carbon.Media
{
    public unsafe abstract class MediaStream : IDisposable
    {
        protected AVStream* pointer;

        protected MediaStream(AVStream* pointer, CodecType codecType = CodecType.Decoder)
        {
            this.pointer = pointer;

            Codec = Codec.Create(this, codecType);
        }

        internal AVStream* Pointer => pointer;

        public int Index
        {
            get => pointer->index;
            set => pointer->index = value;
        }

        public abstract MediaType Type { get; }

        // e.g. H264, AAC ...
        public Codec Codec { get; }

        /// <summary>
        /// The average number of bits per second
        /// </summary>
        public BitRate? BitRate => Codec.Context.BitRate;

        /// <summary>
        /// The fundemental unit of time (in seconds) in which frame timestamps are represented
        /// </summary>
        public Rational TimeBase
        {
            get => pointer->time_base.ToRational();
            set => pointer->time_base = value.ToAVRational();
        }

        /// <summary>
        /// The presentation of the first frame in the stream (pts of the first frame of the stream in presentation order)
        /// </summary>
        public Timestamp? StartTime => new Timestamp(pointer->start_time, TimeBase);

        /// <summary>
        /// The duration of the stream in stream time base. (may be estimated)
        /// </summary>
        public Timestamp? Duration => new Timestamp(pointer->duration, TimeBase);

        /// <summary>
        /// Number of frames delay there will be from the encoder input to the decoder output
        /// </summary>
        public long? FrameDelay { get; set; }

        public long? FrameCount
        {
            get
            {
                long value = pointer->nb_frames;

                if (value == 0) return null;

                return value;
            }
        }

        //
        // Summary:
        //     Real base framerate of the stream. This is the lowest framerate with which all
        //     timestamps can be represented accurately (it is the least common multiple of
        //     all framerates in the stream). Note, this value is just a guess! For example,
        //     if the time base is 1/90000 and all frames have either approximately 3600 or
        //     1800 timer ticks, then r_frame_rate will be 50/1.

        public Rational FrameRate => pointer->r_frame_rate.ToRational();
        
        #region Interleaving

        public InterleavingInfo Interleaving => new InterleavingInfo {
            ChuckSize = pointer->interleaver_chunk_size,
            ChuckDuration = pointer->interleaver_chunk_duration
        };

        #endregion

        public static MediaStream Create(AVStream* pointer, CodecType codecType = CodecType.Decoder)
        {
            MediaStream stream;

            switch (pointer->codec->codec_type)
            {
                case AVMediaType.AVMEDIA_TYPE_AUDIO     : stream = new AudioStream(pointer); break;
                case AVMediaType.AVMEDIA_TYPE_VIDEO     : stream = new VideoStream(pointer); break;
                case AVMediaType.AVMEDIA_TYPE_SUBTITLE  : stream = new SubtitleStream(pointer); break;
                default                                 : stream = new UnknownStream(pointer); break;
            }
            
            ffmpeg.avcodec_parameters_from_context(stream.Pointer->codecpar, stream.Codec.Context.Pointer).EnsureSuccess();
            
            return stream;
        }


        public void Dispose()
        {
            Codec?.Dispose();
        }
    }

    public struct InterleavingInfo
    {
        public long ChuckSize { get; set; }

        public long ChuckDuration { get; set; }
    }

}

 