using Lib.Services.Print;
using Lib.Wpf.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Printing;

namespace Gui.BuyerDesktop.Contexts
{
    internal class MainWindowContext : BaseContext
    {

        public void ShowLabelSetupForm(ILabelSetupForm? labelSetup)
        {
            // Create LabelSetupFormContext
            // Create LabelSetupFormWindow
            // Set context to form
            // Show window
            throw new NotImplementedException();
        }

        //internal class LabelSetupFormContext : ILabelSetupForm
        //{
        //    public IReadOnlyCollection<IPrinter> SystemPrinters { get; set; }

        //}
    }
}
