using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using Figures;

namespace FiguresTests
{
    class CircleTests
    {
        [Test]
        public void TestConstructor_NormalSides_Created
            ([ValueSource(nameof(Constructor_NormalRadius))] double r)
        {
            Circle circle = new Circle(r);

            Assert.IsNotNull(circle);
        }

        public static IEnumerable<double> Constructor_NormalRadius
        {
            get
            {
                double a = 0.001;
                double b = 1;
                double c = 3.4;
                double d = 9999;

                yield return a;
                yield return b;
                yield return c;
                yield return d;
            }
        }

        [Test]
        public void TestConstructor_NegativeSides_Exception
            ([ValueSource(nameof(Constructor_NegativeRadius))] double r)
        {
            Circle circle = null;

            void Constructor()
            {
                circle = new Circle(r);
            }

            Assert.IsNull(circle);

            Assert.Throws<ArgumentException>(Constructor);
        }

        public static IEnumerable<double> Constructor_NegativeRadius
        {
            get
            {
                double a = -0.001;
                double b = 0;
                double c = -1;
                double d = -3.4;
                double e = -9999;

                yield return a;
                yield return b;
                yield return c;
                yield return d;
                yield return e;
            }
        }

        [Test]
        [TestCaseSource(nameof(GetAreasCases))]
        public double TestCalculateArea_Calculated(Circle circle)
        {
            return circle.CalculateArea();
        }

        private static IEnumerable GetAreasCases
        {
            get
            {
                yield return new TestCaseData(new Circle(1)).Returns(Math.PI);
                yield return new TestCaseData(new Circle(3)).Returns(Math.PI * 9);
                yield return new TestCaseData(new Circle(0.01)).Returns(Math.PI * 0.0001);
                yield return new TestCaseData(new Circle(15.5)).Returns(Math.PI * 240.25);
            }
        }
    }
}
