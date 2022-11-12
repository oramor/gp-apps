using Lib.Services.Print.Adapters;

namespace Lib.Services.Print.Labels
{
    public interface IProductLabelData
    {
        public int ProductId { get; set; }
        public int Sku { get; set; }
    }

    class ProductLabel_W43xH25_TscLib : ILabel
    {
        private static readonly SupportedLabelSizeEnum _size = SupportedLabelSizeEnum.W43xH25;

        public string Name => "Этикетка товара, 43x25 мм (драйвер TscLib)";
        public string Description => "Описание";
        public SupportedLabelSizeEnum Size => _size;
        public SupportedPrinterAdapterEnum DriverAdapter => SupportedPrinterAdapterEnum.TscLib;

        public static void PrintLabel(IProductLabelTask labelTask)
        {
            TscLibAdapter.Init(labelTask.LabelSetup.PrinterName);
            TscLibAdapter.SetLabelSize(_size);
            TscLibAdapter.TextLine(25, 25, labelTask.ProductId.ToString());
            TscLibAdapter.Code128(25, 85, 72, labelTask.ProductId.ToString());
            TscLibAdapter.Print(labelTask.Copy);
        }
    }

    public static class ProductLabel
    {
        public static void TscLib_W43xH25(string printerName, int productId, int sku, int? copy)
        {
            TscLibAdapter.Init(printerName);
            TscLibAdapter.SetLabelSize(SupportedLabelSizeEnum.W43xH25);
            TscLibAdapter.TextLine(25, 25, productId.ToString());
            TscLibAdapter.Code128(25, 85, 72, sku.ToString());
            TscLibAdapter.Print(copy);
        }
    }
}
