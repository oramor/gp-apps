using Lib.Services.Print.Labels;

namespace Lib.Services.Print
{
    public class PrintService : IPrintService
    {
        public void PrintLabel(IProductLabelTask labelTask)
        {
            ProductLabel.TscLib_W43_H25("TSC TTP-225", 100, 500, 1);
        }

        public void PrintLabel(ITestLabelTask labelTask)
        {
            throw new NotImplementedException();
        }
    }
}