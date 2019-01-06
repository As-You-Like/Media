using System;
using Xunit;

namespace Carbon.Media.Processing.Filters.Tests
{
    public class ResampleFilterTests
    {
        [Fact]
        public void Parse()
        {
            var resample = (ResampleFilter)Processor.Parse("resample(96000)");

            Assert.Equal("resample(96kHz)", resample.ToString());
        }

        [Fact]
        public void Parse2()
        {
            var resample = (ResampleFilter)Processor.Parse("resample(96000,f32)");

            Assert.Equal("resample(96kHz,f32)", resample.ToString());
        }

        [Fact]
        public void Parse3()
        {
            var resample = (ResampleFilter)Processor.Parse("resample(48kHz,f32)");

            Assert.Equal("resample(48kHz,f32)", resample.ToString());
        }

        [Fact]
        public void Parse4()
        {
            var resample = (ResampleFilter)Processor.Parse("resample(8kHz,f32)");

            Assert.Equal("resample(8kHz,f32)", resample.ToString());
        }

        [Fact]
        public void Parse5()
        {
            var resample = (ResampleFilter)Processor.Parse("resample(8000Hz,f32,2)");

            Assert.Equal("resample(8kHz,f32,2)", resample.ToString());
        }

        [Fact]
        public void Parse6()
        {
            var resample = (ResampleFilter)Processor.Parse("resample(8000Hz,f32,2,stereo)");

            Assert.Equal("resample(8kHz,f32,2,stereo)", resample.ToString());
        }

        [Fact]
        public void Parse7()
        {
            var resample = (ResampleFilter)Processor.Parse("resample(8000Hz,f32,channelLayout:stereo)");


            Assert.Equal("resample(8kHz,f32,channelLayout:stereo)", resample.ToString());
        }

        [Fact]
        public void ParseOutOfOrder()
        {
            var resample = (ResampleFilter)Processor.Parse("resample(8kHz,channelLayout:stereo,channelCount:2)");
        
            Assert.Equal("resample(8kHz,channelCount:2,channelLayout:stereo)", resample.ToString());
        }
    }
}