using Lib.Wpf.Core;

namespace Gui.BuyerDesktop.Contexts
{
    internal interface IMainWindowContext : IWindowContext
    {
    }

    internal class MainWindowContext : BaseContext, IMainWindowContext
    {
        private string _title = "Главное окно";

        public string Title { get => _title; set => Set(ref _title, value); }
    }
}
