using System;
using Carbon.Media.Codecs;
using FFmpeg.AutoGen;

namespace Carbon.Media
{
    public unsafe abstract class MediaStream : IDisposable
    {
        private bool isDisposed = false;
        protected AVStream* pointer;

        protected MediaStream(AVStream* pointer, CodecType codecType = CodecType.Decoder)
        {
            if (pointer == null) throw new ArgumentNullException(nameof(pointer));

            this.pointer = pointer;

            Codec = Codec.Create(this, codecType);
        }

        internal AVStream* Pointer => pointer;

        public int Id
        {
            get => pointer->id;
            set => pointer->id = value;
        }

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
        //  Real base framerate of the stream. This is the lowest framerate with which all
        //  timestamps can be represented accurately (it is the least common multiple of
        //  all framerates in the stream). Note, this value is just a guess! For example,
        //  if the time base is 1/90000 and all frames have either approximately 3600 or
        //  1800 timer ticks, then r_frame_rate will be 50/1.

        public Rational FrameRate => pointer->r_frame_rate.ToRational();

        #region Interleaving

        public InterleavingInfo Interleaving => new InterleavingInfo(
            chunkSize     : pointer->interleaver_chunk_size,
            chuckDuration : pointer->interleaver_chunk_duration
        );

        #endregion

        public static MediaStream Create(AVStream* pointer, CodecType codecType = CodecType.Decoder)
        {
            MediaStream stream = InternalCreate(pointer);

            // Setup the parameters from the current context
            ffmpeg.avcodec_parameters_from_context(stream.Pointer->codecpar, stream.Codec.Context.Pointer).EnsureSuccess();

            return stream;
        }

        private static MediaStream InternalCreate(AVStream* pointer)
        {
            switch (pointer->codec->codec_type)
            {
                case AVMediaType.AVMEDIA_TYPE_AUDIO    : return new AudioStream(pointer);
                case AVMediaType.AVMEDIA_TYPE_VIDEO    : return new VideoStream(pointer); 
                case AVMediaType.AVMEDIA_TYPE_SUBTITLE : return new SubtitleStream(pointer); 
                default                                : return new UnknownStream(pointer); 
            }
        }

        public void Dispose()
        {
            if (isDisposed) return;

            Codec?.Dispose();

            isDisposed = true;
        }
    }
}