using System;
using System.Drawing;
using System.Collections.Generic;
using System.Text;

namespace Carbon.Media.Processors
{
    public class MediaPipeline
    {
        // Orient (flip, rotate, etc)
        // Crop source
        // Determine canvas size
        // Determine target pixel format     (does the source have an alpha channel? do any of the filters apply an alpha?)
        // Determine color model
        // Determine target color space

        public IMediaSource Source { get; set; }

        public int? PageNumber { get; set; }

        // 1. Flip
        public Flip Flip { get; set; }

        // 2. Rotate
        public int Rotate { get; set; }

        // 2. Crop the source
        public Rectangle? Crop { get; set; }   // The crop applied to the source

        // 3. Scale the croped source w/ the interpolator
        public Scale Scale { get; set; }

        // If the resize mode was set to pad (or padding was added after) 
        public Padding Padding { get; set; } = Padding.Zero;
        
        public string Background { get; set; }

        public Position Position => new Position(Padding.Left, Padding.Top);
        
        public int FinalWidth => Scale.Width + Padding.Left + Padding.Right;

        public int FinalHeight => Scale.Height + Padding.Top + Padding.Bottom;

        public Size FinalSize => new Size(FinalWidth, FinalHeight);

        // 4. Determine whether we need a canvas to apply filters or draw a background
        // Filters & Draws
        public List<ITransform> Filters { get; } = new List<ITransform>();
        
        public ImageEncode Encode { get; set; }

        // blob#1 |> orient(x) |> crop(0,0,100,100) |> JPEG(quality:87)

        // blob#1 |> crop(0,0,100,100) |> JPEG(quality:87)
        // blob#1 |> scale(50,50,lancoz) |> draw(background:0xffffff,margin:10) |> pixelate(5px) |> blur(5px) |> sepia(0.5) |> WebP::encode

        // blob#1 |> crop(0,0,100,100) |> JPEG::encode(quality:87)
        // blob#1 |> JPEG::encode(quality:87)
        // blob#1 |> WebP::encode

        public static MediaPipeline From(MediaTransformation transformation)
        {
            return From(transformation.Source, transformation.GetTransforms());
        }

