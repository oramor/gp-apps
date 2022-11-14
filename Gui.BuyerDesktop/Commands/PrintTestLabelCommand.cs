using Lib.Services.Print.Labels;
using Lib.Wpf.Core;
using Lib.Services.Print;
using System.Windows;

namespace Gui.BuyerDesktop.Commands
{
    internal class LabelSetup : ILabelSetup
    {
        private readonly string _printerName = string.Empty;
        private readonly string _driverName = string.Empty;
        private readonly string _portName = string.Empty;

        public string PrinterName { get => _printerName; init => _printerName = value; }
        public string DriverName { get => _driverName; init => _driverName = value; }
        public string PortName { get => _portName; init => _portName = value; }

        public string Title => throw new System.NotImplementedException();

        public SupportedLabelEnum LabelEnum => throw new System.NotImplementedException();

        public SupportedLabelSizeEnum LabelSizeEnum => throw new System.NotImplementedException();

        public SupportedDriverAdapterEnum DriverAdapterEnum => throw new System.NotImplementedException();

        public string LabelName => throw new System.NotImplementedException();

        public string LabelSizeName => throw new System.NotImplementedException();

        public string DriverAdapterName => throw new System.NotImplementedException();
    }

    internal class TestLabelTask : ITestLabelTask
    {
        public ILabelSetup LabelSetup { get => throw new System.NotImplementedException(); init => throw new System.NotImplementedException(); }
        public int Copy { get => throw new System.NotImplementedException(); init => throw new System.NotImplementedException(); }
        public string Text { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public int Barcode { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    }
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
