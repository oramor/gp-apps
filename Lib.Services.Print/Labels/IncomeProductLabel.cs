using Lib.Services.Print.Adapters;

namespace Lib.Services.Print.Labels
{
    public static class IncomeProductLabel
    {
        public static void TscLib_W43_H25(string printerName, int productId, int sku, int? copy)
        {
            TscLibAdapter.Init(printerName);
            TscLibAdapter.SetLabelSize(SupportedLabelSizeEnum.W43_H25);
            TscLibAdapter.TextLine(25, 25, productId.ToString());
            TscLibAdapter.Code128(25, 85, 72, sku.ToString());
            TscLibAdapter.Print(copy);
        }
    }
}
