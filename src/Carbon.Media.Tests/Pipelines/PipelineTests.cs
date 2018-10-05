using System.Drawing;
using Carbon.Media.Drawing;
using Carbon.Media.Tests;

using Xunit;

namespace Carbon.Media.Processing.Tests
{
    public class PipelineTests
    {
        private static readonly MediaSource audio         = new MediaSource("1");
        private static readonly MediaSource jpeg_100x50   = new MediaSource("1", 100, 50);
        private static readonly MediaSource jpeg_85x20    = new MediaSource("1", 85, 20);
        private static readonly MediaSource jpeg_180x180  = new MediaSource("1", 180, 180);

        private static readonly MediaSource jpeg_1280x720 = new MediaSource("23924858", 1280, 720);
        private static readonly MediaSource jpeg_524x485  = new MediaSource("22626389", 524, 485);

        private static readonly MediaSource jpeg_100x50_rotate90 = new MediaSource("1", 100, 50, ExifOrientation.Rotate90);
        private static readonly MediaSource jpeg_1920x2560 = new MediaSource("1", 1920, 2560);

        private static readonly MediaSource gif_200x200 = new MediaSource("1", 200, 200);

        [Fact]
        public void Frame()
        {
            var pipeline = Pipeline.Parse("blob#pipe|>frame(3)|>JPEG::encode");

            Assert.Equal("blob#pipe|>frame(3)|>JPEG::encode", pipeline.Canonicalize());

            Assert.Null(pipeline.Scale);
            Assert.Equal(3, pipeline.FrameNumber);
        }

        [Fact]
        public void ResizeFrameAndEncodeToGif()
        {
            var pipeline = Pipeline.Parse("blob#pipe|>frame(3)|>scale(800,600)|>GIF::encode");

            Assert.Equal(3, pipeline.FrameNumber);
            Assert.Equal(new Size(800, 600), pipeline.FinalSize);
            Assert.Equal(FormatId.Gif, pipeline.Encode.Format);
        }

        [Fact]
        public void BackgroundTest()
        {
            var img = new MediaTransformation(jpeg_100x50)
                .Resize(100, 100)
                .WithBackground("fff")
                .Encode(FormatId.Jp2);

            var pipe = Pipeline.From(img);
            
            Assert.Equal("blob#1|>background(fff)|>scale(100,100,lanczos3)|>JP2::encode", pipe.Canonicalize());

            Assert.Equal(pipe.Canonicalize(), Pipeline.Parse(pipe.Canonicalize()).Canonicalize());
        }

        [Fact]
        public void Page()
        {
            var pipeline = Pipeline.Parse("blob#11|>page(3)|>crop(0,0,200,200)|>JPEG::encode");

            Assert.Equal("blob#11|>page(3)|>crop(0,0,200,200)|>JPEG::encode", pipeline.Canonicalize());

            Assert.Equal(3, pipeline.PageNumber);
        }

        [Fact]
        public void CropExact()
        {
            var pipeline = Pipeline.Parse("blob#pipe|>crop(0,0,200,200)|>JPEG::encode");
            
            Assert.Equal("blob#pipe|>crop(0,0,200,200)|>JPEG::encode", pipeline.Canonicalize());

            Assert.Equal(new Size(200, 200), pipeline.FinalSize);
        }

        [Fact]
        public void PageTest()
        {
            var img = new MediaTransformation(jpeg_100x50_rotate90)
                .WithPage(3)
                .Resize(100, 100)
                .WithBackground("ffffff")
                .Encode(FormatId.Svg);

            var pipe = Pipeline.From(img);

            Assert.Equal("blob#1|>page(3)|>background(ffffff)|>rotate(90deg)|>scale(100,100,lanczos3)|>SVG::encode", pipe.Canonicalize());

            Assert.Equal(pipe.Canonicalize(), Pipeline.Parse(pipe.Canonicalize()).Canonicalize());
        }

        [Fact]
        public void QualityTest()
        {
            var img = new MediaTransformation(jpeg_100x50_rotate90)
                .Resize(100, 100, CropAnchor.Center)
                .WithQuality(82)
                .Encode(FormatId.Jpeg);

            var pipe = Pipeline.From(img);

            Assert.Equal("blob#1|>rotate(90deg)|>crop(0,25,50,50)|>scale(100,100,lanczos3)|>JPEG::encode(quality:82)", pipe.Canonicalize());

            Assert.Equal(pipe.Canonicalize(), Pipeline.Parse(pipe.Canonicalize()).Canonicalize());
        }

