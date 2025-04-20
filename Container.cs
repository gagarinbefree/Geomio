using Autofac;
using Geomio.Calculator;
using Geomio.Print;
using Geomio.Shapes;

namespace Geomio
{
    public static class Container
    {
        public static ICalc Calc;

        static Container()
        {
            var builder = new ContainerBuilder();

            builder.RegisterInstance<IShape>(new Circle(100));
            builder.RegisterInstance<IShape>(new Square(100, 100));
            builder.RegisterInstance<IShape>(new Triangle(100, 100, 100));
            builder.RegisterInstance<IShape>(new Polygon(new List<(double X, double Y)> { (0, 0), (0, 100), (100, 0) }));

            builder.RegisterType<Printer>().As<IPrinter>();
            builder.RegisterType<Calc>().As<ICalc>();

            IContainer container = builder.Build();

            Calc = container.Resolve<ICalc>();
        }
    }
}
