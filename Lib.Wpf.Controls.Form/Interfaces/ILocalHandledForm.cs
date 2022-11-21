using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lib.Wpf.Controls.Form
{
    public interface ILocalHandledForm : IBaseFormContext
    {
        /// <summary>
        /// Локальный хендлер содержит всю бизнес-логику для обработки
        /// данных, полученных с формы. Вызывается из метода Execute
        /// соответствующего класса команды.
        /// </summary>
        LocalFormResult LocalHandler();
    }
}
