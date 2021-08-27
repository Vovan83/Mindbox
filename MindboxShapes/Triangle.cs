using System;
using System.Linq;

namespace MindboxShapes
{
    public class Triangle : BaseShape, IShapeTriangle
    {

        public Triangle()
        {

        }

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

        public double Side1 { get; private set; }
        public double Side2 { get; private set; }
        public double Side3 { get; private set; }

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

        public override void ReportToConsole()
        {
            Console.WriteLine("The area of the triangle is equal to: {0:f5}", GetSquare());
            Console.WriteLine("This triangle {0} rectangular.", IsRectangular() ? "is" : "is not");
        }

        readonly string[] sideLabel = new string[] { "A", "B", "C" };

        double ReadSideFromConsole(int i)
        {
            Console.Write("Enter the side {0}, decimal separator (.): ", sideLabel[i]);
            var stringSide = Console.ReadLine();
            var result = double.TryParse(stringSide, out double side);
            if (!result)
            {
                throw new Exception("the wrong number or the wrong decimal separator was entered.");
            }
            return side;
        }

        public override void SetFromConsole()
        {
            var sides = ReadSidesFromConsole();
            Side1 = sides[0];
            Side2 = sides[1];
            Side3 = sides[2];
        }

        private double[] ReadSidesFromConsole()
        {
            var result = new double[3];
            for (int i = 0; i < 3; i++)
            {
                result[i] = ReadSideFromConsole(i);
            }
            return result;
        }
    }
}