        [Fact]
        public void OrientTest1()
        {
            var img = new MediaTransformation(jpeg_100x50_rotate90)
                .Resize(480, 444)
                .Crop(0, 33, 480, 360)
                .Encode(FormatId.Png);

            var pipe = Pipeline.From(img);

            Assert.Equal(new Size(480, 360), pipe.FinalSize);

            Assert.Equal(
                "blob#1|>rotate(90deg)|>crop(0,3,100,40)|>scale(480,360,lanczos3)|>PNG::encode", 
                pipe.Canonicalize()
            );

            Assert.Equal(pipe.Canonicalize(), Pipeline.Parse(pipe.Canonicalize()).Canonicalize());
        }

        [Fact]
        public void StreamTests()
        { 
            var t = MediaTransformation.Parse("33695921;drop(audio)/video(1mbs,profile:main).mp4");

            var pipe = Pipeline.From(t);

            Assert.Equal("drop(audio)/video(1mbs,profile:main).mp4", t.GetTransformPath());
        }

        [Theory]
        [InlineData("mp3",  "MP3")]
        [InlineData("m4a",  "M4A")]
        [InlineData("opus", "Opus")]
        [InlineData("aac",  "AAC")]
        public void AudioTypes(string name, string canonicalName)
        {
            var t = MediaTransformation.Parse("1;96kbs." + name);

            var pipe = Pipeline.From(t);

            Assert.Null(pipe.Scale);

            Assert.Equal("bitrate(96000)." + name, t.GetTransformPath());

            Assert.Equal($"blob#1|>bitrate(96000)|>{canonicalName}::encode", pipe.Canonicalize());
        }


        [Theory]
        [InlineData("webm", "WebM")]
        [InlineData("mp4", "MP4")]
        public void VideoTests(string name, string canonicalName)
        {
            var t = MediaTransformation.Parse("1;1920x1080/1000kbs." + name);

            var pipe = Pipeline.From(t);

            Assert.Equal((1920, 1080), (pipe.Scale.Width, pipe.Scale.Height));

            Assert.Equal("1920x1080/bitrate(1000000)." + name, t.GetTransformPath());

            Assert.Equal($"blob#1|>scale(1920,1080,lanczos3)|>bitrate(1000000)|>{canonicalName}::encode", pipe.Canonicalize());
        }

        [Fact]
        public void OrientTest2()
        {
            var t = MediaTransformation.Parse("33695921;960x1280/rotate(90).jpeg");

            var pipe = Pipeline.From(jpeg_1920x2560, t.GetTransforms());

            Assert.Equal("blob#1|>rotate(90deg)|>scale(1280,960,lanczos3)|>JPEG::encode", pipe.Canonicalize());

            t = MediaTransformation.Parse("33695921;rotate(90)/1280x960.jpeg");

            pipe = Pipeline.From(jpeg_1920x2560, t.GetTransforms());

            Assert.Equal("blob#1|>rotate(90deg)|>scale(1280,960,lanczos3)|>JPEG::encode", pipe.Canonicalize());
        }
        
        [Fact]
        public void RotateTest()
        {
            var img = new MediaTransformation(jpeg_100x50_rotate90)
                .Resize(480, 444)
                .Crop(0, 33, 480, 360)
                .Rotate(90)
                .Encode(FormatId.Jpeg);

            var pipe = Pipeline.From(img);

            Assert.Equal(360, pipe.Scale.Width);
            Assert.Equal(480, pipe.Scale.Height);

            Assert.Equal(new Size(360, 480), pipe.FinalSize);

            Assert.Equal("blob#1|>rotate(90deg)|>crop(3,0,40,100)|>scale(360,480,lanczos3)|>JPEG::encode", pipe.Canonicalize());
        }

        [Fact]
        public void Crop1Test()
        {
            var img = new MediaTransformation(jpeg_524x485)
                .Resize(480, 444)
                .Crop(0, 33, 480, 360)
                .Encode(FormatId.Jpeg);

            var pipe = Pipeline.From(img);

            Assert.Equal(new Size(480, 360), pipe.FinalSize);

            Assert.Equal("blob#22626389|>crop(0,36,524,393)|>scale(480,360,lanczos3)|>JPEG::encode", pipe.Canonicalize());
        }

