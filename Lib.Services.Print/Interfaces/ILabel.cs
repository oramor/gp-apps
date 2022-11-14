namespace Lib.Services.Print
{
    public interface ILabel
    {
        public string Title { get; }
        public SupportedLabelEnum LabelEnum { get; init; }
        public SupportedLabelSizeEnum LabelSizeEnum { get; init; }
        public SupportedDriverAdapterEnum DriverAdapterEnum { get; init; }
        public string LabelName { get; }
        public string LabelSizeName { get; }
        public string DriverAdapterName { get; }
    }
}
