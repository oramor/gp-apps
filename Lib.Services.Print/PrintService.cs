using Lib.Services.Print.Labels;
using System.Collections.ObjectModel;

namespace Lib.Services.Print
{
    public class PrintService : IPrintService
    {
        private readonly ICollection<ILabel> _labels = new List<ILabel>();
        private readonly IReadOnlyCollection<ILabel> _supportedLabels;

        public PrintService()
        {
            _labels.Add(new TestLabel_W43xH25_TscLib());
            _labels.Add(new ProductLabel_W43xH25_TscLib());

            _supportedLabels = new ReadOnlyCollection<ILabel>((IList<ILabel>)_labels);
        }

        public IReadOnlyCollection<ILabel> SupportedLabels => _supportedLabels;

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
            var item = (from label in _labels
                        where label.LabelEnum == task.LabelSetup.LabelEnum &&
                               label.LabelSizeEnum == task.LabelSetup.LabelSizeEnum &&
                               label.DriverAdapterEnum == task.LabelSetup.DriverAdapterEnum
                        select label).FirstOrDefault();

            if (item == null) throw new ApplicationException("Not found label for this setup");

            var m = item.GetType().GetMethod("ExecutePrint");

            if (m == null) throw new ApplicationException("Not found PrintLabel");

            var paramsArr = new object[] { task };

            m.Invoke(item, paramsArr);
        }
    }
}