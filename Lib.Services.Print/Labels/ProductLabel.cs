using Lib.Services.Print.Adapters;

namespace Lib.Services.Print.Labels
{
    public interface IProductLabelData
    {
        public int ProductId { get; set; }
        public int Sku { get; set; }
    }

    class ProductLabel_TscLib_W43_H25 : ILabel, ICanPrint<IProductLabelTask>
    {
        private static readonly SupportedLabelSizeEnum _size = SupportedLabelSizeEnum.W43_H25;
        public string Name => "Этикетка";
        public string Description => "Описание";
        public SupportedLabelSizeEnum Size => _size;
        public SupportedPrinterAdapterEnum DriverAdapter => SupportedPrinterAdapterEnum.TscLib;

        public static class Printer
        {
            public static void PrintLabel(IProductLabelTask labelTask)
            {
                TscLibAdapter.Init(labelTask.LabelSetup.PrinterName);
                TscLibAdapter.SetLabelSize(_size);
                TscLibAdapter.TextLine(25, 25, labelTask.ProductId.ToString());
                TscLibAdapter.Code128(25, 85, 72, labelTask.ProductId.ToString());
                TscLibAdapter.Print(labelTask.Copy);
            }
        }

        public void PrintLabel(IProductLabelTask labelTask)
        {
            TscLibAdapter.Init(labelTask.LabelSetup.PrinterName);
            TscLibAdapter.SetLabelSize(Size);
            TscLibAdapter.TextLine(25, 25, labelTask.ProductId.ToString());
            TscLibAdapter.Code128(25, 85, 72, labelTask.ProductId.ToString());
            TscLibAdapter.Print(labelTask.Copy);
        }
    }

    public static class ProductLabel
    {
        public static void TscLib_W43_H25(string printerName, int productId, int sku, int? copy)
        {
            TscLibAdapter.Init(printerName);
            TscLibAdapter.SetLabelSize(SupportedLabelSizeEnum.W43_H25);
            TscLibAdapter.TextLine(25, 25, productId.ToString());
            TscLibAdapter.Code128(25, 85, 72, sku.ToString());
            TscLibAdapter.Print(copy);
        }

        public static IEnumerable<ILabel> GetLabels()
        {
            var labels = new List<ILabel>();

        }
    }
}
