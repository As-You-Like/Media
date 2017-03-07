namespace Carbon.Media
{
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

        // Fits a padded box into the bounds
        public static void Fit(ref Box rect, Size bounds, bool upscale = false)
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
        
        public static Box Pad(Size source, Size bounds, CropAnchor anchor = CropAnchor.Center, bool upscale = false)
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
            else
            {
                // If we split on a pixel, add 1px to the left
                if (extraWidth % 2 == 1)
                {
                    left += 1;
                }
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
            else
            {
                // If we split on a pixel, add 1px to the top
                if (extraHeight % 2 == 1)
                {
                    top += 1;
                }
            }

            var padding = new Padding(top, right, bottom, left);

            return new Box(size, padding);
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

            box.X = (int)x;
            box.Y = (int)y;
        }

        public static Rectangle CalculateCropRectangle(Size source, Rational aspect, CropAnchor anchor)
        {
            var targetSize = Max(source, aspect);

            return CalculateCropRectangle(source, targetSize, anchor);
        }

        // source is ALWAYS bigger than bounds
        private static Rectangle CalculateCropRectangle(Size source, Size target, CropAnchor anchor)
        {
            int x = 0,
                y = 0;
       
            // There's veritical space to distribute
            if (source.Height > target.Height)
            {
                if (anchor.HasFlag(CropAnchor.Top))
                {
                    y = 0;
                }
                else if (anchor.HasFlag(CropAnchor.Bottom))
                {
                    y = source.Height - target.Height;
                }
                else // Center
                {
                    y = (int)((source.Height - target.Height) / 2d);
                }
            }
            
            // There's horizontal space to distribute
            if (source.Width > target.Width)
            { 
                if (anchor.HasFlag(CropAnchor.Left))
                {
                    x = 0;
                }
                else if (anchor.HasFlag(CropAnchor.Right))
                {
                    x = source.Width - target.Width;
                }
                else // center
                {
                    x = (int)((source.Width - target.Width) / 2d);
                }
            }

            return new Rectangle(x, y, new Size(target.Width, target.Height));
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