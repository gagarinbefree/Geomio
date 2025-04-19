using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geomio.Shapes
{
    public class Square : Shape
    {
        private readonly double _side1;
        private readonly double _side2;

        public Square(double side1, double side2)
        {
            _side1 = side1;
            _side2 = side2;
        }

        public override double CalcArea() => _side1 * _side2;

        public override double CalcPerimeter() => 2 * (_side1 + _side2);
    }
}
