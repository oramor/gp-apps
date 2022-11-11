namespace Lib.Services.Print
{
    public interface ILabelSetup
    {
        public string Name { get; set; }
        public string PrinterName { get; set; }
        public string DriverName { get; set; }
        public SupportedPrinterAdapterEnum DriverAdapter { get; set; }
        public SupportedLabelSizeEnum LabelSize { get; set; }
    }
}
