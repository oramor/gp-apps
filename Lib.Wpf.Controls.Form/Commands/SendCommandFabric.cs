using Lib.Wpf.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lib.Wpf.Controls.Form
{
    public static class SendCommandFabric
    {
        public static ICommand GetCommand(IServerHandledForm ctx)
        {
            return new SendFormCommand(ctx);
        }

        public static ICommand GetCommand(ILocalHandledForm ctx)
        {
            throw new NotImplementedException();
        }
    }
}
