using Lib.Services.Print.Adapters;

namespace Lib.Services.Print.Labels
{
    public static class IncomeProductLabel
    {
        public static void PrintWithTscLib(string printerName, int productId, int sku, int? copy)
        {
            TscLibAdapter.Init(printerName);
            TscLibAdapter.SetLabelSize(LabelSizeEnum.size43x25mm);
            TscLibAdapter.TextLine(25, 25, productId.ToString());
            TscLibAdapter.Code128(25, 85, 72, sku.ToString());
            TscLibAdapter.Print(copy);
        }
    }
}
