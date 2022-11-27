using Lib.Services.Print.Adapters;

namespace Lib.Services.Print.Labels
{
    /// <summary>
    /// Должен поддерживаться вьюмоделью, которая отправляет команду
    /// на печать этикетки данного вида
    /// </summary>
    public interface IProductLabelData
    {
        public int ProductId { get; set; }
        public int Sku { get; set; }
    }

    public interface IProductLabelTask : IBaseLabelTask, IProductLabelData
    {
    }

    public static class ProductLabelFabric
    {
        public static ISupportedLabel W43xH25_TscLib
        {
            get {
                // Стратегия сводится к одному методу и может быть упакована в делегат
                var executor = (IProductLabelTask labelTask) => {
                    TscLibAdapter.Init(labelTask.LabelSetup.SystemPrinter.DriverName);
                    TscLibAdapter.SetLabelSize(labelTask.LabelSetup.SupportedLabel.LabelSize);
                    TscLibAdapter.TextLine(25, 15, labelTask.ProductId.ToString());
                    TscLibAdapter.Code128(25, 65, 72, labelTask.Sku.ToString());
                    TscLibAdapter.Print(labelTask.Copy);
                };

                var label = new SupportedLabel(executor) {
                    CommonLabel = CommonLabelFactory.ProductLabel,
                    LabelSize = LabelSizeFactory.W43xH25,
                    DriverAdapter = DriverAdapterFactory.TscLib,
                };

                return label;
            }
        }
    }
}
