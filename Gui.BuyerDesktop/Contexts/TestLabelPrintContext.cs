using Gui.BuyerDesktop.Commands;
using Lib.Services.Print.Labels;
using Lib.Wpf.Core;
using System.Windows.Input;

namespace Gui.BuyerDesktop.Contexts
{
    internal class TestLabelPrintContext : BaseContext, ITestLabelData
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

        public ICommand PrintTestLabelCommand => new PrintTestLabelCommand(this);
    }
}
