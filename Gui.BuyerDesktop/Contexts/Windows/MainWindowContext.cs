using Lib.Wpf.Core;
using System;
using System.Windows.Input;

namespace Gui.BuyerDesktop.Contexts
{
    internal interface IHaveCustomTabs<T> where T : System.Enum
    {
        T CurrentTab { get; }
        ICommand ChangeTabCmd { get; }
        void ChangeTab(T targetTab);
    }

    internal enum MainWindowTabs
    {
        Orders,
        Printer
    }

    internal interface IMainWindowContext : IWindowContext, IHaveCustomTabs<MainWindowTabs>
    {
    }

    internal class MainWindowContext : BaseContext, IMainWindowContext
    {
        private string _title = "Главное окно";
        private MainWindowTabs _currentTab = MainWindowTabs.Printer;

        public MainWindowTabs CurrentTab
        {
            get => _currentTab;
            set => Set(ref _currentTab, value);
        }

        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }

        public ICommand ChangeTabCmd => new ChangeTabCommand(this);

        public void ChangeTab(MainWindowTabs targetTab)
        {
            CurrentTab = targetTab;
        }

        #region Commands Classes

        private class ChangeTabCommand : BaseCommand
        {
            private IHaveCustomTabs<MainWindowTabs> _context;

            public ChangeTabCommand(IHaveCustomTabs<MainWindowTabs> ctx)
            {
                _context = ctx;
            }

            public override void Execute(object? parameter)
            {
                var targetTab = (MainWindowTabs)Enum.Parse(typeof(MainWindowTabs), parameter as string);
                _context.ChangeTab(targetTab);
            }
        }

        #endregion
    }
}
