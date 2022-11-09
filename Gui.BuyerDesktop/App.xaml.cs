using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Gui.BuyerDesktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static bool IsProductionMode => false;

        /// <summary>
        /// Определяет, запущено ли приложение под дизайнером XAML.
        /// Дизайнер не вызывает метод OnStartup, поэтому данное поле
        /// в нем получает значение false
        /// </summary>
        public static bool IsDesignMode { get; private set; } = true;  

        #region Host

        private static IHost? _host;
        public static IHost Host => _host ??= Program.CreateHostBuilder().Build();
        
        #endregion

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

        #region Event handlers
        protected async override void OnStartup(StartupEventArgs e)
        {
            IsDesignMode = false;

            var host = Host;
            base.OnStartup(e);
            await host.StartAsync().ConfigureAwait(false);
        }

        protected async override void OnExit(ExitEventArgs e)
        {
            var host = Host;
            await host.StopAsync().ConfigureAwait(false);
            host.Dispose();
            _host = null;
        }
        #endregion

        public static void ConfigureServices(HostBuilderContext host, IServiceCollection services)
        {

        }

        /// <summary>
        /// Текущая директория зависит от того, в каком режиме запущено
        /// приложение (под XAML дизайнером или нет)
        /// </summary>
        public static string CurrentDirectory => IsDesignMode
            ? Path.GetDirectoryName(GetSourceCodePath())
            : Environment.CurrentDirectory;

        /// <summary>
        /// Этот метод позволяет определить, путь к файлу в зависимости от его вызова
        /// </summary>
        private static string GetSourceCodePath([CallerFilePath] string path = null) => path;
    }
}
