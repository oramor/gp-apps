using LibForm;

namespace GuiBuyerDesktop.Windows.LoginWindow
{
    internal class LoginWindowContext : BaseFormContext
    {
        private string _login = string.Empty;
        private string _loginError = string.Empty;
        private string _password = string.Empty;
        private string _passwordError = string.Empty;

        public override bool IsFormReadyToSend
        {
            get {
                return _login != string.Empty && _password != string.Empty;
            }
            set {
                base.IsFormReadyToSend = value;
            }
        }

        #region Login

        public string Login
        {
            get => _login;
            set {
                Set(ref _login, value);
                OnPropertyChaged(nameof(IsFormReadyToSend));
            }
        }

        public string LoginError
        {
            get => _loginError;
            set => Set(ref _loginError, value);
        }

        #endregion

        #region Password

        public string Password
        {
            get => _password;
            set {
                Set(ref _password, value);
                OnPropertyChaged(nameof(IsFormReadyToSend));
            }
        }

        public string PasswordError
        {
            get => _passwordError;
            set => Set(ref _passwordError, value);
        }

        #endregion
    }
}
