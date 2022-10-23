using LibForm;
using System;

namespace GuiBuyerDesktop.Windows.LoginWindow
{
    internal class LoginWindowContext : BaseFormContext
    {
        private string _login = String.Empty;
        private string _password = String.Empty;

        public string Login
        {
            get => _login;
            set {
                Set(ref _login, value);
                OnPropertyChaged(nameof(IsFormReadyToSend));
            }
        }

        public string Password
        {
            get => _password;
            set {
                Set(ref _password, value);
                OnPropertyChaged(nameof(IsFormReadyToSend));
            }
        }

        public override bool IsFormReadyToSend
        {
            get {
                return _login != String.Empty && _password != String.Empty;
            }
            set {
                throw new NotSupportedException();
            }
        }
    }
}
