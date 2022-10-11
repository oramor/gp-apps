using System;
using WPFCore;

namespace GuiBuyerDesktop.Windows.LoginWindow {
    internal class LoginWindowContext : BaseViewModel {
        private string _Login = String.Empty;
        private string _Password = String.Empty;

        public string Login
        {
            get => _Login;
            set {
                Set(ref _Login, value);
                OnPropertyChaged(nameof(IsFormReadyToSend));
            }
        }

        public string Password
        {
            get => _Password;
            set {
                Set(ref _Password, value);
                OnPropertyChaged(nameof(IsFormReadyToSend));
            }
        }

        public bool IsFormReadyToSend
        {
            get {
                return (_Login != String.Empty && _Password != String.Empty);
            }
        }
    }
}
