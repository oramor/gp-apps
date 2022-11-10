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