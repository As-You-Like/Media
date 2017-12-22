namespace Carbon.Media.Processors
{
    public static class Processor
    {
        // TODO: Remove colon once crop has been migrated to new syntax

        private static readonly char[] argStartChars = { '(', ':' };

        public static IProcessor Parse(string segment)
        {
            var indexOfArg = segment.IndexOfAny(argStartChars);

            var syntax = CallSyntax.Parse(segment);

            switch (syntax.Name)
            {
                // Transforms
                case "resize"       : return ResizeTransform.Parse(segment);
                case "scale"        : return ScaleTransform.Create(syntax);
                case "crop"         : return CropTransform.Parse(segment); // still supports legacy syntax...
                case "rotate"       : return RotateTransform.Create(syntax);
                case "flip"         : return FlipTransform.Create(syntax);
                case "orient"       : return OrientTransform.Create(syntax);
                case "pad"          : return PadTransform.Create(syntax);

                case "page"         : return PageFilter.Create(syntax);
                case "frame"        : return FrameFilter.Create(syntax);        
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

                // General Filters           
                case "highlight"    : return HighlightFilter.Create(syntax);
                case "gamma"        : return GammaFilter.Create(syntax);
                case "halftone"     : return HalftoneFilter.Create(syntax);
                case "pixelate"     : return PixelateFilter.Create(syntax);
                case "quantize"     : return QuantizeFilter.Create(syntax);
                case "sharpen"      : return SharpenFilter.Create(syntax);
                case "vibrance"     : return VibranceFilter.Create(syntax);

                // Audio Filters
                case "volume"       : return VolumeFilter.Create(syntax);

                // Drawing
                case "draw"         : return DrawFilter.Parse(segment);

                // Other
                case "metadata"     : return MetadataFilter.Parse(segment);
                case "quality"      : return QualityFilter.Create(syntax);

                // Boolean Options
                case "lossless"     : return LosslessFilter.Default;
                case "debug"        : return DebugFilter.Default;

                default             :
                    // JPEG::encode

                    if (segment.Contains("encode"))
                    {
                        return Encode.Parse(segment);
                    }
                    else
                    {
                        return CustomFilter.Create(syntax);
                    }
            }
        }
    }
}
