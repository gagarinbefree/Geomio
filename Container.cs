using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geomio
{
    public static class Container
    {
        public static Calc Calculator;

        static Container()
        {
            var builder = new ContainerBuilder();
            
            builder.RegisterInstance(new Circle(100)).As<IShape>();
            builder.RegisterInstance(new Square(100, 100)).As<IShape>();
            builder.RegisterInstance(new Triangle(100, 100, 100)).As<IShape>();
            builder.RegisterInstance(new Polygon(new List<(double X, double Y)> { (0, 0), (0, 100), (100, 0) })).As<IShape>();

            builder.RegisterType<Calc>();

            IContainer container = builder.Build();

            Calculator = container.Resolve<Calc>();
        }
    }
}
