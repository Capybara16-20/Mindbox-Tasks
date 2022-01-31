using System;

namespace Figures
{
    public class Triangle : IFigure
    {
        private readonly double a;
        private readonly double b;
        private readonly double c;

        private double Perimetr { get { return a + b + c; } }

        public Triangle(double a, double b, double c)
        {
            if (!CheckSides(a, b, c))
                throw new ArgumentException();

            this.a = a;
            this.b = b;
            this.c = c;
        }

        private static bool CheckSides(double a, double b, double c)
        {
            if ((a <= 0) || (b <= 0) || (c <= 0))
                return false;
            if ((a > b + c) || (b > a + c) || (c > a + b))
                return false;
            
            return true;
        }

        public bool IsRight()
        {
            double sqrA = Math.Pow(a, 2);
            double sqrB = Math.Pow(b, 2);
            double sqrC = Math.Pow(c, 2);

            if ((sqrA == sqrB + sqrC) || (sqrB == sqrA + sqrC)
                || (sqrC == sqrA + sqrB))
                return true;

            return false;
        }

        public double CalculateArea()
        {
            double p = Perimetr / 2;

            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }
    }
}
