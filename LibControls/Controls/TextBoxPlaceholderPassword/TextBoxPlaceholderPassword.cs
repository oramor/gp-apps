using System.Windows;

namespace LibControls
{
    public class TextBoxPlaceholderPassword : TextBoxPlaceholder
    {
        static TextBoxPlaceholderPassword()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(TextBoxPlaceholderPassword),
                new FrameworkPropertyMetadata(typeof(TextBoxPlaceholderPassword))
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
                typeof(TextBoxPlaceholderPassword),
                new PropertyMetadata(false));
    }
}