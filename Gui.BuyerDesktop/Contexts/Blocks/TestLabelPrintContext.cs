using Lib.Core;
using Lib.Services.Print;
using Lib.Wpf.Core;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Windows.Input;

namespace Gui.BuyerDesktop.Contexts
{
    internal class TestLabelPrintContext : BaseContext, ITestLabelPrintContext
    {
        private string _text = "Test";
        private int _barcode = 123456;

        #region Text, Barcode

        public string Text
        {
            get => _text;
            set => Set(ref _text, value);
        }

        public int Barcode
        {
            get => _barcode;
            set => Set(ref _barcode, value);
        }

        #endregion

        #region UI

        public string PrintButtonTitle => "Печатать тестовую этикетку";

        #endregion

        public ICommand PrintTestLabelCmd => new PrintTestLabelCommand(this);

        private class PrintTestLabelCommand : BaseCommand
        {
            private readonly ITestLabelPrintContext _context;

            public PrintTestLabelCommand(ITestLabelPrintContext context)
            {
                _context = context;
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
                        Ru_RU = "Не найден сетап для печати тестовой этикетки",
                        En_US = "Not found setup for TestLabel printing"
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
}
