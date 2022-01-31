using System;

namespace Figures
{
    public class Circle : IFigure
    {
        private readonly double radius;

        public Circle(double radius)
        {
            if (radius <= 0)
                throw new ArgumentException();

            this.radius = radius;
        }

        public double CalculateArea()
        {
            return Math.PI * Math.Pow(radius, 2);
        }
    }
}
