using System;
using Carbon.Media.Processing;
using Xunit;

namespace Carbon.Media.Tests
{
    public class MediaTransformTests
    {
        [Fact]
        public void Detect()
        {
            var source = new MediaSource("37117398", 960, 540);

            var transformation = MediaTransformation.Parse("detect(edges,lanzcos5)/960x540.webp", source);

            var detectFilter = transformation[0] as DetectFilter;

            Assert.Equal("edges", detectFilter.Name);
            Assert.Equal("lanzcos5", detectFilter.Algorithm);

            Assert.Equal("960x540/detect(edges,algorithm:lanzcos5).webp", new MediaRenditionInfo(null, transformation).TransformPath);

            Assert.Equal("960x540/detect(edges).webp", new MediaRenditionInfo(null, MediaTransformation.Parse("detect(edges).webp", source)).TransformPath);
        }

        [Fact]
        public void Poster()
        {
            var source = new MediaSource("37117398", 960, 540);

            var transformation = MediaTransformation.Parse("poster/960x540.webp", source);

            Assert.Equal(FrameFilter.Poster, transformation[0]);

            Assert.Equal("poster/960x540.webp", new MediaRenditionInfo(null, transformation).TransformPath);
            
            Assert.Equal("blob#37117398|>frame(0)|>scale(960,540,lanczos3)|>WebP::encode", transformation.ToPipeline().Canonicalize());

        }

        [Fact]
        public void Preset()
        {
            var source = new MediaSource("37117398", 960, 540);
            
            var transformation = MediaTransformation.Parse("preset(ultrafast)/960x540.mp4", source);

            Assert.Equal("ultrafast", (transformation[0] as PresetFilter).Name);
            Assert.Equal(FormatId.Mp4, transformation.Encoder.Format);

            Assert.Equal("960x540/preset(ultrafast).mp4", new MediaRenditionInfo(null, transformation).TransformPath);
        }

        [Fact]
        public void Profile()
        {
            var source = new MediaSource("37117398", 960, 540);

            var transformation = MediaTransformation.Parse("profile(high444)/960x540.mp4", source);

            Assert.Equal("high444", (transformation[0] as ProfileFilter).Name);

            Assert.Equal("960x540/profile(high444).mp4", new MediaRenditionInfo(null, transformation).TransformPath);
        }

        [Fact]
        public void Tune()
        {
            var source = new MediaSource("37117398", 960, 540);

            var transformation = MediaTransformation.Parse("tune(animation)/960x540.webm", source);

            Assert.Equal("animation", (transformation[0] as TuneFilter).Name);
            Assert.Equal(FormatId.WebM, transformation.Encoder.Format);

            Assert.Equal("960x540/tune(animation).webm", new MediaRenditionInfo(null, transformation).TransformPath);
        }

        [Fact]
        public void R()
        {
            MediaTransformation.Parse("11840747;900x700.webp");
            MediaTransformation.Parse("900x700.webp");
            MediaTransformation.Parse("/900x700.webp");

        }
        [Theory]
        [InlineData("page(1)/crop(3,0,809,1056)/92x120/bg(fff).webp")]
        [InlineData("background(red)/frame(18)/100x100-c.png")]
        [InlineData("100x100-t.m4v")]
        public void ParseDoesNotChangeOutput(string text)
        {
            Assert.Equal(text, MediaTransformation.Parse(text).GetTransformPath());
        }

        [Fact]
        public void F()
        {
            var source = new MediaSource("37117398", 1125, 1500);

            var transformation = MediaTransformation.Parse("page(1)/crop(3,0,809,1056)/92x120/bg(fff).webp", source);

            Assert.Equal("page(1)/crop(3,0,809,1056)/92x120/bg(fff).webp", new MediaRenditionInfo(null, transformation, seperator: '/').TransformPath);

            var rendition = new MediaRenditionInfo(null, transformation, seperator: '/');

            var scaled = rendition.Scale(2);


            Assert.Equal("/37117398/page(1)/crop(3,0,809,1056)/184x240/bg(fff).webp", scaled.ToString());
        }

        [Fact]
        public void D()
        {
            // https://carbonmade-media.accelerator.net/35240287;600x800/crop(80,0,450,800).webp

            var source = new MediaSource("35240287", 1125, 1500);
            
            var transformation = MediaTransformation.Parse("35240287;600x800/crop(80,0,450,800).webp", source);

            Assert.Equal("crop(150,0,843,1500)/450x800.webp", new MediaRenditionInfo(null, transformation).TransformPath);

            var rendition = new MediaRenditionInfo(null, transformation);

            rendition.Resize(100, 100);

            Assert.Equal("/35240287;crop(150,0,843,1500)/450x800.webp", rendition.ToString());
        }

