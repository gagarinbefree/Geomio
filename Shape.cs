using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geomio
{
    public abstract class Shape : IShape
    {
        public abstract double CalcArea();
        public abstract double CalcPerimeter();
    }
}
