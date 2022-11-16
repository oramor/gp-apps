namespace Lib.Services.Print
{
    public interface ILabel
    {
        public string Title { get; }
        public SupportedLabelEnum LabelId { get; init; }
        public ILabelSize LabelSize { get; init; }
        public IDriverAdapter DriverAdapter { get; init; }
    }
}
