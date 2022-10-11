using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Test.Windows.TestBindingWindow {
    public class TestBindingWindowContext {
        // These fields hold the values for the public properties.
        private string _Login = String.Empty;

        public event PropertyChangedEventHandler PropertyChanged;

        // This method is called by the Set accessor of each property.  
        // The CallerMemberName attribute that is applied to the optional propertyName  
        // parameter causes the property name of the caller to be substituted as an argument.  
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string Login
        {
            get => _Login;
            set {
                if (value != _Login) {
                    _Login = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }

}
