using Lib.Services;
using Lib.Services.Print;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Linq;
using System.Printing;
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

        /// <summary>
        /// Таким образом, хост будет создан единожды при первом обращении к нему.
        /// </summary>
        private static IHost? _host;
        public static IHost Host => _host ??= Program.CreateHostBuilder().Build();

        #endregion

        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show("Ошибка уровня приложения: " + e.Exception.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

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

            var printers = GetSystemPrinters();
        }

        protected async override void OnExit(ExitEventArgs e)
        {
            var host = Host;
            await host.StopAsync().ConfigureAwait(false);
            host.Dispose();
            _host = null;
        }
        #endregion

        #region Host infrastructure

        /// <summary>
        /// Метод добавляет сервисы во "встроенный" DI-контейнер. Вызывается при сборке
        /// хоста приложения. Важно обратить внимание, что все добавленные сервисы будут
        /// доступны сторорнним приложениям, взаимодействующим с текущей программой
        /// через интерфейс IHost. 
        /// </summary>
        public static void ConfigureServices(HostBuilderContext host, IServiceCollection services)
        {
            /// По запросу для типа IPrintService будет возвращаться
            /// инстанс PrintService, что позволит ограничиться только
            /// указанием интерфейсов в вызывающем коде
            services.AddSingleton<IPrintService, PrintService>();
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

        #endregion

        #region ICanPrintLabels implements

        public System.Collections.Generic.IEnumerable<ISystemPrinterInfo> GetSystemPrinters()
        {
            var printersColl = new LocalPrintServer().GetPrintQueues().Select(v => {
                var printerInfo = new SystemPrinterInfo() {
                    Name = v.Name,
                    DriverName = v.QueueDriver.Name,
                    PrintPortName = v.QueuePort.Name,
                    Priority = v.Priority
                };

                return printerInfo;
            });

            //var printersColl = new LocalPrintServer().GetPrintQueues().Select(v => v);

            return printersColl;
        }


        #endregion
    }

    public class SystemPrinterInfo : ISystemPrinterInfo
    {
        public string Name { get; init; } = String.Empty;
        public string DriverName { get; init; } = String.Empty;
        public string PrintPortName { get; init; } = String.Empty;
        //public bool IsOffline { get; init; }
        //public bool IsNotAvailable { get; init; }
        //public PrintQueueStatus Status { get; init; }
        //public bool IsHidden { get; init; }
        //public bool IsRawOnlyEnabled { get; init; }
        public int Priority { get; init; }
    }
}
