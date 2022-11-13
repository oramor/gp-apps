using Lib.Services.Print.Adapters;
using Lib.Services.Print.Base;

namespace Lib.Services.Print.Labels
{
    /// <summary>
    /// Этот интерфейс должен быть реализован вьюмоделью, которая желает
    /// передавать команду печати данного вида этикетки
    /// </summary>
    public interface ITestLabelData
    {
        public string Text { get; set; }
        public int Barcode { get; set; }
    }

    public interface ITestLabelTask : IBaseLabelTask, ITestLabelData
    {
    }

    class TestLabel_W43xH25_TscLib : BaseLabel
    {
        public override SupportedLabelEnum LabelEnum => SupportedLabelEnum.TestLabel;
        public override SupportedLabelSizeEnum LabelSizeEnum => SupportedLabelSizeEnum.W43xH25;
        public override SupportedDriverAdapterEnum DriverAdapterEnum => SupportedDriverAdapterEnum.TscLib;

        public static void PrintLabel(ITestLabelTask labelTask)
        {
            TscLibAdapter.Init(labelTask.LabelSetup.PrinterName);
            TscLibAdapter.SetLabelSize(labelTask.LabelSetup.LabelSizeEnum);
            TscLibAdapter.TextLine(25, 25, labelTask.Text);
            TscLibAdapter.Code128(25, 85, 72, labelTask.Barcode.ToString());
            TscLibAdapter.Print(labelTask.Copy);
        }
    }
}
