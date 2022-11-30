using Lib.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Windows;

namespace Gui.BuyerDesktop
{
    public class Program
    {
        [STAThread]
        public static void Main()
        {
            var app = new App();
            app.InitializeComponent();
            app.Run();

            //AppDomain currentDomain = AppDomain.CurrentDomain;
            //currentDomain.UnhandledException += new UnhandledExceptionEventHandler(UnhandledExeptionHandler);

        }

        // Здесь можно сообщить, что приложение будет закрыто
        //static void UnhandledExeptionHandler(object sender, UnhandledExceptionEventArgs args)
        //{
        //    LocalizedException e = (LocalizedException)args.ExceptionObject;
        //    MessageBox.Show(e.GetLocalizeMessage(SupportedCulture.Ru_RU));
        //}

        public static IHostBuilder CreateHostBuilder()
        {
            var builder = Host.CreateDefaultBuilder();

            builder.UseContentRoot(App.CurrentDirectory);
            builder.ConfigureAppConfiguration((host, cfg) => cfg
                .SetBasePath(App.CurrentDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            );

            /// App.ConfigureServices передается в виде коллбека, который, при вызове
            /// получит два параметра: host и 
            builder.ConfigureServices(App.ConfigureServices);

            return builder;
        }
    }
}