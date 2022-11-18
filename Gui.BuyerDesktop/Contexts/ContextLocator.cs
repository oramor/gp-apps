using Lib.Services.Print;
using Lib.Services.Print.Labels;
using Microsoft.Extensions.DependencyInjection;

namespace Gui.BuyerDesktop.Contexts.Locator
{
    /// <summary>
    /// Этот класс помещается в статические ресурсы приложения по позволяет
    /// обращаться ко вьюмоделям по шаблону вида DataContext="{Binding LabelPrintContext, Source={StaticResource Contexts}}"
    /// </summary>
    internal class ContextLocator
    {
        public static ILabelSetupContext? LabelPrintContext => App.Host.Services.GetService<ILabelSetupContext>();

        public static ITestLabelPrintContext? TestLabelPrintContext => App.Host.Services.GetService<ITestLabelPrintContext>();

        public static IMainWindowContext? MainWindowContext => App.Host.Services.GetService<IMainWindowContext>();

        public static ILoginWindowContext? LoginWindowContext => App.Host.Services.GetService<ILoginWindowContext>();
    }
}
