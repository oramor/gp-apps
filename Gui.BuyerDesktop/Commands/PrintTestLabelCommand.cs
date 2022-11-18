using Lib.Services.Print;
using Lib.Services.Print.Labels;
using Lib.Wpf.Core;

namespace Gui.BuyerDesktop.Commands
{
    internal class PrintTestLabelCommand : BaseCommand
    {
        private readonly ITestLabelPrintContext _context;

        public PrintTestLabelCommand(ITestLabelPrintContext ctx)
        {
            _context = ctx;
        }

        public override void Execute(object? parameter)
        {
            var printer = App.Host.Services.GetService(typeof(IPrintService)) as IPrintService;

            ISupportedLabel label = printer?.SupportedLabels[0];

            var labelSetup = new LabelSetup() {
                SupportedLabel = label,
                PrinterName = "TSC TTP-225",
                DriverName = "TSC TTP-225",
                PortName = ""
            };

            var labelTask = new TestLabelTask() {
                LabelSetup = labelSetup,
                Text = _context.Text,
                Barcode = _context.Barcode,
            };


            printer?.PrintLabel(labelTask);
        }
    }
}
