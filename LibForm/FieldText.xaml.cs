using System;
using System.Windows;
using System.Windows.Controls;

namespace LibForm
{
    public partial class FieldText : UserControl
    {
        public FieldText()
        {
            InitializeComponent();
        }

        #region Text
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set {
                SetValue(TextProperty, value);
            }
        }
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(
                "Text",
                typeof(string),
                typeof(FieldText),
                new FrameworkPropertyMetadata(String.Empty) {
                    BindsTwoWayByDefault = true,
                    //CoerceValueCallback = (_, value) => value ?? string.Empty
                });
        #endregion

        #region PlaceholderText
        public string PlaceholderText
        {
            get { return (string)GetValue(PlaceholderTextProperty); }
            set {
                SetValue(PlaceholderTextProperty, value);
            }
        }
        public static readonly DependencyProperty PlaceholderTextProperty =
            DependencyProperty.Register(
                "PlaceholderText",
                typeof(string),
                typeof(FieldText),
                new PropertyMetadata(String.Empty)
                );
        #endregion

        #region ErrorMessage
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
        #endregion
    }
}
