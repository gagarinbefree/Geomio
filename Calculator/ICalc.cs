using Geomio.Shapes;

namespace Geomio.Calculator
{
    public interface ICalc
    {
        double Area();
        double Area<T>() where T : IShape;
        double Perimeter();
        double Perimeter<T>() where T : IShape;
        void Print();
        void Print<T>() where T : IShape;
    }
}