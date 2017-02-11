using System;
using System.Collections.Generic;
using System.Text;

namespace Carbon.Media.Processors
{
    using Geometry;

    public class MediaPipeline
    {
        // Orient (flip, rotate, etc)
        // Crop source
        // Determine canvas size
        // Determine target pixel format     (does the source have an alpha channel? do any of the filters apply an alpha?)
        // Determine color model
        // Determine target color space

        public IMediaSource Source { get; set; }

        // 1. orient

        // 2. crop the source
        public Rectangle? Crop { get; set; }   // The crop applied to the source

        // 3. Scale the crop w/ interpolator
        // Note: The padding should have shrunk the image
        public Scale Scale { get; set; }

        // If the resize mode was set to pad... 
        public Padding Padding { get; set; } = Padding.Zero;
        
        public string Background { get; set; }

        public Position Position
            => new Position { X = Padding.Left, Y = Padding.Top };
        
        public int FinalWidth => Scale.Width + Padding.Left + Padding.Right;

        public int FinalHeight => Scale.Height + Padding.Top + Padding.Bottom;

        // 4. Determine whether we need a canvas to apply filters or draw a background
        public List<IFilter> Filters { get; } = new List<IFilter>();
        
        public Encode Encode { get; set; }

        // blob#1 |> crop(0,0,100,100) |> JPEG(quality:87)
        // blob#1 |> scale(50,50,lancoz) |> draw(background:0xffffff,margin:10) |> pixelate(5px) |> blur(5px) |> sepia(0.5) |> WebP::encode

        // blob#1 |> JPEG::encode(quality:87)
        // blob#1 |> GIF::encode
        // blob#1 |> PNG::encode
        // blob#1 |> WebP::encode

        public static MediaPipeline From(MediaTransformation transformation)
        {
            var pipeline = new MediaPipeline {
                Source = transformation.Source
            };

            var interpolater = InterpolaterMode.Lanczos3;
            Rectangle? crop = null;
            var box = new Box();

            box.Width = pipeline.Source.Width;
            box.Height = pipeline.Source.Height;
            
            foreach (var transform in transformation.GetTransforms())
            {
                if (transform is Crop)
                {
                    var xScale = (double)pipeline.Source.Width / box.Width;
                    var yScale = (double)pipeline.Source.Height / box.Height;

                    var c = ((Crop)transform).GetRectangle(box.Size);

                    box.Width = (int)c.Width;
                    box.Height = (int)c.Height;

                    if (xScale != 1d || yScale != 1d)
                    {
                        c = c.Scale(xScale, yScale);
                    }

                    crop = c;
                }
                else if (transform is Resize)
                {
                    var resize = (Resize)transform;

                    if (resize.Background != null)
                    {
                        pipeline.Background = resize.Background;
                    }

                    var bounds = resize.CalcuateSize(box.Size);

                    bool upscale = resize.Upscale;

                    switch (resize.Mode)
                    {
                        case ResizeFlags.Crop:
                            crop = ResizeHelper.CalculateCropRectangle(box.Size, bounds, resize.Anchor ?? CropAnchor.Center);

                            box.Width = bounds.Width;
                            box.Height = bounds.Height;

                            break;

                        case ResizeFlags.Fit:
                            ResizeHelper.Fit(ref box, bounds, resize.Upscale);
                            break;

                        case ResizeFlags.Pad:
                            box = ResizeHelper.Pad(box.Size, bounds, resize.Anchor ?? CropAnchor.Center, resize.Upscale); break;

                        default: // Exact
                            box.Width = bounds.Width;
                            box.Height = bounds.Height;

                            break;
                    }
                }
                else if (transform is Scale)
                {
                    var scale = (Scale)transform;

                    box.Width = scale.Width;
                    box.Height = scale.Height;

                    if (scale.Mode != InterpolaterMode.None)
                    {
                        interpolater = scale.Mode;
                    }
                }
                else if (transform is Pad)
                {
                    var pad = (Pad)transform;

                    box.Padding = new Padding(
                        top    : box.Padding.Top + pad.Top,
                        right  : box.Padding.Right + pad.Right,
                        bottom : box.Padding.Bottom + pad.Bottom,
                        left   : box.Padding.Left + pad.Left
                    );
                }
                else if (transform is Rotate)
                {
                    var rotate = (Rotate)transform;

                    if (rotate.Angle == 90 || rotate.Angle == 270)
                    {
                        var oldWidth = box.Width;
                        var oldHeight = box.Height;

                        // flip the height & width
                        box.Width = oldHeight;
                        box.Height = oldWidth;
                    }
                }

                else if (transform is IFilter)
                {
                    pipeline.Filters.Add((IFilter)transform);
                }
            }

            pipeline.Crop = crop;

            if (crop == null || crop.Value.Size != box.Size)
            {
                pipeline.Scale = new Scale(box.Width, box.Height, interpolater);
            }

            pipeline.Padding = box.Padding;
            pipeline.Encode = new Encode(ImageFormat.Jpeg, 0);
            
            return pipeline;
        }

        public string Canonicalize()
        {
            var sb = new StringBuilder();

            sb.Append("blob#" + Source.Key);

            if (Crop != null)
            {
                var c = Crop.Value;

                sb.Append("|>");

                sb.Append($"crop({c.X},{c.Y},{c.Width},{c.Height})");
            }

            if (Scale != null)
            {
                sb.Append("|>");

                sb.Append(Scale.Canonicalize());
            }

            // pad(0,0)
            if (!Padding.Equals(Padding.Zero))
            {
                sb.Append("|>");
                sb.Append("pad(");
                sb.Append(Padding.ToString());
                sb.Append(")");
            }

            if (!Padding.Equals(Padding.Zero) || Background != null)
            {
                // sb.Append("|>");

                // var draw = new Draw { Background = Background, Margin = Margin };

                // sb.Append(draw.Canonicalize());
            }

            foreach (var filter in Filters)
            {
                sb.Append("|>");

                sb.Append(filter.Canonicalize());
            }

            sb.Append("|>");

            sb.Append(Encode.Canonicalize());

            return sb.ToString();
        }

        // Final Clip (we may overdraw for blurs)
    }

    public struct Draw
    {
        public Padding Margin { get; set; }

        public string Background { get; set; }

        public string Canonicalize()
        {
            var sb = new StringBuilder();

            sb.Append("draw(");

            if (Background != null)
            {
                sb.Append(",background:");
                sb.Append(Background);
            }

            if (!Margin.Equals(Padding.Zero))
            {
                sb.Append(",margin:");
                sb.Append(Margin.ToString());
            }
            
            sb.Append(")");

            return sb.ToString();
        }
    }

    public struct Position
    {
        public int X;
        public int Y;
    }

  

  

    // how can we define a canvas?

    // Canvas(500,500, color: red)
    // Padding is applied to the scale & becomes a margin in draw phase...
}
