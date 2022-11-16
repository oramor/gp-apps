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

    //class ProductLabel_W43xH25_TscLib : BaseLabel
    //{
    //    public override CommonLabelEnum LabelEnum => CommonLabelEnum.ProductLabel;
    //    public override LabelSizeEnum LabelSizeEnum => LabelSizeEnum.W43xH25;
    //    public override DriverAdapterEnum DriverAdapterEnum => DriverAdapterEnum.TscLib;

    //    public static void ExecutePrint(IProductLabelTask labelTask)
    //    {
    //        TscLibAdapter.Init(labelTask.LabelSetup.PrinterName);
    //        TscLibAdapter.SetLabelSize(labelTask.LabelSetup.LabelSizeEnum);
    //        TscLibAdapter.TextLine(25, 25, labelTask.ProductId.ToString());
    //        TscLibAdapter.Code128(25, 85, 72, labelTask.ProductId.ToString());
    //        TscLibAdapter.Print(labelTask.Copy);
    //    }
    //}
}
