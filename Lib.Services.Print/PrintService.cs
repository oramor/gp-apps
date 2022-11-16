using Lib.Services.Print.Labels;

namespace Lib.Services.Print
{
    public class PrintService : IPrintService
    {
        private readonly IList<ILabel> _supportedLabels = new List<ILabel>();
        private readonly IList<IDriverAdapter> _supportedDriverAdapters = new List<IDriverAdapter>();
        private readonly IList<ILabelSize> _supportedLabelSizes = new List<ILabelSize>();

        public PrintService()
        {
            // Fill labels
            _supportedLabels.Add(new TestLabel_W43xH25_TscLib());

            // Fill drivers 
            _supportedDriverAdapters.Add(new DriverAdapter() { DriverAdapterId = SupportedDriverAdapterEnum.TscLib, DriverAdapterTitle = "TSC Driver" });

            // Fill sizes
            _supportedLabelSizes.Add(new LabelSize() { LabelSizeWidth = 43, LabelSizeHeight = 25, LabelSizeId = SupportedLabelSizeEnum.W43xH25 });
        }

        public IList<ILabel> SupportedLabels => _supportedLabels;
        public IList<ILabelSize> SupportedLabelSizes => _supportedLabelSizes;
        public IList<IDriverAdapter> SupportedDriverAdapters => _supportedDriverAdapters;

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
            ILabel? item = (from label in _supportedLabels
                            where label.LabelEnum == task.LabelSetup.LabelEnum &&
                                   label.LabelSizeEnum == task.LabelSetup.LabelSizeEnum &&
                                   label.DriverAdapterEnum == task.LabelSetup.DriverAdapterEnum
                            select label).FirstOrDefault();

            if (item == null) throw new ApplicationException("Not found supported label for this setup");

            var m = item.GetType().GetMethod("ExecutePrint");

            if (m == null) throw new ApplicationException("Not found PrintLabel");

            var paramsArr = new object[] { task };

            m.Invoke(item, paramsArr);
        }
    }
}