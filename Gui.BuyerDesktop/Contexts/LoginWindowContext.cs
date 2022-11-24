using Gui.BuyerDesktop.Windows;
using Lib.Wpf.Controls.Form;
using Lib.Wpf.Core;
using System;
using System.Windows;
using System.Windows.Input;

namespace Gui.BuyerDesktop.Contexts
{
    internal interface ILoginWindowContext : IWindowContext, IServerHandledForm
    {
    }

    internal class LoginWindowContext : BaseFormContext, ILoginWindowContext
    {
        private string _title = "Вход";
        public string Title { get => _title; set => Set<string>(ref _title, value); }

        public Uri Endpoint => new("http://localhost/api/v1/subjects/login");

        public override bool IsFormReadyToSend
        {
            get {
                return _login != string.Empty && _password != string.Empty;
            }
            set {
                base.IsFormReadyToSend = value;
            }
        }

        #region HandleSuccess

        public override void HandleSuccess(SuccessFormDto dto)
        {
            if (dto.SessionToken == string.Empty)
            {
                throw new ApplicationException("Ваши учетные данные верны, но аутентификация не может быть завершена, т.к. сервер не предоставил SessionToken. Обратитесь к администратору.");
            }

            ResetState();
            TopMessage = $"Вы авторизованы с токеном {dto.SessionToken}";
            var loginWindow = Application.Current.Windows[0];
            var mainWindow = new MainWindow();
            Application.Current.MainWindow = mainWindow;
            loginWindow.Close();
            mainWindow.Show();
        }

        #endregion

        public override ICommand SendFormCommand => SendCommandFabric.GetCommand(this);

        #region Login

        private string _login = string.Empty;
        public string Login
        {
            get => _login;
            set {
                Set(ref _login, value);
                OnPropertyChaged(nameof(IsFormReadyToSend));
            }
        }

        private string _loginError = string.Empty;
        public string LoginError
        {
            get => _loginError;
            set => Set(ref _loginError, value);
        }

        #endregion

        #region Password

        private string _password = string.Empty;
        public string Password
        {
            get => _password;
            set {
                Set(ref _password, value);
                OnPropertyChaged(nameof(IsFormReadyToSend));
            }
        }

        private string _passwordError = string.Empty;
        public string PasswordError
        {
            get => _passwordError;
            set => Set(ref _passwordError, value);
        }

        #endregion
    }
}