        // 23924858/1492x839/crop(358,336,780,140)
        [Fact]
        public void Crop2Test()
        {
            var rendition = new MediaTransformation(jpeg_1280x720)
                .Resize(1492, 839)              // upscale by 1.1x      
                .Crop(358, 336, 780, 140)
                .Encode(FormatId.Jpeg);

            // var cropScale = 1492 / 1280; // 0.85

            var pipe = Pipeline.From(rendition);

            Assert.Equal(new Size(780, 140), pipe.FinalSize);

            Assert.Equal("blob#23924858|>crop(307,288,669,120)|>scale(780,140,lanczos3)|>JPEG::encode", pipe.Canonicalize());
        }

        [Fact]
        public void ResizeAndCropTest()
        {
            // scale 1.17

            var rendition = new MediaTransformation(jpeg_85x20)
                .Resize(100, 100, CropAnchor.Center)
                .Encode(FormatId.Jpeg);
 
            Assert.Equal(
                "blob#1|>crop(32,0,20,20)|>scale(100,100,lanczos3)|>JPEG::encode",
                Pipeline.From(rendition).Canonicalize()
            );

            rendition = new MediaTransformation(jpeg_85x20).Resize(100, 100, CropAnchor.Left).Encode(FormatId.Jpeg);

            Assert.Equal(
                "blob#1|>crop(0,0,20,20)|>scale(100,100,lanczos3)|>JPEG::encode", 
                Pipeline.From(rendition).Canonicalize()
            );

            rendition = new MediaTransformation(jpeg_85x20)
                .Resize(100, 100, CropAnchor.Right)
                .Encode(FormatId.Jpeg);

            Assert.Equal(
                "blob#1|>crop(65,0,20,20)|>scale(100,100,lanczos3)|>JPEG::encode", 
                Pipeline.From(rendition).Canonicalize()
            );

            rendition = new MediaTransformation(jpeg_85x20)
                .Resize(300, 100, CropAnchor.Right)
                .Encode(FormatId.Jpeg);

            Assert.Equal(
                "blob#1|>crop(25,0,60,20)|>scale(300,100,lanczos3)|>JPEG::encode",
                Pipeline.From(rendition).Canonicalize()
            );
        }

        [Fact]
        public void PadTest()
        {
            var rendition = new MediaTransformation(jpeg_85x20)
                .Resize(100, 100)
                .Apply(new PadTransform(100))
                .Encode(FormatId.Jpeg);

            var pipeline = Pipeline.From(rendition);

            Assert.Equal(100, pipeline.Scale.Width);
            Assert.Equal(100, pipeline.Scale.Height);

            Assert.Equal(100, pipeline.Padding.Top);
            Assert.Equal(100, pipeline.Padding.Right);
            Assert.Equal(100, pipeline.Padding.Bottom);
            Assert.Equal(100, pipeline.Padding.Left);
            
            Assert.Equal(100, pipeline.Position.X);
            Assert.Equal(100, pipeline.Position.Y);

            Assert.Equal(new Size(300, 300), pipeline.FinalSize);

            Assert.Equal("blob#1|>scale(100,100,lanczos3)|>pad(100)|>JPEG::encode", pipeline.Canonicalize());
        }

        [Fact]
        public void PadTest2()
        {
            var rendition = new MediaTransformation(jpeg_85x20)
                .Apply(new BackgroundFilter("000000"))
                .Apply(new ResizeTransform(100, 200, ResizeFlags.Pad))
                .Encode(FormatId.Jpeg);

            var pipe = Pipeline.From(rendition);
            
            Assert.Equal(new Size(100, 200), pipe.FinalSize);

            // We split a pixel in half -- and added to the left
            Assert.Equal("blob#1|>background(000000)|>scale(85,20,lanczos3)|>pad(90,7,90,8)|>JPEG::encode", pipe.Canonicalize());
        }


        [Fact]
        public void Contain1()
        {
            var a = MediaTransformation.Parse("1;background(000)/1200x630,contain.jpeg", jpeg_180x180);

            var pipe = Pipeline.From(a);

            Assert.Equal(ResizeFlags.Contain, ResizeFlags.Pad | ResizeFlags.Upscale);

            Assert.Equal(0, pipe.Padding.Top);
            Assert.Equal(0, pipe.Padding.Bottom);
            Assert.Equal(285, pipe.Padding.Left);
            Assert.Equal(285, pipe.Padding.Right);

            Assert.Equal("blob#1|>background(000)|>scale(630,630,lanczos3)|>pad(0,285)|>JPEG::encode", pipe.Canonicalize());

            Assert.Equal(new Size(1200, 630), pipe.FinalSize);
        }
        
