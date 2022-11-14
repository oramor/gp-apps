using Lib.Services.Print;
using Lib.Services.Print.Labels;
using Lib.Wpf.Core;

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
            var labelSetup = new LabelSetup() {
                LabelEnum = SupportedLabelEnum.TestLabel,
                LabelSizeEnum = SupportedLabelSizeEnum.W43xH25,
                DriverAdapterEnum = SupportedDriverAdapterEnum.TscLib,
                PrinterName = "TSC TTP-225",
                DriverName = "TSC TTP-225",
                PortName = ""
            };

            var labelTask = new TestLabelTask() {
                LabelSetup = labelSetup,
                Text = _context.Text,
                Barcode = _context.Barcode,
            };

            var printer = App.Host.Services.GetService(typeof(IPrintService)) as IPrintService;
            printer?.PrintLabel(labelTask);
        }
    }
}
