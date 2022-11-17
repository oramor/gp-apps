using Lib.Services.Print.Adapters;

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

    public class TestLabelTask : BaseLabelTask, ITestLabelTask
    {
        public string Text { get; set; } = string.Empty;
        public int Barcode { get; set; }
    }

    class TestLabel_W43xH25_TscLib : BaseLabel, ISupportedLabel
    {
        public TestLabel_W43xH25_TscLib()
        {
            CommonLabel = CommonLabelFactory.TestLabel;
            LabelSize = LabelSizeFactory.W43xH25;
            DriverAdapter = DriverAdapterFactory.TscLib;
        }

        public static void ExecutePrint(TestLabelTask labelTask)
        {
            TscLibAdapter.Init(labelTask.LabelSetup.PrinterName);
            TscLibAdapter.SetLabelSize(labelTask.LabelSetup.SupportedLabel.LabelSize);
            TscLibAdapter.TextLine(25, 15, labelTask.Text);
            TscLibAdapter.Code128(25, 65, 72, labelTask.Barcode.ToString());
            TscLibAdapter.Print(labelTask.Copy);
        }
    }

    //public static class TestLabelFabric
    //{
    //    public static ISupportedLabel W43xH25_TscLib
    //    {
    //        get {
    //            var executor = (TestLabelTask labelTask) => {
    //                TscLibAdapter.Init(labelTask.LabelSetup.PrinterName);
    //                TscLibAdapter.SetLabelSize(labelTask.LabelSetup.SupportedLabel.LabelSize);
    //                TscLibAdapter.TextLine(25, 15, labelTask.Text);
    //                TscLibAdapter.Code128(25, 65, 72, labelTask.Barcode.ToString());
    //                TscLibAdapter.Print(labelTask.Copy);
    //            };

    //            var cls = new SupportedLabel() {
    //                CommonLabel = CommonLabelFactory.TestLabel,
    //                LabelSize = LabelSizeFactory.W43xH25,
    //                DriverAdapter = DriverAdapterFactory.TscLib,
    //                ExecutePrint = executor
    //            };

    //            return cls;
    //        }
    //    }
    //}
}