        [Fact]
        public void CoverTest1()
        {
            var a = MediaTransformation.Parse("1;1200x630,cover.jpeg", jpeg_180x180);

            var pipe = Pipeline.From(a);

            Assert.Equal("blob#1|>crop(0,43,180,94)|>scale(1200,630,lanczos3)|>JPEG::encode", pipe.Canonicalize());

            Assert.Equal(new Size(1200, 630), pipe.FinalSize);
        }

        [Fact]
        public void DebugTest()
        {
            var pipeline = Pipeline.Parse("blob#pipe|>crop(0,0,200,200)|>JPEG::encode|>debug");

            Assert.Equal("blob#pipe|>crop(0,0,200,200)|>JPEG::encode|>debug", pipeline.Canonicalize());

            Assert.Equal(new Size(200, 200), pipeline.FinalSize);

            Assert.True(pipeline.IsDebug);
        }

        [Fact]
        public void ExpiresTest()
        {
            var a = MediaTransformation.Parse("1;expires(1514686554).jpeg", jpeg_180x180);

            var filter = a.GetTransforms()[0] as ExpiresFilter;

            Assert.Equal("2017-12-31T02:15:54.0000000Z", filter.Timestamp.ToString("o"));

            var pipe = Pipeline.From(a);

            Assert.Equal("blob#1|>expires(1514686554)|>scale(180,180,lanczos3)|>JPEG::encode", pipe.Canonicalize());
        }
        

        [Fact]
        public void PadModeTest()
        {
            var a = MediaTransformation.Parse("1;background(000)/1200x630,pad|upscale.jpeg", jpeg_180x180);
            
            var pipe = Pipeline.From(a);

            Assert.Equal(0, pipe.Padding.Top);
            Assert.Equal(0, pipe.Padding.Bottom);
            Assert.Equal(285, pipe.Padding.Left);
            Assert.Equal(285, pipe.Padding.Right);

            Assert.Equal("blob#1|>background(000)|>scale(630,630,lanczos3)|>pad(0,285)|>JPEG::encode", pipe.Canonicalize());

            Assert.Equal(new Size(1200, 630), pipe.FinalSize);
        }

        [Fact]
        public void CropTest()
        {            
            var pipe = Pipeline.From(new MediaTransformation(jpeg_100x50)
                .Crop(0, 0, 25, 25)
                .Encode(FormatId.Jpeg)
            );

            Assert.Equal("blob#1|>crop(0,0,25,25)|>JPEG::encode", pipe.Canonicalize());
        }

        [Fact]
        public void CropAndScale()
        {
            var rendition = new MediaTransformation(jpeg_100x50)
                .Crop(0, 0, 25, 25)
                .Resize(50, 50)
                .Encode(FormatId.Jpeg);

            var pipe = Pipeline.From(rendition);

            Assert.Equal("blob#1|>crop(0,0,25,25)|>scale(50,50,lanczos3)|>JPEG::encode", pipe.Canonicalize());
        }

        [Fact]
        public void CropAndScale2()
        {
            // We need to apply the "Scale" operations to the crop in reverse...

            var rendition = new MediaTransformation(jpeg_100x50)
                .Resize(50, 25) // 50%
                .Crop(0, 0, 25, 25)
                .Encode(FormatId.Jpeg);

            var pipe = Pipeline.From(rendition);

            Assert.Equal("blob#1|>crop(0,0,50,50)|>scale(25,25,lanczos3)|>JPEG::encode", pipe.Canonicalize());
        }

        [Fact]
        public void CropAndScaleDisportionally()
        {
            var rendition = new MediaTransformation(jpeg_100x50)
                .Resize(50, 100) // 50%, 200%
                .Crop(0, 0, 25, 25)
                .Encode(FormatId.Jpeg);

            var pipe = Pipeline.From(rendition);

            Assert.Equal("blob#1|>crop(0,0,50,12)|>scale(25,25,lanczos3)|>JPEG::encode", pipe.Canonicalize());
        }

