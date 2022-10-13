using LibCore;
using System;
using System.Windows;

namespace GuiBuyerDesktop.Windows.LoginWindow
{
    internal class LoginWindowContext : BaseViewModel
    {
        private string _Login = String.Empty;
        private string _Password = null;

        public string Login
        {
            get => _Login;
            set {
                MessageBox.Show("Checked!");
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
                //MessageBox.Show(_Password);
            }
        }

        public bool IsFormReadyToSend
        {
            get {
                return _Login != String.Empty;
            }
        }
    }
}
