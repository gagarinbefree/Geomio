using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geomio.Shapes
{
    public class Polygon : Shape
    {
        private readonly List<(double X, double Y)> _vertices;

        public Polygon(List<(double X, double Y)> vertices)
        {
            _vertices = vertices;

            if (vertices.Count < 3)
                throw new ArgumentException("Polygon must have at least 3 vertices");
        }

        public override double CalcArea()
        {
            // Формула площади Гаусса
            double area = 0;
            int n = _vertices.Count;

            for (int i = 0; i < n; i++)
            {
                var current = _vertices[i];
                var next = _vertices[(i + 1) % n];
                area += current.X * next.Y - next.X * current.Y;
            }

            return Math.Abs(area / 2);
        }

        public override double CalcPerimeter()
        {
            double perimeter = 0;
            int n = _vertices.Count;

            for (int i = 0; i < n; i++)
            {
                var current = _vertices[i];
                var next = _vertices[(i + 1) % n];
                perimeter += Math.Sqrt(Math.Pow(next.X - current.X, 2) + Math.Pow(next.Y - current.Y, 2));
            }

            return perimeter;
        }
    }
}
