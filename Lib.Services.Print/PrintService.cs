﻿using Lib.Services.Print.Labels;
using System.Collections.ObjectModel;

namespace Lib.Services.Print
{
    public class PrintService : IPrintService
    {
        private readonly List<ISupportedLabel> _supportedLabels = new();
        private readonly ObservableCollection<ILabelSetup> _labelSetups = new();

        public PrintService()
        {
            // Fill labels
            _supportedLabels.Add(TestLabelFabric.W43xH25_TscLib);
            _supportedLabels.Add(ProductLabelFabric.W43xH25_TscLib);
        }
        public ICollection<ILabelSetup> LabelSetups => _labelSetups;

        public IList<ISupportedLabel> SupportedLabels => _supportedLabels;

        public void PrintLabel(IProductLabelTask labelTask)
        {
            CallDriver(labelTask);
        }

        public void PrintLabel(ITestLabelTask labelTask)
        {
            CallDriver(labelTask);
        }

        private static void CallDriver(IBaseLabelTask task)
        {
            //ISupportedLabel? item = (from label in _supportedLabels
            //                         where label.CommonLabel == task.LabelSetup.SupportedLabel.CommonLabel &&
            //                                label.LabelSize == task.LabelSetup.SupportedLabel.LabelSize &&
            //                                label.DriverAdapter == task.LabelSetup.SupportedLabel.DriverAdapter
            //                         select label).FirstOrDefault();

            //if (item == null) throw new ApplicationException("Not found supported label for this setup");

            var m = task.LabelSetup.SupportedLabel.GetType().GetMethod("ExecutePrint");

            //var m = item.GetType().GetMethod("ExecutePrint");

            if (m == null) throw new ApplicationException("Not found ExecutePrint method");

            var paramsArr = new object[] { task };

            m.Invoke(task.LabelSetup.SupportedLabel, paramsArr);
        }
    }
}