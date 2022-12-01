using Gui.BuyerDesktop.Windows;
using Lib.Core.Interfaces;
using Lib.Models;
using Lib.Wpf.Controls.Form;
using Lib.Wpf.Core;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace Gui.BuyerDesktop.Contexts
{
    internal class SessionContext : BaseContext, ISessionContext<SubjectRoleId>
    {
        private bool _isAuth; // default false
        public bool IsAuth
        {
            get {
                if (_isAuth == false) return false;

                if (SessionToken == string.Empty) return false;
                /// Так же можно добавить постоянно работающий таймер, который будет проверять,
                /// не истек ли срок токена и, если истек, выполнять Logout, что приведет
                /// к оповещению всех компонентов
                var tokenExpiredData = LoginDate.AddSeconds(SessionTokenDuration);
                return DateTime.Now < tokenExpiredData;
            }
            /// Является приватным, т.к. внешние компоненты не должны прямо
            /// изменять этот статус, только через Logout/Login
            private set => Set(ref _isAuth, value);
        }

        public ICollection<SubjectRoleId> Roles { get; set; }

        public string SessionToken { get; set; } = string.Empty;

        public int SessionTokenDuration { get; set; }

        public bool CheckPermit(SubjectRoleId role)
        {
            throw new NotImplementedException();
        }

        public void Login(string sessionToken, ICollection<SubjectRoleId> roles, int sessionTokenDuration)
        {
            SessionToken = sessionToken;
            Roles = roles;
            SessionTokenDuration = sessionTokenDuration;
            LoginDate = DateTime.Now;
            IsAuth = true; // Will notified all controls which depends from IsAuth
        }

        public DateTime LoginDate { get; set; }

        public void Logout()
        {
            SessionToken = string.Empty;
            SessionTokenDuration = default;
            Roles.Clear();
            IsAuth = false; // Will notified all controls which depends from IsAuth
        }

        public ICommand ShowLoginFormCmd => new ShowLoginFormCommand(this);

        public string LoginFormTitle => IsAuth ? "Выход" : "Вход";

        public void ShowLoginForm()
        {
            var ctx = new LoginFormContext();
            var window = new LoginWindow();
            window.Title = "Вход";
            window.DataContext = ctx;
            window.Owner = Application.Current.MainWindow;
            window.ShowDialog();
        }

        private class ShowLoginFormCommand : BaseCommand
        {
            private readonly SessionContext _context;

            public ShowLoginFormCommand(SessionContext context)
            {
                _context = context;
            }

            public override void Execute(object? parameter)
            {
                _context.ShowLoginForm();
            }
        }

        private class LoginFormContext : BaseFormContext, IServerHandledForm
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
}
