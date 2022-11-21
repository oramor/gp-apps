using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lib.Wpf.Controls.Form
{
    public interface IServerHandledForm : IBaseFormContext
    {
        /// <summary>
        /// Содержит ссылку, по которой форма должна отправлять запрос к API
        /// </summary>
        Uri Endpoint { get; }
    }
}
