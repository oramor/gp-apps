using Gui.BuyerDesktop.Commands;
using Lib.Services.Print.Labels;
using Lib.Wpf.Core;
using Lib.Services.Print;
using System;
using System.Windows.Input;
using System.Collections.Generic;
using System.Printing;
using System.Linq;
using System.Collections.ObjectModel;

namespace Gui.BuyerDesktop.Contexts
{
    internal class MainWindowContext : BaseContext, ICanPrintLabels
    {
        private readonly ICollection<ILabelSetup> _labelSetups = new Collection<ILabelSetup>();

        //private IObservable
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

        public void ShowLabelSetupForm(ILabelSetupForm? labelSetup)
        {
            // Create LabelSetupFormContext
            // Create LabelSetupFormWindow
            // Set context to form
            // Show window
            throw new NotImplementedException();
        }

        internal class LabelSetupFormContext : ILabelSetupForm
        {
            public IReadOnlyCollection<IPrinter> SystemPrinters { get; set; }

            public string[] GetSupportedDrivers()
            {
                throw new NotImplementedException();
            }

            public string[] GetSupportedLabels()
            {
                throw new NotImplementedException();
            }

            public string[] GetSupportedSizes(SupportedLabelEnum label, SupportedDriverAdapterEnum driver)
            {
                throw new NotImplementedException();
            }
        }
    }
}
