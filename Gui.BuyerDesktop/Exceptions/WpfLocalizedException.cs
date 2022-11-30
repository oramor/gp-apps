using Lib.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Gui.BuyerDesktop
{
    public class WpfLocalizedException : BaseLocalizedException, ISelfHandledException
    {
        public WpfLocalizedException(ICultureNode node, string message = "") : base(node, message)
        {
        }

        public void Handle()
        {
            // TODO
            var locale = SupportedCulture.Ru_RU;
            var message = GetLocalizeMessage(locale);
            MessageBox.Show(message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
