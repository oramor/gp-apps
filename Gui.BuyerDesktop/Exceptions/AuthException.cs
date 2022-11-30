using Lib.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Gui.BuyerDesktop.Exceptions
{
    internal class AuthException : Exception, ISelfHandledException
    {
        public AuthException() { }

        public void Handle()
        {
            MessageBox.Show("Auth exception!");
        }
    }
}
