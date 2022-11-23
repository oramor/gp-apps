using Lib.Services.Print.Labels;

namespace Lib.Services.Print
{
    public class PrintService : IPrintService
    {
        private readonly List<ISupportedLabel> _supportedLabels = new();

        public PrintService()
        {
            // Fill labels
            _supportedLabels.Add(TestLabelFabric.W43xH25_TscLib);
        }

        public IList<ISupportedLabel> SupportedLabels => _supportedLabels;

        public void PrintLabel(IProductLabelTask labelTask)
        {
            CallDriver(labelTask);
        }

        public void PrintLabel(ITestLabelTask labelTask)
        {
            CallDriver(labelTask);
        }

        private void CallDriver(IBaseLabelTask task)
        {
            ISupportedLabel? item = (from label in _supportedLabels
                                     where label.CommonLabel == task.LabelSetup.SupportedLabel.CommonLabel &&
                                            label.LabelSize == task.LabelSetup.SupportedLabel.LabelSize &&
                                            label.DriverAdapter == task.LabelSetup.SupportedLabel.DriverAdapter
                                     select label).FirstOrDefault();

            if (item == null) throw new ApplicationException("Not found supported label for this setup");

            var m = item.GetType().GetMethod("ExecutePrint");

            if (m == null) throw new ApplicationException("Not found PrintLabel");

            var paramsArr = new object[] { task };

            m.Invoke(item, paramsArr);
        }
    }
}