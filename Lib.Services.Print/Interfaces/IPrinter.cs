using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Services.Print
{
    public interface IPrinter
    {
        public string Name { get; init; }
        public string DriverName { get; init; }
        public string PortName { get; init; }
        public int Priority { get; init; }
    }
}
