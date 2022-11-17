namespace Lib.Services.Print
{
    public class SupportedLabel : ISupportedLabel
    {
        public required ICommonLabel CommonLabel { get; init; }
        public required ILabelSize LabelSize { get; init; }
        public required IDriverAdapter DriverAdapter { get; init; }

        //private Action<object> ExecutePrintDelegate;

        //delegate void ExecutePrintDelegate(TestLabelTask labelTask);

        public string Title
        {
            get {
                var labelName = CommonLabel.Title;
                var driver = " (драйвер " + DriverAdapter.Title + ")";
                return labelName + ", " + LabelSize.Title + driver;
            }
        }

        //public void ExecutePrint { get; set => ExecutePrintDelegate = value; }
    }
}
