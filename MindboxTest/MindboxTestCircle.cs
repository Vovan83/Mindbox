using MindboxShapes;
using NUnit.Framework;
using System;

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
    }
}