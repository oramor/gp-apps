namespace Lib.Services.Print
{
    public abstract class BaseLabel : ILabel
    {
        public required ICommonLabel CommonLabel { get; init; }
        public required ILabelSize LabelSize { get; init; }
        public required IDriverAdapter DriverAdapter { get; init; }

        public string Title
        {
            get {
                var labelName = CommonLabel.Title;
                var driver = " (драйвер " + DriverAdapter.Title + ")";
                return labelName + ", " + LabelSize.Title + driver;
            }
        }
    }
}