        public static MediaPipeline From(IMediaSource source, IReadOnlyList<ITransform> processors)
        {
            var pipeline = new MediaPipeline {
                Source = source
            };

            if (source.Orientation != null)
            {
                switch(source.Orientation.Value)
                {
                    case ExifOrientation.FlipHorizontal : pipeline.Flip   = Flip.Horizontally;  break;
                    case ExifOrientation.Rotate180      : pipeline.Rotate = 180;                break;
                    case ExifOrientation.FlipVertical   : pipeline.Flip   = Flip.Vertically;    break;

                    case ExifOrientation.Transpose      : pipeline.Flip = Flip.Horizontally;
                                                          pipeline.Rotate = 270; break;

                    case ExifOrientation.Rotate90       : pipeline.Rotate = 90;                 break;

                    case ExifOrientation.Transverse     : pipeline.Flip = Flip.Horizontally;
                                                          pipeline.Rotate = 90; break;
                    case ExifOrientation.Rotate270      : pipeline.Rotate = 270;                break;
                }
            }

            var sourceSize = new Size(source.Width, source.Height);

            var interpolater = InterpolaterMode.Lanczos3;
            Rectangle? crop = null;

            var box = new Box {
                Width = sourceSize.Width,
                Height = sourceSize.Height
            };

            int? quality = null;

            foreach (var transform in processors)
            {
                if (transform is Page page)
                {
                    pipeline.PageNumber = page.Number;
                }
                else if (transform is Background background)
                {
                    pipeline.Background = background.Color;
                }
                else if (transform is Flip flip)
                {
                    // Do we need to apply the operations in reverse?
                    pipeline.Flip = flip;
                }
                else if (transform is Crop ct)
                {
                    var xScale = (double)pipeline.Source.Width / box.Width;
                    var yScale = (double)pipeline.Source.Height / box.Height;

                    var c = ct.GetRectangle(box.Size);

                    box.Width = (int)c.Width;
                    box.Height = (int)c.Height;

                    if (xScale != 1d || yScale != 1d)
                    {
                        c = c.Scale(xScale, yScale);
                    }

                    crop = c;
                }
                else if (transform is Quality q)
                {
                    quality = q.Value;
                }
                else if (transform is Resize resize)
                {
                    if (resize.Background != null)
                    {
                        pipeline.Background = resize.Background;
                    }

                    var bounds = resize.CalcuateSize(box.Size);

                    bool upscale = resize.Upscale;

                    switch (resize.Mode)
                    {
                        case ResizeFlags.Crop:
                            crop = ResizeHelper.CalculateCropRectangle(box.Size, bounds.ToRational(), resize.Anchor ?? CropAnchor.Center);

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
                else if (transform is Scale scale)
                {
                    box.Width = scale.Width;
                    box.Height = scale.Height;

                    if (scale.Mode != InterpolaterMode.None)
                    {
                        interpolater = scale.Mode;
                    }
                }
                else if (transform is Pad pad)
                {
                    box.Padding = new Padding(
                        top     : box.Padding.Top + pad.Top,
                        right   : box.Padding.Right + pad.Right,
                        bottom  : box.Padding.Bottom + pad.Bottom,
                        left    : box.Padding.Left + pad.Left
                    );
                }
                else if (transform is Rotate rotate)
                {
                    if (rotate.Angle == 90 || rotate.Angle == 270)
                    {
                        var oldSize = box.Size;

                        // flip the height & width
                        box.Width = oldSize.Height;
                        box.Height = oldSize.Width;

                        if (crop != null)
                        {
                            var oldCrop = crop.Value;

                            crop = new Rectangle(oldCrop.Y, oldCrop.X, oldCrop.Height, oldCrop.Width);
                        }
                    }


                    // TODO: Consider existing orientation

                    pipeline.Rotate = rotate.Angle;
                }
                else if (transform is ImageEncode encode)
                {
                    if (quality != null)
                    {
                        encode = new ImageEncode(encode.Format, quality);
                    }

                    pipeline.Encode = encode;
                }
                else
                {
                    pipeline.Filters.Add(transform);
                }
            }

            pipeline.Crop = crop;

            if (crop == null || crop.Value.Size != box.Size)
            {
                pipeline.Scale = new Scale(box.Size, interpolater);
            }

            pipeline.Padding = box.Padding;
            
            return pipeline;
        }

        public static MediaPipeline Parse(string text)
        {
            var segments = text.Split(new[] { "|>" }, 50, StringSplitOptions.None);

            /*
               blob#1 
            |> scale(50,50,lancoz)
            |> draw(background:0xffffff,margin:10) 
            |> pixelate(5px) 
            |> blur(5px) 
            |> sepia(0.5) 
            |> WebP::encode
            */

            var result = new MediaPipeline();

            foreach (var segment in segments)
            {
                if (segment.Contains("#"))
                {
                    var id = segment.Split('#')[1];

                    result.Source = new MediaSource(id, 100, 100);

                    continue;
                }

                var transform = Transform.Parse(segment);

                switch (transform)
                {
                    case Page page:
                        result.PageNumber = page.Number;
                        break;
                    case Background bg:
                        result.Background = bg.Color;
                        break;
                    case Rotate rotate:
                        result.Rotate = rotate.Angle;
                        break;
                    case Flip flip:
                        result.Flip = flip;
                        break;
                    case Scale scale:
                        result.Scale = scale;
                        break;
                    case Crop crop:
                        result.Crop = crop.GetRectangle();
                        break;
                    case ImageEncode encode:
                        result.Encode = encode;
                        break;
                    default:
                        result.Filters.Add(transform);
                        break;
                }
            }

            return result;
        }

        public string Canonicalize()
        {
            var sb = new StringBuilder();

            sb.Append("blob#" + Source.Key);

            if (PageNumber != null)
            {
                sb.Append("|>page(" + PageNumber + ")");
            }
            if (Background != null)
            {
                sb.Append("|>background(" + Background + ")");
            }

            if (Flip != null)
            {
                sb.Append("|>");
                sb.Append(Flip.Canonicalize());
            }

            if (Rotate != 0)
            {
                sb.Append("|>rotate(");
                sb.Append(Rotate);
                sb.Append("deg)");
            }

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

            if (Background != null)
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
    }

    // how can we define a canvas?

    // Canvas(500,500, color: red)
    // Padding is applied to the scale & becomes a margin in draw phase...
}
