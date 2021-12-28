using System;
using System.IO;

namespace MindboxShapes
{

    public class Circle : BaseShape, IShapeCircle
    {

        public Circle() { }

        public Circle(double radius)
        {
            if (radius < 0)
            {
                throw new ArgumentException("The radius cannot be negative");
            }
            Radius = radius;
        }

        public override ShapeType ShapeType => ShapeType.Circle;
        public readonly double Radius;



        public override double GetSquare()
        {
            return Math.PI * Radius * Radius;
        }
        public override BaseShape SetFromConsole(TextReader textReader, TextWriter textWriter)
        {
            textWriter.Write("Enter the radius, decimal separator (.): ");
            var stringRadius = textReader.ReadLine();
            var result = double.TryParse(stringRadius, out double radius);
            if (!result)
            {
                throw new Exception("The wrong number or the wrong decimal separator was entered.");
            }
            return new Circle(radius);
        }

        public override void ReportToConsole(TextWriter textWriter)
        {
            textWriter.WriteLine("The area of the circle is equal to: {0:f5}", GetSquare());
        }
    }
}
