using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geomio.Shapes
{
    public class Circle : Shape
    {
        private readonly double _radius;

        public Circle(double radius)
        {
            _radius = radius;
        }

        public override double CalcArea() => Math.PI * _radius * _radius;

        public override double CalcPerimeter() => 2 * Math.PI * _radius;
    }
}
