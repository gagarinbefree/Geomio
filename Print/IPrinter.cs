using Geomio.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geomio.Print
{
    public interface IPrinter
    {
        void Print(IShape shape);
    }
}
