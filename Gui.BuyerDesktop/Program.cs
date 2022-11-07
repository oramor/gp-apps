using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

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
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var builder = Host.CreateDefaultBuilder(args);

            builder.UseContentRoot(Environment.CurrentDirectory);
            builder.ConfigureAppConfiguration((host, cfg) => {
                cfg.SetBasePath(Environment.CurrentDirectory);
                cfg.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            });

            builder.ConfigureServices(App.ConfigureServices);

            return builder;
        }
    }
}