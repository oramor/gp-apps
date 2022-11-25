using Lib.Core;
using Lib.Services.Print;
using Lib.Wpf.Core;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace Gui.BuyerDesktop.Commands
{
    internal class PrintTestLabelCommand : BaseCommand
    {
        private readonly ITestLabelPrintContext _context;

        public PrintTestLabelCommand(ITestLabelPrintContext ctx)
        {
            _context = ctx;
        }

        public override void Execute(object? parameter)
        {
            // Если хранить LabelSetups на стороне приложения, то будет непросто получать к ним доступ
            // Лучше поместить в сервис.

            var printService = App.Host.Services.GetService<IPrintService>();

            // Get LabelSetup by CommonLabel
            var labelSetup = (from ls in printService?.LabelSetups
                              where ls.SupportedLabel.CommonLabel == CommonLabelFactory.TestLabel
                              select ls).FirstOrDefault();

            if (labelSetup == null)
            {
                var dict = new ExeptionCultureNode {
                    Ru_RU = "Не найден сетпа для печати тестовой этикетки",
                    En_US = "Not found setup for print TestLabel"
                };

                throw new LocalizedException(dict);
            }

            var labelTask = new TestLabelTask() {
                LabelSetup = labelSetup,
                Text = _context.Text,
                Barcode = _context.Barcode,
            };

            printService?.PrintLabel(labelTask);
        }
    }
}
