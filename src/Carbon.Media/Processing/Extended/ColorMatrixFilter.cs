using System;

namespace Carbon.Media.Processing
{
    public class ColorMatrixFilter
    {
        public static readonly ColorMatrixFilter Identity = new ColorMatrixFilter(new float[] {
            1, 0, 0, 0, 0,
            1, 0, 0, 0, 0,
            1, 0, 0, 0, 0,
            1, 0, 0, 0, 0
        });
        public ColorMatrixFilter(float[] matrix)
        {
            if (matrix.Length != 20)
            {
                throw new ArgumentException("Must be 20 elements", nameof(matrix));
            }
        }

        // Matrix 4 x 5 | column major
        public float[] Matrix { get; }
    }
}

/*
IDENTITY
| 1 0 0 0 0 |
| 0 1 0 0 0 |
| 0 0 1 0 0 |
| 0 0 0 1 0 |
*/

// 4 x 5 ? 

/*
| M11 M12 M13 M14 M15 |
| M21 M22 M23 M24 M25 |
| M31 M32 M33 M34 M35 |
| M41 M42 M43 M44 M45 |

| M11 M12 M13 M14 M15 |    | R |   | R' |
| M21 M22 M23 M24 M25 |    | G |   | G' |
| M31 M32 M33 M34 M35 |  × | B | = | B' |
| M41 M42 M43 M44 M45 |    | A |   | A' |
                           | 1 |

 */

// https://kazzkiq.github.io/svg-color-filter/