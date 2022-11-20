namespace Lib.Services.Print
{
    public abstract class BaseLabel : ILabel
    {
        public ICommonLabel CommonLabel { get; init; }
        public ILabelSize LabelSize { get; init; }
        public IDriverAdapter DriverAdapter { get; init; }

        public string Title => string.Format("{0}, {1} (драйвер {2})", CommonLabel.Title, LabelSize.Title, DriverAdapter.Title);
    }
}
