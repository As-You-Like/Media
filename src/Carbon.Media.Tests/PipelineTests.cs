﻿using Carbon.Media.Tests;

using Xunit;

namespace Carbon.Media.Processors.Tests
{
    public class PipelineTests
    {
        private static readonly MediaSource jpeg_100x50   = new MediaSource("1", 100, 50);
        private static readonly MediaSource jpeg_85x20    = new MediaSource("1", 85, 20);
        private static readonly MediaSource jpeg_1280x720 = new MediaSource("23924858", 1280, 720);

        // 23924858/1492x839/crop:358-336_780x140
        [Fact]
        public void Crop3()
        {
            var rendition = new MediaTransformation(jpeg_1280x720, ImageFormat.Jpeg)
                .Resize(1492, 839)              // upscale by 1.1x      
                .Crop(358, 336, 780, 140);

            // var cropScale = 1492 / 1280; // 0.85

            var pipe = MediaPipeline.From(rendition);

            Assert.Equal(780, pipe.FinalWidth);
            Assert.Equal(140, pipe.FinalHeight);

            Assert.Equal("blob#23924858|>crop(307,288,669,120)|>scale(780,140,lanczos3)|>encode(JPEG)", pipe.Canonicalize());
        }


        [Fact]
        public void Pad3()
        {
            var rendition = new MediaTransformation(jpeg_85x20, ImageFormat.Jpeg)
                .Resize(100, 100)
                .Apply(new Pad(100));

            var pipe = MediaPipeline.From(rendition);

            Assert.Equal(100, pipe.Scale.Width);
            Assert.Equal(100, pipe.Scale.Height);

            Assert.Equal(100, pipe.Padding.Top);
            Assert.Equal(100, pipe.Padding.Right);
            Assert.Equal(100, pipe.Padding.Bottom);
            Assert.Equal(100, pipe.Padding.Left);

            Assert.Equal(300, pipe.FinalWidth);
            Assert.Equal(300, pipe.FinalHeight);

            Assert.Equal("blob#1|>scale(100,100,lanczos3)|>pad(100)|>encode(JPEG)", pipe.Canonicalize());
            // Assert.Equal("blob#1|>scale(100,100,lanczos3)|>pad(100)|>JPEG::encode", pipe.Canonicalize());

        }

        [Fact(Skip = "The padding wasn't even...")]
        public void Pad1()
        {
            var rendition = new MediaTransformation(jpeg_85x20, ImageFormat.Jpeg)
                .Apply(new Resize(100, 200, ResizeFlags.Pad));

            var pipe = MediaPipeline.From(rendition);
            
            // Tricky.... if we don't get an even divide, the final image may be off.
            // Where sould we distribute the pixel? We can scale by 1x

            Assert.Equal(100, pipe.FinalWidth);
            Assert.Equal(200, pipe.FinalHeight);

            Assert.Equal("blob#1|>scale(85,20,lanczos3)|>pad(90,7)|>encode(JPEG)", pipe.Canonicalize());

        }

        [Fact]
        public void Crop1()
        {
            var rendition = new MediaTransformation(jpeg_100x50, ImageFormat.Jpeg)
                .Crop(0, 0, 25, 25);

            var pipe = MediaPipeline.From(rendition);

            Assert.Equal("blob#1|>crop(0,0,25,25)|>encode(JPEG)", pipe.Canonicalize());
        }

        [Fact]
        public void CropAndScale()
        {
            var rendition = new MediaTransformation(jpeg_100x50, ImageFormat.Jpeg)
                .Crop(0, 0, 25, 25)
                .Resize(50, 50);

            var pipe = MediaPipeline.From(rendition);

            Assert.Equal("blob#1|>crop(0,0,25,25)|>scale(50,50,lanczos3)|>encode(JPEG)", pipe.Canonicalize());
        }

