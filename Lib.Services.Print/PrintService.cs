using Lib.Services.Print.Labels;

namespace Lib.Services
{
    public class PrintService : IPrintService
    {
        public void PrintLabel<T>(T labelParams) where T : IPrintService_AbstractLabelParams
        {
            IncomeProductLabel.PrintWithTscLib("TSC TTP-225", 100, 500, 1);
        }
    }
}