        [Fact]
        public void FilterTest()
        {
            var rendition = new MediaTransformation(jpeg_85x20)
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
                .Apply(new SepiaFilter(0.5f))
                .Encode(FormatId.Jpeg);
              
            var pipe = Pipeline.From(rendition);

            Assert.Equal("blob#1|>scale(255,40,lanczos3)|>blur(5)|>brightness(0.5)|>contrast(0.5)|>invert(0.5)|>grayscale(0.5)|>hueRotate(45deg)|>opacity(0.5)|>pixelate(20)|>saturate(0.5)|>sepia(0.5)|>JPEG::encode", pipe.Canonicalize());

            Assert.Equal(pipe.Canonicalize(), Pipeline.Parse(pipe.Canonicalize()).Canonicalize());
        }

        [Fact]
        public void FilterClamps()
        {
            var rendition = new MediaTransformation(jpeg_85x20)
                .Resize(Unit.Parse("300%"), Unit.Parse("200%"))
                .Apply(new BrightnessFilter(3.5f)) // not clamped
                .Apply(new ContrastFilter(3.5f))   // not clamped
                .Apply(new InvertFilter(1.4f))     // clamped to 1
                .Apply(new GrayscaleFilter(1.3f))  // clamped to 1
                .Apply(new OpacityFilter(1.3f))    // clamped to 1
                .Apply(new SaturateFilter(0.5f))
                .Apply(new SepiaFilter(1.3f))
                .Encode(FormatId.Tiff);

            var pipe = Pipeline.From(rendition);

            var text = pipe.Canonicalize();

            Assert.Equal("blob#1|>scale(255,40,lanczos3)|>brightness(3.5)|>contrast(3.5)|>invert(1)|>grayscale(1)|>opacity(1)|>saturate(0.5)|>sepia(1)|>TIFF::encode", text);

            Assert.Equal(text, Pipeline.Parse(pipe.Canonicalize()).Canonicalize());
        }

        [Fact]
        public void ResizeFit1()
        {
            var rendition = new MediaTransformation(jpeg_100x50)
                .Apply(ResizeTransform.Parse("resize(25x50,fit|upscale)"))
                .Encode(FormatId.Jpeg);

            var pipe = Pipeline.From(rendition);

            Assert.Equal("blob#1|>scale(25,12,lanczos3)|>JPEG::encode", pipe.Canonicalize());
        }

        [Fact]
        public void ResizeFit2()
        {
            var rendition = new MediaTransformation(jpeg_100x50)
                .Apply(ResizeTransform.Parse("resize(200x200,fit|upscale)"))
                .Encode(FormatId.Jpeg);
            
            var pipe = Pipeline.From(rendition);

            Assert.Equal("blob#1|>scale(200,100,lanczos3)|>JPEG::encode", pipe.Canonicalize());
        }

        [Fact]
        public void ResizeFit3()
        {
            var rendition = new MediaTransformation(jpeg_100x50)
                .Apply(ResizeTransform.Parse("resize(25,50,fit)"))
                .Encode(FormatId.Jpeg);

            var pipe = Pipeline.From(rendition);

            Assert.Equal("blob#1|>scale(25,12,lanczos3)|>JPEG::encode", pipe.Canonicalize());
        }

        [Fact]
        public void ResizePercent()
        {
            var rendition = new MediaTransformation(jpeg_85x20)
                .Resize(Unit.Parse("300%"), Unit.Parse("200%"))
                .Encode(FormatId.Jpeg);

            var pipe = Pipeline.From(rendition);
            
            Assert.Equal("blob#1|>scale(255,40,lanczos3)|>JPEG::encode", pipe.Canonicalize());
        }

        [Fact]
        public void Scale1()
        {
            var rendition = new MediaTransformation(jpeg_85x20)
                .Apply(new ScaleTransform(100, 200, InterpolaterMode.Cubic))
                .Encode(FormatId.Jpeg);

            var pipe = Pipeline.From(rendition);

            Assert.Equal("blob#1|>scale(100,200,cubic)|>JPEG::encode", pipe.Canonicalize());
        }

        [Fact]
        public void ResizeAuto()
        {
            var rendition = new MediaTransformation(jpeg_85x20)
                .Resize(Unit.Parse("_"), Unit.Parse("40"))
                .Encode(FormatId.Jpeg);

            Assert.Equal(170, rendition.Width);
            Assert.Equal(40, rendition.Height);

            var pipe = Pipeline.From(rendition);

            Assert.Equal("blob#1|>scale(170,40,lanczos3)|>JPEG::encode", pipe.Canonicalize());
        }



