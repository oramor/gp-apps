using Gui.BuyerDesktop.Contexts;
using Lib.Core;
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

        #region Error Handler

        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            var err = e.Exception.InnerException;

            if (err is LocalizedException exception)
            {
                // TODO Определять язык по контексту приложения
                MessageBox.Show(exception.GetLocalizeMessage(SupportedCulture.Ru_RU), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                e.Handled = true;
            }
            else
            {
                // TODO Так же добавить выбор из дефолтного языка. Можно создать класс Culture.Translate()
                MessageBox.Show("Ошибка уровня приложения: " + e.Exception.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

                if (IsProductionMode)
                {
                    e.Handled = true;
                }
            }
        }

        #endregion

        #region Event handlers
        protected async override void OnStartup(StartupEventArgs e)
        {
            IsDesignMode = false;

            var host = Host;
            base.OnStartup(e);
            await host.StartAsync().ConfigureAwait(false);

            //var printers = GetSystemPrinters();
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
        /// Таким образом, хост будет создан единожды при первом обращении к нему.
        /// </summary>
        private static IHost? _host;
        public static IHost Host => _host ??= Program.CreateHostBuilder().Build();

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
            services.AddSingleton<ILabelPrintContext, LabelPrintContext>();
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

        #region ILabelPrintContext implements

        public System.Collections.Generic.IEnumerable<IPrinter> GetSystemPrinters()
        {
            var printers = new LocalPrintServer().GetPrintQueues().Select(v => new SystemPrinter() {
                Name = v.Name,
                DriverName = v.QueueDriver.Name,
                PortName = v.QueuePort.Name,
                Priority = v.Priority
            });

            return printers;
        }

        #endregion
    }


}
