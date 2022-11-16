using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Services.Print
{
    public class LabelSetup : BaseLabel, ILabelSetup
    {
        public CommonLabelEnum CommonLabelKey { get; init; }
        public required string PrinterName { get; init; }
        public required string DriverName { get; init; }
        public string PortName { get; init; } = string.Empty;
    }
}
