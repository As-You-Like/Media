﻿using Xunit;

namespace Carbon.Media.Processors.Tests
{
    public class EncodeTests
	{
        [Theory]
        [InlineData("gif",  FormatId.Gif,  "image/gif")]
        [InlineData("ico",  FormatId.Ico,  "image/x-icon")]
        [InlineData("jpeg", FormatId.Jpeg, "image/jpeg")]
        [InlineData("jxr",  FormatId.Jxr,  "image/jxr")]
        [InlineData("png",  FormatId.Png,  "image/png")]
        [InlineData("webp", FormatId.WebP, "image/webp")]

        // Audio
        [InlineData("aac",  FormatId.Aac,  "audio/aac")]
        [InlineData("m4a",  FormatId.M4a,  "audio/mp4")]
        [InlineData("mp3",  FormatId.Mp3,  "audio/mpeg")]
        // [InlineData("oga",  FormatId.Oga,  "audio/ogg")]
        [InlineData("opus", FormatId.Opus, "audio/opus")]

        // Videos
        [InlineData("mp4", FormatId.Mp4, "video/mp4")]

        public void A(string name, FormatId format, string mime)
        {
            var encode = Encode.Parse($"{name}::encode(quality:95)");

            Assert.Equal(95, encode.Quality);

            var e = Encode.Parse(encode.Canonicalize());

            Assert.Equal($"{e.Format.Canonicalize()}::encode(quality:95)", encode.Canonicalize());

            Assert.Equal(format, e.Format);

            Assert.Equal(mime, encode.Mime.ToString());
        }

        [Fact]
        public void Png8Test()
        {
            var encode = Encode.Parse("png8::encode");

            Assert.Equal(FormatId.Png, encode.Format);
            Assert.True(encode.Flags.HasFlag(EncodingFlags._8bit));
        }

        [Fact]
        public void Png32Test()
        {
            var encode = Encode.Parse("png32::encode");

            Assert.Equal(FormatId.Png, encode.Format);
            Assert.True(encode.Flags.HasFlag(EncodingFlags._32bit));
        }

        [Fact]
        public void ProgressiveJpegTest()
        {
            var encode = Encode.Parse("pjpg::encode");

            Assert.Equal(FormatId.Jpeg, encode.Format);
            Assert.True(encode.Flags.HasFlag(EncodingFlags.Progressive));
        }

        [Fact]
        public void LosslessTest()
        {
            var encode = Encode.Parse("WebP::encode(lossless:true)");

            Assert.Equal(FormatId.WebP, encode.Format);
            Assert.True(encode.Flags.HasFlag(EncodingFlags.Lossless));
        }
    }
}