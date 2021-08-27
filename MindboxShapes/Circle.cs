using System;

namespace MindboxShapes
{

    public class Circle : BaseShape, IShapeCircle
    {

        public Circle()
        {

        }

        public Circle(double radius)
        {
            if (radius < 0)
            {
                throw new ArgumentException("The radius cannot be negative");
            }
            Radius = radius;
        }

        public double Radius { get; private set; }

        public override void SetFromConsole()
        {
            Console.Write("Enter the radius, decimal separator (.): ");
            var stringRadius = Console.ReadLine();
            var result = double.TryParse(stringRadius, out double radius);
            if (!result)
            {
                throw new Exception("The wrong number or the wrong decimal separator was entered.");
            }
            Radius = radius;
        }

        public override double GetSquare()
        {
            return Math.PI * Radius * Radius;
        }

        public override void ReportToConsole()
        {
            Console.WriteLine("The area of the circle is equal to: {0:f5}", GetSquare());
        }
    }
}
