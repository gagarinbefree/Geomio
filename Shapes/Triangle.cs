using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geomio.Shapes
{
    public class Triangle : Shape
    {
        private readonly double _sideA;
        private readonly double _sideB;
        private readonly double _sideC;

        public Triangle(double a, double b, double c)
        {
            _sideA = a;
            _sideB = b;
            _sideC = c;
        }

        public override double CalcArea()
        {
            // Формула Герона
            double p = CalcPerimeter() / 2;
            return Math.Sqrt(p * (p - _sideA) * (p - _sideB) * (p - _sideC));
        }

        public override double CalcPerimeter() => _sideA + _sideB + _sideC;
    }
}
