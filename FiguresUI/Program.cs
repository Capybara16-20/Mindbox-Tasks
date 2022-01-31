using System;
using System.Collections.Generic;
using Figures;

namespace FiguresUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Circle circle = new Circle(3);

            Triangle triangle = new Triangle(0.001, 0.001, 1.0);

            List<IFigure> figures = new List<IFigure>();
            figures.Add(circle);
            figures.Add(triangle);

            foreach(IFigure figure in figures)
            {
                Console.WriteLine(figure.CalculateArea());
            }
        }
    }
}
