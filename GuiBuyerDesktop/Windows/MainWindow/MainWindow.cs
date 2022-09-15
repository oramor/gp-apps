using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCore;

namespace GuiBuyerDesktop.Windows.MainWindow
{
    internal class MainWindow : BaseViewModel
    {
        private string _Login;
        private string _Password;

        public string Login
        {
            get { return _Login; }

        }
    }
}
