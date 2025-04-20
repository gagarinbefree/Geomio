using System.Text;
using Autofac;
using Geomio.Calculator;
using Geomio.Shapes;

namespace Geomio
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Container.Calc.Print();
            Container.Calc.Print<Circle>();
        }
    }                   
}