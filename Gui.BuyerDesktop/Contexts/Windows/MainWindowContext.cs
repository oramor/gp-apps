using Lib.Wpf.Core;

namespace Gui.BuyerDesktop.Contexts
{
    internal interface IMainWindowContext : IWindowContext
    {
    }

    internal enum MainWindowTabs
    {
        Orders,
        Printer
    }

    internal class MainWindowContext : BaseContext, IMainWindowContext
    {
        private string _title = "Главное окно";

        public MainWindowTabs CurrentTab { get; private set; } = MainWindowTabs.Printer;
        public bool Test { get; set; } = true;

        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }
    }
}
