using System;

namespace Carbon.Media
{
    using Geometry;

    public static class ResizeHelper
    {
        // Fit the image without changing the aspect

        public static Size Fit(Size source, Size bounds, bool upscale = false)
        {
            var aspect = source.ToRational();

            var result = Max(bounds, aspect);

            // If we're not upscaling 

            if (!upscale && (result.Width > source.Width || result.Height > source.Height))
            {
                return Max(source, aspect);
            }

            return result;
        }

        // Fits a padded rectangle into the bounds
        public static void Fit(ref Box2 rect, Size bounds, bool upscale = false)
        {
            var outerSize = new Size(rect.OuterWidth, rect.OuterHeight);

            var aspect = outerSize.ToRational();

            var target = Max(bounds, aspect);

            // If we're not upscaling 

            if (!upscale && (target.Width > rect.OuterWidth || target.Height > rect.OuterHeight))
            {
                target = Max(outerSize, aspect);                
            }

            rect.Width = target.Width;
            rect.Height = target.Height;
        }
        
        public static Box2 Pad(Size source, Size bounds, CropAnchor anchor = CropAnchor.Center, bool upscale = false)
        {
            var size = Fit(source, bounds, upscale); // Fit if it doesn't fit or needs upscaling...

            // Distribute the padding
            var extraWidth  = bounds.Width  - size.Width;
            var extraHeight = bounds.Height - size.Height;
        
            int top = extraHeight / 2,
                right = extraWidth / 2,
                bottom = extraHeight / 2,
                left = extraWidth / 2;

            if (anchor.HasFlag(CropAnchor.Left))
            {
                right = extraWidth;
                left = 0;
            }
            else if (anchor.HasFlag(CropAnchor.Right))
            {
                left = extraWidth;
                right = 0;
            }

            if (anchor.HasFlag(CropAnchor.Top))
            {
                bottom = extraHeight;
                top = 0;
            }
            else if (anchor.HasFlag(CropAnchor.Bottom))
            {
                top = extraHeight;
                bottom = 0;
            }

            var padding = new Margin(top, right, bottom, left);

            return new Box2(size, padding);
        }

        // Align the box within the bounds

        public static void Align(ref Rectangle box, Size bounds, CropAnchor anchor)
        {
            double x = 0d,
                   y = 0d;

            // There's horizontal space
            if (box.Width < bounds.Width)
            {
                if (anchor.HasFlag(CropAnchor.Left))
                {
                    x = 0;
                }
                else if (anchor.HasFlag(CropAnchor.Right))
                {
                    x = bounds.Width - box.Width;
                }
                else // center
                {
                    x = (bounds.Width - box.Width) / 2d;
                }
            }
            
            // There's vertical space
            if (box.Height < bounds.Height)
            {
                if (anchor.HasFlag(CropAnchor.Top))
                {
                    y = 0;
                }
                else if (anchor.HasFlag(CropAnchor.Bottom))
                {
                    y = bounds.Height - box.Height;
                }
                else // Center
                {
                    y = (bounds.Height - box.Height) / 2d;
                }
            }

            box.X = x;
            box.Y = y;
        }

        public static Rectangle CalculateCropRectangle(Size sourceSize, Size bounds, CropAnchor anchor)
        {
            double x = 0d,
                   y = 0d,
                   scale = 0d;
            
            double widthP  = (double)bounds.Width / sourceSize.Width;
            double heightP = (double)bounds.Height / sourceSize.Height;

            if (heightP < widthP)
            {
                scale = widthP;

                if (anchor.HasFlag(CropAnchor.Top))
                {
                    y = 0;
                }
                else if (anchor.HasFlag(CropAnchor.Bottom))
                {
                    y = bounds.Height - (sourceSize.Height * scale);
                }
                else // Center
                {
                    y = (bounds.Height - (sourceSize.Height * scale)) / 2d;
                }
            }
            else
            {
                scale = heightP;

                if (anchor.HasFlag(CropAnchor.Left))
                {
                    x = 0;
                }
                else if (anchor.HasFlag(CropAnchor.Right))
                {
                    x = bounds.Width - (sourceSize.Width * scale);
                }
                else // center
                {
                    x = (bounds.Width - (sourceSize.Width * scale)) / 2d;
                }
            }

            return new Rectangle(
                x       : x,
                y       : y,
                width   : sourceSize.Width * scale,
                height  : sourceSize.Height * scale
            );
        }

        /// <summary>
        /// Gets the biggest rectangle that fits within the box at a specific aspect
        /// </summary>
        public static Size Max(Size bounds, Rational aspect)
        {
            double targetAspect = aspect;
            double currentAspect = bounds.ToRational();

            if (currentAspect > targetAspect) // Shrink the width
            {
                int newWidth = (int)(bounds.Height * targetAspect);

                return new Size(newWidth, bounds.Height);
            }
            else if (currentAspect < targetAspect) // Shrink the height
            {
                int newHeight = (int)(bounds.Width / targetAspect);

                return new Size(bounds.Width, newHeight);
            }
            else // Aspects are the same
            {
                return new Size(bounds.Width, bounds.Height);
            }
        }
    }
}