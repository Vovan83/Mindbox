using System;

namespace MindboxShapes
{

    public class Circle : BaseShape, IShapeCircle
    {

        public Circle(double radius)
        {
            if (radius < 0)
            {
                throw new ArgumentException("The radius cannot be negative");
            }
            Radius = radius;
        }

        public double Radius { get; }

        public override double GetSquare()
        {
            return Math.PI * Radius * Radius;
        }
    }
}
