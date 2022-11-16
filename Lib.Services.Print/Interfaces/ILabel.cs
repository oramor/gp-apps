namespace Lib.Services.Print
{
    public interface ILabel
    {
        public string Title { get; }
        public ICommonLabel CommonLabel { get; init; }
        public ILabelSize LabelSize { get; init; }
        public IDriverAdapter DriverAdapter { get; init; }
    }
}
