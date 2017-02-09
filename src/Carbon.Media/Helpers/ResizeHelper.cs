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

            var target = Max(bounds, aspect);

            // If we're not upscaling 

            if (!upscale && (target.Height > source.Height || target.Width > source.Width))
            {
                return Max(source, aspect);
            }

            return target;
        }

        /*
        // TODO: Determine how to distribute the padding based on the alignment...
        public static void PadCrop(ref Rectangle box, Padding padding)
        {
            var size = new Size(box.Width, box.Height);

            box.Width  -= (padding.Left + padding.Right);
            box.Height -= (padding.Top + padding.Bottom);

            Align(ref box, size, CropAnchor.Center);
        }
        */

        // Align the box within the bounds

        public static void Align(ref Rectangle box, Size bounds, CropAnchor anchor)
        {
            var x = 0d;
            var y = 0d;

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