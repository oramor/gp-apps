using System.Windows;

namespace Gui.BuyerDesktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static bool IsProductionMode => false;

        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show("Произошла неизвестная ошибка: " + e.Exception.Message,
                "Ошибка",
                MessageBoxButton.OK,
            MessageBoxImage.Error);

            if (IsProductionMode)
            {
                e.Handled = true;
            }
        }
    }
}
