using Lib.Services.Print.Labels;
using Lib.Wpf.Core;
//using Microsoft.Extensions.DependencyInjection;

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
            // Если хранить LabelSetups на стороне приложения, то будет непросто получать к ним доступ
            // Лучше поместить в сервис.

            //var printer = App.Host.Services.GetService<IPrintService>();

            //ISupportedLabel label = printer?.SupportedLabels[0];

            //var labelSetup = new LabelSetup() {
            //    SupportedLabel = label,
            //    PrinterName = "TSC TTP-225",
            //    DriverName = "TSC TTP-225",
            //    PortName = ""
            //};

            //var labelTask = new TestLabelTask() {
            //    LabelSetup = labelSetup,
            //    Text = _context.Text,
            //    Barcode = _context.Barcode,
            //};


            //printer?.PrintLabel(labelTask);
        }
    }
}
