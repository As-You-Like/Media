namespace Carbon.Media.Processors
{
    public static class Processor
    {
        // TODO: Remove colon once crop has been migrated to new syntax

        private static readonly char[] argStartChars = { '(', ':' };

        public static IProcessor Parse(string segment)
        {
            var indexOfArg = segment.IndexOfAny(argStartChars);

            var name = indexOfArg > -1
                ? segment.Substring(0, indexOfArg)
                : segment;

            switch (name)
            {
                // Transforms
                case "resize"       : return ResizeTransform.Parse(segment);
                case "scale"        : return ScaleTransform.Parse(segment);
                case "crop"         : return CropTransform.Parse(segment);
                case "rotate"       : return RotateTransform.Parse(segment);
                case "flip"         : return FlipTransform.Parse(segment);
                case "pad"          : return PadTransform.Parse(segment);

                case "page"         : return PageFilter.Parse(segment);
                case "frame"        : return FrameFilter.Parse(segment);        
                case "background"   : return BackgroundFilter.Parse(segment);
                
                // web filters
                case "blur"         : return BlurFilter.Parse(segment);
                case "brightness"   : return BrightnessFilter.Parse(segment);
                case "contrast"     : return ContrastFilter.Parse(segment);
                case "grayscale"    : return GrayscaleFilter.Parse(segment);
                case "rotateHue"    : return HueRotateFilter.Parse(segment);
                case "hueRotate"    : return HueRotateFilter.Parse(segment);
                case "hue-rotate"   : return HueRotateFilter.Parse(segment);
                case "invert"       : return InvertFilter.Parse(segment);
                case "opacity"      : return OpacityFilter.Parse(segment);
                case "saturate"     : return SaturateFilter.Parse(segment);
                case "sepia"        : return SepiaFilter.Parse(segment);

                // General Filters           
                case "highlight"    : return HighlightFilter.Parse(segment);
                case "gamma"        : return GammaFilter.Parse(segment);
                case "halftone"     : return HalftoneFilter.Parse(segment);
                case "pixelate"     : return PixelateFilter.Parse(segment);
                case "quantize"     : return QuantizeFilter.Parse(segment);
                case "sharpen"      : return SharpenFilter.Parse(segment);
                case "vibrance"     : return VibranceFilter.Parse(segment);

                // Audio Filters
                case "volume"       : return VolumeFilter.Parse(segment);

                // Drawing
                case "draw"         : return DrawFilter.Parse(segment);

                // Other
                case "metadata"     : return MetadataFilter.Parse(segment);
                case "quality"      : return Quality.Parse(segment);

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
                        return CustomFilter.Parse(segment);
                    }
            }
        }
    }
}
