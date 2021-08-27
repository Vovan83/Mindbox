using System;
using System.Linq;

namespace MindboxShapes
{
    public class Triangle : BaseShape, IShapeTriangle
    {

        public Triangle(double side1, double side2, double side3)
        {
            if (side1 < 0 || side2 < 0 || side3 < 0)
            {
                throw new ArgumentException("The side of triangle cannot be negative");
            }

            Side1 = side1;
            Side2 = side2;
            Side3 = side3;
        }

        public double Side1 { get; }
        public double Side2 { get; }
        public double Side3 { get; }

        public override double GetSquare()
        {
            var halfPerimeter = (Side1 + Side2 + Side3) / 2;
            return Math.Sqrt(halfPerimeter * ((halfPerimeter - Side1) * (halfPerimeter - Side2) * (halfPerimeter - Side3)));
        }

        public bool IsRectangular()
        {
            var sides = new[] { Side1, Side2, Side3, };
            var sortedSides = sides.OrderByDescending(side => side).ToArray();
            return Math.Abs(sortedSides[0] * sortedSides[0] - sortedSides[1] * sortedSides[1] - sortedSides[2] * sortedSides[2]) < 1e-6; ;
        }
    }
}
