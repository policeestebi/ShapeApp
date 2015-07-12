using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShapeApp.Entities;

namespace ShapeApp.UnitTesting
{
    [TestClass]
    public class ShapeUnitTest
    {
        [TestMethod]
        public void IsPointInsideShouldReturnTrue_Circle()
        {
            var circle = new Circle("circle 1.7 5.05 1");

            var point = new Point(Convert.ToDecimal(2), Convert.ToDecimal(4.70));

            var result = circle.IsPointInside(point);

            Assert.IsTrue(result);

        }

        [TestMethod]
        public void IsPointInsideShouldReturnFalse_Circle()
        {
            var circle = new Circle("circle 1.7 5.05 1");

            var point = new Point(Convert.ToDecimal(8.50), Convert.ToDecimal(7));

            var result = circle.IsPointInside(point);

            Assert.IsFalse(result);

        }

        [TestMethod]
        public void IsPointInsideShoouldReturnTrue_Rectangle()
        {
            var rectangle = new Rectangle("rectangle 7 28 41 32");
            var point = new Point(Convert.ToDecimal(20), Convert.ToDecimal(20));

            var result = rectangle.IsPointInside(point);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsPointInsideShoouldReturnFalse_Rectangle()
        {
            var rectangle = new Rectangle("rectangle 7 28 41 32");
            var point = new Point(Convert.ToDecimal(35), Convert.ToDecimal(55));

            var result = rectangle.IsPointInside(point);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsPointInsideShouldReturnTrue_Square()
        {
            var square = new Square("square 7 28 41");
            var point = new Point(Convert.ToDecimal(20), Convert.ToDecimal(20));

            var result = square.IsPointInside(point);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsPointInsideShoouldReturnFalse_Square()
        {
            var square = new Square("square 7 28 41");
            var point = new Point(Convert.ToDecimal(35), Convert.ToDecimal(55));

            var result = square.IsPointInside(point);

            Assert.IsFalse(result);
        }


        [TestMethod]
        public void IsPointInsideShoouldReturnTrue_Triangle()
        {
            var triangle = new Triangle("triangle 1 2 3 5 5 2");
            var point = new Point(Convert.ToDecimal(3), Convert.ToDecimal(3));

            var result = triangle.IsPointInside(point);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsPointInsideShoouldReturnFalse_Triangle()
        {
            var triangle = new Triangle("triangle 1 2 3 5 5 2");
            var point = new Point(Convert.ToDecimal(5), Convert.ToDecimal(5));

            var result = triangle.IsPointInside(point);

            Assert.IsFalse(result);
        }



        [TestMethod]
        public void IsPointInsideShouldReturnTrue_Donut()
        {
            var donut = new Donut("donut 5 5 1 3");

            var point = new Point(Convert.ToDecimal(5), Convert.ToDecimal(7));

            var result = donut.IsPointInside(point);

            Assert.IsTrue(result);

        }

        [TestMethod]
        public void IsPointInsideShouldReturnFalse_Donut()
        {
            var donut = new Donut("donut 5 5 1 3");

            var point = new Point(Convert.ToDecimal(5), Convert.ToDecimal(5));

            var result = donut.IsPointInside(point);

            Assert.IsFalse(result);

        }

    }
}
