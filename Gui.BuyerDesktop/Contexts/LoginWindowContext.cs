using Lib.Wpf.Controls.Form;
using System;

namespace Gui.BuyerDesktop.Contexts
{
    internal class LoginWindowContext : BaseFormContext
    {
        private static readonly string _endpoint = "http://localhost/api/v1/subjects/login";
        private string _login = string.Empty;
        private string _loginError = string.Empty;
        private string _password = string.Empty;
        private string _passwordError = string.Empty;

        public override Uri Endpoint
        {
            get => new(_endpoint);
        }

        public override bool IsFormReadyToSend
        {
            get {
                return _login != string.Empty && _password != string.Empty;
            }
            set {
                base.IsFormReadyToSend = value;
            }
        }

        public override void HandleSuccess(SuccessFormDto dto)
        {
            if (dto.SessionToken == string.Empty)
            {
                throw new ApplicationException("Ваши учетные данные верны, но аутентификация не может быть завершена, т.к. сервер не предоставил SessionToken. Обратитесь к администратору.");
            }

            ResetState();
            TopMessage = $"Вы авторизованы с токеном {dto.SessionToken}";
        }

        #region Login
        public string Login
        {
            get => _login;
            set {
                //MessageBox.Show("ddfdf");
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
