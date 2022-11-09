using Lib.Services.Print.Labels;

namespace Lib.Services
{
    public class PrintService
    {
        public void PrintIncomeProductLabel()
        {
            IncomeProductLabel.PrintWithTscLib("TSC TTP-225", 100, 500, 1);
        }
    }
}