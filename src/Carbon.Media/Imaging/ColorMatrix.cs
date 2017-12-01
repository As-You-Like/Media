/*
using System;

namespace Carbon.Media
{
    public class ColorMatrix
    {
        // R G B A W
        // G
        // B
        // A
        // W

        // Vector4[] rows (rgbaw) ? 

        private float[][] values;

        public ColorMatrix(float[][] values)
        {
            this.values = values ?? throw new ArgumentNullException(nameof(values));

            // red   vector
            // green vector
            // blue  vector
            // alpha vector
            // bias  vector
        }

        public float[][] Values => values;

        // Algorithm:
        // r = dot(r)
        // g = dot(g)
        // b = dot(b)
        // a = dot(a)
    }
}
*/

// https://msdn.microsoft.com/en-us/library/system.drawing.imaging.colormatrix(v=vs.110).aspx