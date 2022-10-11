using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using WPFCore;

namespace GuiBuyerDesktop.Windows.LoginWindow {
    internal class LoginWindowContextCopy : BaseViewModel {
        private string _Login;
        private string _Password;

        public string Login
        {
            get => _Login;
            set => Set(ref value, _Login);
        }

        public string Password
        {
            get => _Password;
            set => Set(ref value, _Password);
        }

        public bool IsFormReadyToSend
        {
            get {
                return (_Login is not null && _Password is not null);
            }
        }
    }
}
