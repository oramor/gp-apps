using Lib.Services.Print;
using Microsoft.Extensions.DependencyInjection;

namespace Gui.BuyerDesktop.Contexts.Locator
{
    /// <summary>
    /// Помещаются только те контексты, которые должны существовать на всем протяжении жизни приложения в единственном экземпляре. Из XAML можно обращаться по шаблону вида DataContext="{Binding LabelPrintContext, Source={StaticResource Contexts}}"
    /// </summary>
    internal class ContextLocator
    {
        public static ILabelSetupContext? LabelPrintContext => App.Host.Services.GetService<ILabelSetupContext>();

        public static ITestLabelPrintContext? TestLabelPrintContext => App.Host.Services.GetService<ITestLabelPrintContext>();

        public static IMainWindowContext? MainWindowContext => App.Host.Services.GetService<IMainWindowContext>();

        //public static ISessionContext<SubjectRoleId>? SessionContext => App.Host.Services.GetService<ISessionContext<SubjectRoleId>>();

        public static SessionContext? SessionContext => App.Host.Services.GetService<SessionContext>();
    }
}
