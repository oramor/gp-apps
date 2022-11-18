using Lib.Services.Print;
using Lib.Wpf.Core;
using Lib.Core;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Printing;

namespace Gui.BuyerDesktop.Contexts
{
    public class LabelPrintContext : BaseContext, ILabelPrintContext
    {
        private readonly ICollection<ILabelSetup> _labelSetups = new Collection<ILabelSetup>();

        public IReadOnlyCollection<IPrinter> SystemPrinters
        {
            get {
                var printers = new LocalPrintServer().GetPrintQueues().Select(v => new SystemPrinter() {
                    Name = v.Name,
                    DriverName = v.QueueDriver.Name,
                    PortName = v.QueuePort.Name,
                    Priority = v.Priority
                }).ToList().AsReadOnly();

                return printers;
            }
        }

        public ICollection<ILabelSetup> LabelSetups => _labelSetups;
    }
}
