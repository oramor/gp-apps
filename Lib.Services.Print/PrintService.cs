using Lib.Services.Print.Labels;

namespace Lib.Services.Print
{
    public class PrintService : IPrintService
    {
        public IReadOnlyCollection<ILabel> SupportedLabels => throw new NotImplementedException();

        public void PrintLabel(IProductLabelTask labelTask)
        {
            //ProductLabel.TscLib_W43xH25("TSC TTP-225", 100, 500, 1);
        }

        public void PrintLabel(ITestLabelTask labelTask)
        {
            //ProductLabel_TscLib_W43xH25.Printer.PrintLabel(labelTask)
            throw new NotImplementedException();
        }
    }
}