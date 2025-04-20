using Geomio.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geomio.Print
{
    public class Printer : IPrinter
    {
        public void Print(IShape shape)
        {
            Console.WriteLine($"Shape:{shape.GetType().Name} Area:{shape.CalcArea()} Perimeter:{shape.CalcPerimeter()}");
        }
    }
}
