using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Geomio.Print;
using Geomio.Shapes;

namespace Geomio.Calculator
{
    public class Calc : ICalc
    {
        private readonly IEnumerable<IShape> _shapes;
        private readonly IPrinter _printer;

        public Calc(IEnumerable<IShape> shapes, IPrinter printer)
        {
            _shapes = shapes;
            _printer = printer;
        }

        public void Print()
        {
            foreach (IShape shape in _shapes)
            {
                _printer.Print(shape);
            }
        }

        public void Print<T>() where T : IShape
        {
            foreach (IShape shape in _shapes.OfType<T>())
            {
                _printer.Print(shape);
            }
        }

        public double Area() => _shapes.Sum((s) => s.CalcArea());

        public double Area<T>() where T : IShape => _shapes.OfType<T>().Sum((s) => s.CalcArea());

        public double Perimeter() => _shapes.Sum((s) => s.CalcPerimeter());

        public double Perimeter<T>() where T : IShape => _shapes.OfType<T>().Sum((s) => s.CalcPerimeter());
    }
}
