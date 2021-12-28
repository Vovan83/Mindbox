using MindboxShapes;
using NUnit.Framework;
using System;
using System.IO;
using System.Text;

namespace MindboxTest
{
    [TestFixture]
    public class MindboxTestCircle
    {
        [Test]
        public void NegativeRadius()
        {
            Assert.Throws<ArgumentException>(() => new Circle(-1));
        }

        [TestCase(0, 0)]
        [TestCase(1, Math.PI * 1 * 1)]
        [TestCase(1e-6, Math.PI * 1e-6 * 1e-6)]
        [TestCase(1e+6, Math.PI * 1e+6 * 1e+6)]
        public void CalculateSquare(double radius, double expectedSquare)
        {
            IShape shape = new Circle(radius);

            var square = shape.GetSquare();

            Assert.AreEqual(expectedSquare, square, 1e-6);
        }

        [Test]
        public void FactoryCreateTest() 
        {
            IShapeFactory shapeFactory = new SimpleShapeFactory();
            IConsoleInteractions shapeInteractions = shapeFactory.CreateShapeFromName("circle");
            Assert.IsInstanceOf(typeof(Circle), shapeInteractions);
        }

        [Test]
        public void ConsoleSetTest() 
        {
            IConsoleInteractions shapeInteractions = new Circle();
            var shape = shapeInteractions.SetFromConsole(new StringReader($"12{Environment.NewLine}"), new StringWriter());
            Assert.IsInstanceOf(typeof(Circle), shape);
            Assert.AreEqual(((Circle)shape).Radius, 12.0, 1e-5);
        }

        [Test]
        public void ConsoleReportTest()
        {
            var sb = new StringBuilder();
            var shape = new Circle(1.9544100);
            shape.ReportToConsole(new StringWriter(sb));
            var _out = sb.ToString();
            Assert.AreEqual($"The area of the circle is equal to: 12.00000{Environment.NewLine}", _out);
        }
    }
}