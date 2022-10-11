using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GuiTest.Windows {
    public class TestBindingWindowContext : INotifyPropertyChanged {
        /**
         * Эти поля содержат буфер для хранения данных (помним, что привязка
         * к полям класса невозможна, только к свойствам (get; set)
         * */
        private string _Login = "uyuyuy888u";
        private string _Email = String.Empty;

        private string _InfoPlaceholder = "Awaiting input...";

        public event PropertyChangedEventHandler PropertyChanged;

        // This method is called by the Set accessor of each property.  
        // The CallerMemberName attribute that is applied to the optional propertyName  
        // parameter causes the property name of the caller to be substituted as an argument.  
        private void OnPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string Login
        {
            get => _Login;
            set {
                if (value != _Login) {
                    _Login = value;
                    //OnPropertyChanged();
                    // Следует передавать имя свойства, привязку к которому
                    // нужно обновить
                    OnPropertyChanged(nameof(InfoLogin));
                }
            }
        }

        public string Email
        {
            get => _Email;
            set {
                if (value != _Email) {
                    _Email = value;
                    OnPropertyChanged();
                }
            }
        }

        public string InfoLogin
        {
            get => _Login;
        }
    }
}
