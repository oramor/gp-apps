using System.Windows;

namespace Lib.Wpf.Controls
{
    public class PasswordTextBox : PlaceholderTextBox
    {
        static PasswordTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(PasswordTextBox),
                new FrameworkPropertyMetadata(typeof(PasswordTextBox))
                );
        }

        /// <summary>
        /// Показать текст.
        /// </summary>
        public bool IsTextVisibility
        {
            get => (bool)GetValue(IsTextVisibilityProperty);
            set => SetValue(IsTextVisibilityProperty, value);
        }

        /// <summary>
        /// <see cref="DependencyProperty"/> для свойства <see cref="IsTextVisibility"/>.
        /// </summary>
        public static readonly DependencyProperty IsTextVisibilityProperty =
            DependencyProperty.Register(
                nameof(IsTextVisibility),
                typeof(bool),
                typeof(PasswordTextBox),
                new PropertyMetadata(false));
    }
}