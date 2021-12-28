using MindboxShapes;
using NUnit.Framework;
using System;
using System.IO;
using System.Text;

namespace MindboxTest
{
    [TestFixture]
    class MindboxTestTriangle
    {
        [TestCase(0,0,-1)]
        [TestCase(0,-1,0)]
        [TestCase(-1,0,0)]
        [TestCase(-1,-1,-1)]
        public void NegativeSide(double side1, double side2, double side3)
        {
            Assert.Throws<ArgumentException>(() => new Triangle(side1, side2, side3));
        }

        [TestCase(0, 0, 0, 0)]
        [TestCase(1, 1, 1, 0.433012)]
        public void CalculateSquare(double side1, double side2, double side3, double expectedSquare)
        {
            IShape shape = new Triangle(side1, side2, side3);

            var square = shape.GetSquare();

            Assert.AreEqual(expectedSquare, square, 1e-6);
        }

        [TestCase(1, 1, 1.41421356237, true)]
        [TestCase(1, 1, 1, false)]
        [TestCase(9, 9, 12.72792206, true)]
        [TestCase(3, 9, 9.486832980, true)]
        public void IsRectangular(double side1, double side2, double side3, bool isRectangularExpected)
        {
            IShapeTriangle shape = new Triangle(side1, side2, side3);

            var isRectangular = shape.IsRectangular();

            Assert.AreEqual(isRectangularExpected, isRectangular);
        }

        [Test]
        public void FactoryCreateTest()
        {
            IShapeFactory shapeFactory = new SimpleShapeFactory();
            IConsoleInteractions shapeInteractions = shapeFactory.CreateShapeFromName("triangle");
            Assert.IsInstanceOf(typeof(Triangle), shapeInteractions);
        }

        [Test]
        public void ConsoleSetTest()
        {
            IConsoleInteractions shapeInteractions = new Triangle();
            var shape = shapeInteractions.SetFromConsole(new StringReader($"12{Environment.NewLine}12{Environment.NewLine}12{Environment.NewLine}"), new StringWriter());
            Assert.IsInstanceOf(typeof(Triangle), shape);
            Assert.AreEqual(((Triangle)shape).Side1, 12.0, 1e-5);
            Assert.AreEqual(((Triangle)shape).Side2, 12.0, 1e-5);
            Assert.AreEqual(((Triangle)shape).Side3, 12.0, 1e-5);
        }

        [Test]
        public void ConsoleReportTest()
        {
            var sb = new StringBuilder();
            var shape = new Triangle(1, 1, 1.41421356237);
            shape.ReportToConsole(new StringWriter(sb));
            var _out = sb.ToString();
            Assert.AreEqual($"The area of the triangle is equal to: 0.50000{Environment.NewLine}This triangle is rectangular.{Environment.NewLine}", _out);
        }
    }
}
