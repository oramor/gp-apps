using Lib.Services.Print.Labels;
using Lib.Wpf.Core;
using Lib.Services.Print;
using System.Windows;

namespace Gui.BuyerDesktop.Commands
{
    internal class PrintTestLabelCommand : BaseCommand
    {
        private readonly ITestLabelData _context;

        public PrintTestLabelCommand(ITestLabelData ctx)
        {
            _context = ctx;
        }

        public override void Execute(object? parameter)
        {
            var printer = App.Host.Services.GetService(typeof(IPrintService));
        }
    }
}
