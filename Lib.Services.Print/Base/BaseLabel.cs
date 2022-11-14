namespace Lib.Services.Print
{
    public abstract class BaseLabel : ILabel
    {
        public SupportedLabelEnum LabelEnum { get; init; }
        public SupportedLabelSizeEnum LabelSizeEnum { get; init; }
        public SupportedDriverAdapterEnum DriverAdapterEnum { get; init; }

        public string Title => LabelName + ", " + LabelSizeName + " (драйвер " + DriverAdapterName + ")";

        public string LabelName
        {
            get {
                if (LabelEnum == SupportedLabelEnum.TestLabel) return "Тестовая этикетка";
                if (LabelEnum == SupportedLabelEnum.ProductLabel) return "Этикетка товара";
                if (LabelEnum == SupportedLabelEnum.ProductBatchLabel) return "Этикетка партии товара";
                return string.Empty;
            }
        }

        public string LabelSizeName
        {
            get {
                if (LabelSizeEnum == SupportedLabelSizeEnum.W43xH25) return "43x25 mm";
                return string.Empty;
            }
        }

        public string DriverAdapterName
        {
            get {
                if (DriverAdapterEnum == SupportedDriverAdapterEnum.TscLib) return "TSCLib";
                return string.Empty;
            }
        }
    }
}
