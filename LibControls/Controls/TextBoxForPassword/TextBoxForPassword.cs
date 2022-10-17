using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace LibControls
{
    public class TextBoxForPassword : TextBox
    {
        static TextBoxForPassword()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(TextBoxForPassword),
                new FrameworkPropertyMetadata(typeof(TextBoxForPassword))
                );
        }

        /// <summary>
        /// Цвета текста подсказки.
        /// </summary>
        public Brush DefaultTextBrush
        {
            get { return (Brush)GetValue(DefaultTextBrushProperty); }
            set { SetValue(DefaultTextBrushProperty, value); }
        }
        public static readonly DependencyProperty DefaultTextBrushProperty =
            DependencyProperty.Register(
                nameof(DefaultTextBrush),
                typeof(Brush),
                typeof(TextBoxForPassword),
                new PropertyMetadata(SystemColors.InactiveSelectionHighlightBrush));

        /// <summary>
        /// Сам текст подсказки.
        /// </summary>
        public string DefaultText
        {
            get { return (string)GetValue(DefaultTextProperty); }
            set { SetValue(DefaultTextProperty, value); }
        }
        public static readonly DependencyProperty DefaultTextProperty =
            DependencyProperty.Register(
                nameof(DefaultText),
                typeof(string),
                typeof(TextBoxForPassword),
                new PropertyMetadata("Enter password..."));

        /// <summary>
        /// Текстовое поле пустое.
        /// </summary>
        public bool IsEmpty
        {
            get => (bool)GetValue(IsEmptyProperty);
            private set => SetValue(IsEmptyPropertyKey, value);
        }

        private static readonly DependencyPropertyKey IsEmptyPropertyKey =
            DependencyProperty.RegisterReadOnly(
                nameof(IsEmpty),
                typeof(bool),
                typeof(TextBoxForPassword),
                new PropertyMetadata(true)
                );

        /// <summary><see cref="DependencyProperty"/> для свойства <see cref="IsEmpty"/>.</summary>
        public static readonly DependencyProperty IsEmptyProperty = IsEmptyPropertyKey.DependencyProperty;

        /// <summary>
        /// Переопределение метода вызываемого при изменении текста, устанавливающий
        /// пустое или нет текстовое поле.
        /// </summary>
        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            base.OnTextChanged(e);

            IsEmpty = string.IsNullOrWhiteSpace(Text);
        }
    }
}
