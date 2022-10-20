using System;
using System.Windows;
using System.Windows.Controls;

namespace LibForm
{
    /// <summary>
    /// Interaction logic for FieldText.xaml
    /// </summary>
    public partial class FieldText : UserControl
    {
        public FieldText()
        {
            InitializeComponent();
        }

        public string ErrorMessage
        {
            get { return (string)GetValue(ErrorMessageProperty); }
            set {
                SetValue(ErrorMessageProperty, value);
            }
        }
        public static readonly DependencyProperty ErrorMessageProperty =
            DependencyProperty.Register(
                "ErrorMessage",
                typeof(string),
                typeof(FieldText),
                new PropertyMetadata(String.Empty)
                );
    }
}
