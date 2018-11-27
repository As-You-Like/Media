using System;
using Carbon.Media.Drawing;

namespace Carbon.Media.Processing
{
    public static class Processor
    {
        public static IProcessor Parse(string text)
        {
            var syntax = CallSyntax.Parse(text);

            switch (syntax.Name)
            {
                // transforms
                case "resize"       : return ResizeTransform.Parse(text);
                case "scale"        : return ScaleTransform.Create(syntax);
                case "crop"         : return CropTransform.Create(syntax);
                case "rotate"       : return RotateTransform.Create(syntax);
                case "flip"         : return FlipTransform.Create(syntax);
                case "orient"       : return OrientTransform.Create(syntax);
                case "pad"          : return PadTransform.Create(syntax);

                case "page"         : return PageFilter.Create(syntax);
                case "frame"        : return FrameFilter.Create(syntax);
                case "timestamp"    : return TimestampFilter.Create(syntax);
                case "background"   : return BackgroundFilter.Create(syntax);
                
                // web filters
                case "blur"         : return BlurFilter.Create(syntax);
                case "brightness"   : return BrightnessFilter.Create(syntax);
                case "contrast"     : return ContrastFilter.Create(syntax);
                case "grayscale"    : return GrayscaleFilter.Create(syntax);
                case "rotateHue"    : return HueRotateFilter.Create(syntax);
                case "hueRotate"    : return HueRotateFilter.Create(syntax);
                case "hue-rotate"   : return HueRotateFilter.Create(syntax);
                case "invert"       : return InvertFilter.Create(syntax);
                case "opacity"      : return OpacityFilter.Create(syntax);
                case "saturate"     : return SaturateFilter.Create(syntax);
                case "sepia"        : return SepiaFilter.Create(syntax);

                // other filters           
                case "highlight"    : return HighlightFilter.Create(syntax);
                case "gamma"        : return GammaFilter.Create(syntax);
                case "halftone"     : return HalftoneFilter.Create(syntax);
                case "pixelate"     : return PixelateFilter.Create(syntax);
                case "quantize"     : return QuantizeFilter.Create(syntax);
                case "sharpen"      : return SharpenFilter.Create(syntax);
                case "vibrance"     : return VibranceFilter.Create(syntax);
                case "detect"       : return DetectFilter.Create(syntax);

                // Audio Filters
                case "volume"       : return VolumeFilter.Create(syntax);

                // Container Filters
                case "bitrate"      : return BitRateFilter.Create(syntax);

                // Drawing
                case "draw"         : return DrawCommand.Parse(text.AsSpan());

                // Other
                case "colors"       : return ColorsFilter.Create(syntax);
                case "metadata"     : return MetadataFilter.Parse(text);
                case "quality"      : return QualityFilter.Create(syntax);
                case "expires"      : return ExpiresFilter.Create(syntax);
                case "tune"         : return TuneFilter.Create(syntax);
                case "profile"      : return ProfileFilter.Create(syntax);
                case "preset"       : return PresetFilter.Create(syntax);

                // Flags
                case "lossless"     : return LosslessFlag.Default;
                case "poster"       : return FrameFilter.Poster;
                case "debug"        : return DebugFilter.Default;

                default             :
                    // JPEG::encode

                    if (text.Contains("encode"))
                    {
                        return EncodeParameters.Parse(text);
                    }
                    else
                    {
                        return CustomFilter.Create(syntax);
                    }
            }
        }
    }
}
