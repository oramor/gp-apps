using Lib.Services.Print.Adapters;

namespace Lib.Services.Print
{
    /// <summary>
    /// Этот интерфейс должен быть реализован вьюмоделью, которая желает
    /// передавать команду печати данного вида этикетки
    /// </summary>
    public interface ITestLabelPrintContext
    {
        public string Text { get; set; }
        public int Barcode { get; set; }
    }

    public interface ITestLabelTask : IBaseLabelTask, ITestLabelPrintContext
    {
    }

    public class TestLabelTask : BaseLabelTask, ITestLabelTask
    {
        public string Text { get; set; } = string.Empty;
        public int Barcode { get; set; }
    }

    public static class TestLabelFabric
    {
        public static ISupportedLabel W43xH25_TscLib
        {
            get {
                // Стратегия сводится к одному методу и может быть упакована в делегат
                var executor = (TestLabelTask labelTask) => {
                    TscLibAdapter.Init(labelTask.LabelSetup.SystemPrinter.DriverName);
                    TscLibAdapter.SetLabelSize(labelTask.LabelSetup.SupportedLabel.LabelSize);
                    TscLibAdapter.TextLine(25, 15, labelTask.Text);
                    TscLibAdapter.Code128(25, 65, 72, labelTask.Barcode.ToString());
                    TscLibAdapter.Print(labelTask.Copy);
                };

                var label = new SupportedLabel(executor) {
                    CommonLabel = CommonLabelFactory.TestLabel,
                    LabelSize = LabelSizeFactory.W43xH25,
                    DriverAdapter = DriverAdapterFactory.TscLib,
                };

                return label;
            }
        }
    }
}