        [Fact]
        public void FilterTest1()
        {
            var t = MediaTransformation.Parse("33695921;100x100/" + string.Join('/', 
                "blur(1)",
                "brightness(1)",
                "contrast(1)",
                "gamma(2)",
                "grayscale(1)",
                "invert(1)",
                "pixelate(1)",
                "sepia(1)",
                "sharpen(1)",
                "vibrance(1)"
             ) + ".jpeg");

            var pipe = Pipeline.From(jpeg_1920x2560, t.GetTransforms());


            Assert.True(pipe.Filters[0] is BlurFilter);
            Assert.True(pipe.Filters[1] is BrightnessFilter);
            Assert.True(pipe.Filters[2] is ContrastFilter);
            Assert.True(pipe.Filters[3] is GammaFilter);
            Assert.True(pipe.Filters[4] is GrayscaleFilter);
            Assert.True(pipe.Filters[5] is InvertFilter);
            Assert.True(pipe.Filters[6] is PixelateFilter);
            Assert.True(pipe.Filters[7] is SepiaFilter);
            Assert.True(pipe.Filters[8] is SharpenFilter);

            Assert.Equal("blob#1|>scale(100,100,lanczos3)|>blur(1)|>brightness(1)|>contrast(1)|>gamma(2)|>grayscale(1)|>invert(1)|>pixelate(1)|>sepia(1)|>sharpen(1)|>vibrance(1)|>JPEG::encode", pipe.Canonicalize());
        }

        [Fact]
        public void Draw1()
        {
            var a = MediaTransformation.Parse("1;draw(circle(radius:5)).heif", jpeg_180x180);

            var pipe = Pipeline.From(a);
            
            Assert.Equal("blob#1|>scale(180,180,lanczos3)|>draw(circle(5))|>HEIF::encode", pipe.Canonicalize());
        }


        [Fact]
        public void DrawCircleWithUnitAndBlendMode()
        {
            var a = MediaTransformation.Parse("1;draw(circle(radius:50%),blendMode:color-burn).heif", jpeg_180x180);

            var pipe = Pipeline.From(a);

            Assert.Equal("blob#1|>scale(180,180,lanczos3)|>draw(circle(50%),blendMode:ColorBurn)|>HEIF::encode", pipe.Canonicalize());
        }

     
        [Fact]
        public void DrawPath1()
        {
            var a = MediaTransformation.Parse("1;draw(path(M150 0 L75 200 L225 200 Z)).heif", jpeg_180x180);

            var pipe = Pipeline.From(a);

            var draw = pipe.Filters[0] as DrawCommand;

            Assert.Equal("M150 0 L75 200 L225 200 Z", (draw.Objects[0] as PathShape).Content);

            Assert.Equal("blob#1|>scale(180,180,lanczos3)|>draw(path(M150 0 L75 200 L225 200 Z))|>HEIF::encode", pipe.Canonicalize());
        }
        
        [Fact]
        public void Draw2()
        {
            var a = MediaTransformation.Parse("1;draw(circle(radius:5),rectangle(100,100,red),fill:red,blendMode:burn).heif", jpeg_180x180);

            var pipe = Pipeline.From(a);
            
            Assert.Equal("blob#1|>scale(180,180,lanczos3)|>draw(circle(5),rectangle(100,100),fill:red,blendMode:ColorBurn)|>HEIF::encode", pipe.Canonicalize());
        }

        [Fact]
        public void Metadata1()
        {
            var a = MediaTransformation.Parse("1;metadata(width,height).json", jpeg_180x180);

            var pipe = Pipeline.From(a);

            Assert.Equal("width", pipe.Metadata.Properties[0]);
            Assert.Equal("height", pipe.Metadata.Properties[1]);

            Assert.Equal("blob#1|>metadata(width,height)|>JSON::encode", pipe.Canonicalize());
        }

        [Fact]
        public void Metadata2()
        {
            var a = MediaTransformation.Parse("1;metadata({width,height,camera}).json", jpeg_180x180);

            var pipe = Pipeline.From(a);

            Assert.Equal("width", pipe.Metadata.Properties[0]);
            Assert.Equal("height", pipe.Metadata.Properties[1]);
            Assert.Equal("camera", pipe.Metadata.Properties[2]);

            Assert.Equal("blob#1|>metadata(width,height,camera)|>JSON::encode", pipe.Canonicalize());
        }


        [Fact]
        public void Metadata3()
        {
            var a = MediaTransformation.Parse("1;metadata.json", jpeg_180x180);

            var pipe = Pipeline.From(a);

            Assert.Equal("blob#1|>metadata|>JSON::encode", pipe.Canonicalize());
        }

    }
}