        [Fact]
        public void CropAndScale2()
        {
            // We need to apply the "Scale" operations to the crop in reverse...

            var rendition = new MediaTransformation(jpeg_100x50, ImageFormat.Jpeg)
                .Resize(50, 25) // 50%
                .Crop(0, 0, 25, 25);

            var pipe = MediaPipeline.From(rendition);

            Assert.Equal("blob#1|>crop(0,0,50,50)|>scale(25,25,lanczos3)|>encode(JPEG)", pipe.Canonicalize());
        }

        [Fact]
        public void CropAndScaleDisportionally()
        {
            var rendition = new MediaTransformation(jpeg_100x50, ImageFormat.Jpeg)
                .Resize(50, 100) // 50%, 200%
                .Crop(0, 0, 25, 25);

            var pipe = MediaPipeline.From(rendition);

            Assert.Equal("blob#1|>crop(0,0,50,12)|>scale(25,25,lanczos3)|>encode(JPEG)", pipe.Canonicalize());
        }

        [Fact]
        public void Filters()
        {
            var rendition = new MediaTransformation(jpeg_85x20, "jpeg")
                .Resize(Unit.Parse("300%"), Unit.Parse("200%"))
                .Apply(new BlurFilter(5))
                .Apply(new BrightnessFilter(0.5f))
                .Apply(new ContrastFilter(0.5f))
                .Apply(new InvertFilter(0.5f))
                .Apply(new GrayscaleFilter(0.5f))
                .Apply(new HueRotateFilter(45))
                .Apply(new OpacityFilter(0.5f))
                .Apply(new PixelateFilter(20))
                .Apply(new SaturateFilter(0.5f))
                .Apply(new SepiaFilter(0.5f));
              
            var pipe = MediaPipeline.From(rendition);

            Assert.Equal("blob#1|>scale(255,40,lanczos3)|>blur(5)|>brightness(0.5)|>contrast(0.5)|>invert(0.5)|>grayscale(0.5)|>hueRotate(45deg)|>opacity(0.5)|>pixelate(20)|>saturate(0.5)|>sepia(0.5)|>encode(JPEG)", pipe.Canonicalize());
        }

        [Fact]
        public void ResizeFit1()
        {
            var rendition = new MediaTransformation(jpeg_100x50, "jpeg")
                .Apply(Resize.Parse("resize(25x50,fit|upscale)"));

            var pipe = MediaPipeline.From(rendition);

            Assert.Equal("blob#1|>scale(25,12,lanczos3)|>encode(JPEG)", pipe.Canonicalize());
        }

        [Fact]
        public void ResizeFit2()
        {
            var rendition = new MediaTransformation(jpeg_100x50, "jpeg")
                .Apply(Resize.Parse("resize(200x200,fit|upscale)"));
            
            var pipe = MediaPipeline.From(rendition);

            Assert.Equal("blob#1|>scale(200,100,lanczos3)|>encode(JPEG)", pipe.Canonicalize());
        }


        [Fact]
        public void ResizePercent()
        {
            var rendition = new MediaTransformation(jpeg_85x20, "jpeg")
                .Resize(Unit.Parse("300%"), Unit.Parse("200%"));

            var pipe = MediaPipeline.From(rendition);
            
            Assert.Equal("blob#1|>scale(255,40,lanczos3)|>encode(JPEG)", pipe.Canonicalize());
        }

        [Fact]
        public void Scale1()
        {
            var rendition = new MediaTransformation(jpeg_85x20, "jpeg")
                .Apply(new Scale(100, 200, InterpolaterMode.Cubic));

            var pipe = MediaPipeline.From(rendition);

            Assert.Equal("blob#1|>scale(100,200,cubic)|>encode(JPEG)", pipe.Canonicalize());

        }

        [Fact]
        public void ResizeAuto()
        {
            var rendition = new MediaTransformation(jpeg_85x20, "jpeg")
                .Resize(Unit.Parse("_"), Unit.Parse("40"));

            Assert.Equal(170, rendition.Width);
            Assert.Equal(40, rendition.Height);

            var pipe = MediaPipeline.From(rendition);

            Assert.Equal("blob#1|>scale(170,40,lanczos3)|>encode(JPEG)", pipe.Canonicalize());
        }      
    }

  
}