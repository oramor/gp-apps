using System.Windows;
using System.Windows.Controls;

namespace Lib.Wpf.Controls
{
    public class CustomComboBox : ComboBox
    {
        static CustomComboBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(CustomComboBox),
                new FrameworkPropertyMetadata(typeof(CustomComboBox))
                );
        }

        public string PlaceholderText
        {
            get { return (string)GetValue(PlaceholderTextProperty); }
            set { SetValue(PlaceholderTextProperty, value); }
        }
        public static readonly DependencyProperty PlaceholderTextProperty =
            DependencyProperty.Register(
                nameof(PlaceholderText),
                typeof(string),
                typeof(CustomComboBox),
                new PropertyMetadata("Select value..."));
    }
}