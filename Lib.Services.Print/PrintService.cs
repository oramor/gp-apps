using Lib.Services.Print;
using Lib.Services.Print.Labels;

namespace Lib.Services
{
    public class PrintService : IPrintService
    {
        public void PrintIcomeProductLabel(IIncomeProductLabelTask labelTask)
        {
            IncomeProductLabel.TscLib_W43_H25("TSC TTP-225", 100, 500, 1);
        }
    }
}