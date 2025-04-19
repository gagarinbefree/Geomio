using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geomio
{
    public class Calc
    {
        private readonly IEnumerable<IShape> _shapes;

        public Calc(IEnumerable<IShape> shapes)
        {
            _shapes = shapes;
        }

        public void Print()
        {
            foreach (IShape shape in _shapes)
            {
                print(shape);
            }
        }

        public void Print<T>() where T : IShape
        {
            foreach (IShape shape in _shapes.OfType<T>())
            {
                print(shape);
            }
        }

        public double Area() => _shapes.Sum((s) => s.CalcArea());

        public double Area<T>() where T : IShape => _shapes.OfType<T>().Sum((s) => s.CalcArea());

        public double Perimeter() => _shapes.Sum((s) => s.CalcPerimeter());

        public double Perimeter<T>() where T : IShape => _shapes.OfType<T>().Sum((s) => s.CalcPerimeter());

        private void print(IShape shape) => Console.WriteLine($"Shape:{shape.GetType().Name} Area:{shape.CalcArea()} Perimeter:{shape.CalcPerimeter()}");
    }
}
