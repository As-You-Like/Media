
using System;

namespace Carbon.Media
{
    // The Skia Color Matrix is 4 x 5
    // ImageSharp & MagicScalar matrixes are 4x4

    /*
    public class ColorMatrix
    {
        // R G B A W
        // G
        // B
        // A
        // W

        // Vector4[] rows (rgbaw) ? 
        
        public ColorMatrix(float[] values)
        {
            if (values is null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            if (values.Length != 25)
            {
                throw new Exception("Must contain 25 elements");
            }

            Values = values ?? throw new ArgumentNullException(nameof(values));

          
        }

        public readonly float[] Values;


        // Algorithm:
        // r = dot(r)
        // g = dot(g)
        // b = dot(b)
        // a = dot(a)
    }

    */

    // red   vector
    // green vector
    // blue  vector
    // alpha vector
    // bias  vector
}


// https://msdn.microsoft.com/en-us/library/system.drawing.imaging.colormatrix(v=vs.110).aspx
// https://developer.android.com/reference/android/graphics/ColorMatrix.html