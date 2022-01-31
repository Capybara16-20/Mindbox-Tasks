using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using Figures;

namespace FiguresTests
{
    public class TriangleTests
    {
        [Test]
        public void TestConstructor_NormalSides_Created
            ([ValueSource(nameof(Constructor_NormalSides))] double a, 
            [ValueSource(nameof(Constructor_NormalSides))] double b, 
            [ValueSource(nameof(Constructor_NormalSides))] double c)
        {
            Triangle triangle = new Triangle(a, b, c);

            Assert.IsNotNull(triangle);
        }

        public static IEnumerable<double> Constructor_NormalSides
        {
            get
            {
                double a = 3.2;
                double b = 4.1;
                double c = 5.3;

                yield return a;
                yield return b;
                yield return c;
            }
        }

        [Test]
        public void TestConstructor_NegativeSides_Exception
            ([ValueSource(nameof(Constructor_NegativeSides))] double a,
            [ValueSource(nameof(Constructor_NegativeSides))] double b, 
            [ValueSource(nameof(Constructor_NegativeSides))] double c)
        {
            Triangle triangle = null;

            void Constructor()
            {
                triangle = new Triangle(a, b, c);
            }

            Assert.IsNull(triangle);

            Assert.Throws<ArgumentException>(Constructor);
        }

        public static IEnumerable<double> Constructor_NegativeSides
        {
            get
            {
                double a = -3.2;
                double b = -4.1;
                double c = -5.3;

                yield return a;
                yield return b;
                yield return c;
            }
        }

        [Test]
        public void TestConstructor_NotCorrectSides_Exception()
        {
            double a = 3;
            double b = 2.5;
            double c = 10;
            Triangle triangle = null;

            void Constructor()
            {
                triangle = new Triangle(a, b, c);
            }

            Assert.IsNull(triangle);

            Assert.Throws<ArgumentException>(Constructor);
        }

        [Test]
        public void TestIsRight_RightTriangleSides_True()
        {
            Triangle triangle = new Triangle(3, 4, 5);
            bool expected = true;

            bool actual = triangle.IsRight();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestIsRight_NotRightTriangleSides_False()
        {
            Triangle triangle = new Triangle(2, 4, 5);
            bool expected = false;

            bool actual = triangle.IsRight();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCaseSource(nameof(GetAreasCases))]
        public double TestCalculateArea_Calculated(Triangle triangle)
        {
            return triangle.CalculateArea();
        }

        private static IEnumerable GetAreasCases
        {
            get
            {
                yield return new TestCaseData(new Triangle(3, 4, 5)).Returns(6);
                yield return new TestCaseData(new Triangle(1, 5, 5)).Returns(Math.Sqrt(6.1875));
                yield return new TestCaseData(new Triangle(3, 3, 3)).Returns(Math.Sqrt(15.1875));
                yield return new TestCaseData(new Triangle(1, 4, 3)).Returns(Math.Sqrt(0));

            }
        }
    }
}