namespace Lib.Services.Print
{
    public abstract class BaseLabel : ILabel
    {
        public required SupportedLabelEnum SupportedLabelKey { get; init; }
        public required ILabelSize LabelSize { get; init; }
        public required IDriverAdapter DriverAdapter { get; init; }

        public string Title
        {
            get {
                var labelName = GetLabelName();
                var driver = " (драйвер " + DriverAdapter.Title + ")";
                return labelName + ", " + LabelSize.Title + driver;
            }
        }

        private string GetLabelName()
        {
            if (LabelId == SupportedLabelEnum.TestLabel) return "Тестовая этикетка";
            if (LabelId == SupportedLabelEnum.ProductLabel) return "Этикетка товара";
            if (LabelId == SupportedLabelEnum.ProductBatchLabel) return "Этикетка партии товара";
            return "<Unsupported label>";
        }
    }
}
