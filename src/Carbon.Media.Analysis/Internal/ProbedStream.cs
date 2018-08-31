using System;
using System.Runtime.Serialization;
using Carbon.Json;

namespace Carbon.Media.Analysis.Internal
{
    public class ProbedStream
    {
        [DataMember(Name = "index")]
        public int Index { get; set; }

        [DataMember(Name = "codec_name")]
        public string CodecName { get; set; }

        [DataMember(Name = "codec_long_name")]
        public string CodecLongName { get; set; }

        [DataMember(Name = "profile")]
        public string Profile { get; set; }

        // audio | video | ...
        [DataMember(Name = "codec_type")]
        public string CodecType { get; set; }

        [DataMember(Name = "codec_time_base")]
        public string CodecTimeBase { get; set; }

        [DataMember(Name = "codec_tag_string")]
        public string CodecTagString { get; set; }

        [DataMember(Name = "codec_tag")]
        public string CodecTag { get; set; }

        // AUDIO
        [DataMember(Name = "sample_fmt")]
        public string SampleFormat { get; set; }

        [DataMember(Name = "sample_rate")]
        public int SampleRate { get; set; }

        [DataMember(Name = "channels")]
        public int ChannelCount { get; set; }

        [DataMember(Name = "channel_layout")]
        public string ChannelLayout { get; set; }

        [DataMember(Name = "bits_per_sample")]
        public int BitsPerSample { get; set; }

        // VIDEO

        [DataMember(Name = "width")]
        public int Width { get; set; }

        [DataMember(Name = "height")]
        public int Height { get; set; }

        [DataMember(Name = "coded_width")]
        public int CodedWidth { get; set; }

        [DataMember(Name = "coded_height")]
        public int CodedHeight { get; set; }

        [DataMember(Name = "has_b_frames")]
        public int HasBFrames { get; set; }

        [DataMember(Name = "sample_aspect_ratio")]
        public string SampleAspectRatio { get; set; }

        [DataMember(Name = "display_aspect_ratio")]
        public string DisplayAspectRatio { get; set; }

        [DataMember(Name = "pix_fmt")]
        public string PixelFormat { get; set; }

        [DataMember(Name = "level")]
        public int Level { get; set; }

        [DataMember(Name = "color_range")]
        public string ColorRange { get; set; }

        [DataMember(Name = "color_space")]
        public string ColorSpace { get; set; }

        [DataMember(Name = "color_transfer")]
        public string ColorTransfer { get; set; }

        [DataMember(Name = "color_primaries")]
        public string ColorPrimaries { get; set; }

        [DataMember(Name = "chroma_location")]
        public string ChromaLocation { get; set; }

        [DataMember(Name = "refs")]
        public int Refs { get; set; }

        [DataMember(Name = "is_avc")]
        public string IsAvc { get; set; }

        [DataMember(Name = "nal_length_size")]
        public string NalLengthSize { get; set; }

        [DataMember(Name = "r_frame_rate")]
        public string RFrameRate { get; set; }

        [DataMember(Name = "avg_frame_rate")]
        public string AverageFrameRate { get; set; }

        [DataMember(Name = "time_base")]
        public string TimeBase { get; set; }

        [DataMember(Name = "start_pts")]
        public long? StartPts { get; set; }

        [DataMember(Name = "start_time")]
        public TimeSpan? StartTime { get; set; }

        [DataMember(Name = "duration_ts")]
        public long DurationTimestamp { get; set; }

        [DataMember(Name = "duration")] // in seconds
        public TimeSpan? Duration { get; set; }

        [DataMember(Name = "bit_rate")]
        public long? BitRate { get; set; }

        [DataMember(Name = "max_bit_rate")]
        public long? MaxBitRate { get; set; }

        [DataMember(Name = "bits_per_raw_sample")]
        public int? BitsPerRawSample { get; set; }

        [DataMember(Name = "nb_frames")]
        public int? FrameCount { get; set; }

        [DataMember(Name = "disposition")]
        public ProbedDisposition Disposition { get; set; }
         
        [DataMember(Name = "tags")]
        public JsonObject Tags { get; set; }

        public MediaStreamInfo ToStreamInfo()
        {
            MediaStreamInfo stream = null;

            if (CodecType == "audio")
            {
                stream = new AudioStreamInfo {
                    ChannelLayout = this.ChannelLayout,
                    ChannelCount = this.ChannelCount,
                    SampleFormat = FfmpegHelper.ParseSampleFormat(SampleFormat),
                    SampleRate = SampleRate,
                };
            }
            else if (CodecType == "video")
            {
                stream = new VideoStreamInfo {
                    PixelFormat = PixelFormatHelper.Parse(PixelFormat),
                    Width = this.Width,
                    Height = this.Height
                };
            }
            else if (CodecType == "subtitle")
            {
                stream = new SubtitleStreamInfo
                {

                };
            }
            else if (CodecType == "data")
            {
                stream = new DataStreamInfo
                {

                };
            }
            else
            {
                stream = new MediaStreamInfo();
            }

            stream.Codec = Profile != null ? CodecInfo.Create(CodecIdHelper.Parse(CodecName), Profile).Name : CodecName;

            if (TimeBase != null && Rational.TryParse(TimeBase, out var timeBase))
            {
                stream.TimeBase = timeBase;
            }

            
            stream.Duration = Duration ?? TimeSpan.Zero;
            stream.StartTime = StartTime ?? TimeSpan.Zero;

            stream.FrameCount = FrameCount;
            

            return stream;
            
        }
    }
}