using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Services.Print
{
    public class LabelSetup : ILabelSetup
    {
        public required ISupportedLabel SupportedLabel { get; init; }
        public required string PrinterName { get; init; }
        public required string DriverName { get; init; }
        public string PortName { get; init; } = string.Empty;
    }
}
