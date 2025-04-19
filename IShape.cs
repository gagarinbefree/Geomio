using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geomio
{
    public interface IShape
    {
        abstract double CalcArea();
        abstract double CalcPerimeter();
    }
}
