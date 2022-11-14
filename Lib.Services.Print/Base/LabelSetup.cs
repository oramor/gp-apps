using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Services.Print
{
    public class LabelSetup : BaseLabel, ILabelSetup
    {
        public string PrinterName { get; init; }
        public string DriverName { get; init; }
        public string PortName { get; init; }
    }
}
