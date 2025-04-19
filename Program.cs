using System.Text;
using Geomio.Shapes;

namespace Geomio
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var calc = Container.Calculator;
            calc.Print();
            calc.Print<Circle>();
        }
    }                   
}