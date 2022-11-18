using Lib.Services.Print;
using Lib.Services.Print.Labels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gui.BuyerDesktop.Contexts.Locator
{
    /// <summary>
    /// Этот класс помещается в статические ресурсы приложения по позволяет
    /// обращаться ко вьюмоделям по шаблону вида DataContext="{Binding LabelPrintContext, Source={StaticResource Contexts}}"
    /// </summary>
    internal class ContextLocator
    {
        public static ILabelPrintContext? LabelPrintContext => App.Host.Services.GetService(typeof(ILabelPrintContext)) as ILabelPrintContext;

        public static ITestLabelPrintContext? TestLabelPrintContext => App.Host.Services.GetService(typeof(ITestLabelPrintContext)) as ITestLabelPrintContext;
    }
}