        [Fact]
        public void E()
        {
            var source = new MediaSource("35240287", 1125, 1500);

            var transformation = new MediaTransformation(source);

            transformation.Apply(MediaTransformation.ParseTransforms(new[] { "500x500" }));

            transformation.Encode(FormatId.Png);
            
            Assert.Equal("500x500.png", new MediaRenditionInfo(null, transformation).TransformPath);
        }


        [Fact]
        public void ToPipelineTests()
        {
            var source = new MediaSource("1", 2000, 2000);

            var transformation = MediaTransformation.Parse("1;2000x2000/crop(97,21,480,360).jpeg", source);

            Assert.Equal(480, transformation.Width);
            Assert.Equal(360, transformation.Height);
            
            var pipeline = Pipeline.From(transformation);

            Assert.Equal("blob#1|>crop(97,21,480,360)|>JPEG::encode", pipeline.Canonicalize());
        }


        [Fact]
        public void DoubleResizeUp()
        {
            var source = new MediaSource("1", 2000, 2000);

            var transformation = MediaTransformation.Parse("1;2000x2000/crop(97,21,480,360)/960x720.jpeg", source);

            Assert.Equal(960, transformation.Width);
            Assert.Equal(720, transformation.Height);

            var pipeline = Pipeline.From(transformation);

            Assert.Equal("blob#1|>crop(97,21,480,360)|>scale(960,720,lanczos3)|>JPEG::encode", pipeline.Canonicalize());
            
            Assert.Equal("crop(97,21,480,360)/960x720.jpeg", pipeline.ToTransformPath());

        }

        [Fact]
        public void DoubleResizeDown()
        {
            var source = new MediaSource("1", 2000, 2000);

            var transformation = MediaTransformation.Parse("blob;2000x2000/crop(97,21,480,360)/240x180.jpeg", source);

            var pipeline = transformation.ToPipeline();

            // TODO: how do we flip crop & scale order...

            var scale = pipeline.Scale.Width / (double)pipeline.Crop.Value.Width; // 50%

            Assert.Equal("crop(97,21,480,360)/240x180.jpeg", pipeline.ToTransformPath());

            var rendition = new MediaRenditionInfo(null, transformation);

            Assert.Equal("crop(97,21,480,360)/240x180.jpeg", rendition.TransformPath);
        }

        [Fact]
        public void Q()
        {
            var source = new MediaSource("1", 2000, 2000);

            var transformation = MediaTransformation.Parse("blob;1300x1300/crop(56,62,480,360).jpeg", source);
            
            var pipeline = transformation.ToPipeline();

            var scale = pipeline.Scale.Width / (double)pipeline.Crop.Value.Width;
            
            Assert.Equal(0.650406504065041, scale, 5);

            Assert.Equal(1300, (int)(source.Width * scale));
            Assert.Equal(1300, (int)(source.Height * scale));

            Assert.Equal(55, (int)(pipeline.Crop.Value.X * scale));
            Assert.Equal(61, (int)(pipeline.Crop.Value.Y * scale));
            Assert.Equal(480, (int)(pipeline.Crop.Value.Width * scale));
            Assert.Equal(359, (int)(pipeline.Crop.Value.Height * scale));
            
            Assert.Equal("crop(86,95,738,553)/480x360.jpeg", pipeline.ToTransformPath());
        }

        [Fact]
        public void A()
        {
            Assert.Throws<InvalidTransformException>(() => MediaTransformation.Parse("10888535;500x500-c/pixelate(5)//grayscale(0.1).png"));
            Assert.Throws<InvalidTransformException>(() => MediaTransformation.Parse("10888535;500x500-c/grayscale(-1)/grayscale(0.1).png"));
        }

        [Fact]
        public void OrientTest3()
        {
            var t = MediaTransformation.Parse("33695921;960x1280/rotate(90).jpeg");

            Assert.Equal("33695921", t.Source.Key);

            var resize = t[0] as ResizeTransform;
            var rotate = t[1] as RotateTransform;
            var encode = t[2] as EncodeParameters;

            Assert.Equal((960, 1280), (resize.Width, resize.Height));
            Assert.Equal(90, rotate.Angle);
            Assert.Equal(FormatId.Jpeg, encode.Format);
        }

        [Fact]
        public void B()
        {
            try
            {
                var a = MediaTransformation.Parse("10888535;500x500-c/blur(2001).png");
            }
            catch (InvalidTransformException ex)
            {
                Assert.Equal(1, ex.Index);

                // Assert.Equal("Must be between 0 and 2,000", ex.InnerException.Message);
                Assert.Equal(typeof(ArgumentOutOfRangeException), ex.InnerException.GetType());
            }
        }


        
        [Fact]
        public void C()
        {
            try
            {
                var a = MediaTransformation.Parse("10888535;500x500-c/blur(2000)/sepia(-1).png");
            }
            catch (InvalidTransformException ex)
            {
                Assert.Equal(2, ex.Index);

                // Assert.Equal("Must be >= 0", ex.Message);
            }
        }
    }
}