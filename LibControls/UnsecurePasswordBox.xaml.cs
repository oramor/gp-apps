using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace LibControls
{
    /// <summary>Логика взаимодействия для UnsecurePasswordBox.xaml</summary>
    public partial class UnsecurePasswordBox : UserControl
    {
        public UnsecurePasswordBox()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Цвета текста подсказки
        /// </summary>
        public Brush DefaultTextBrush
        {
            get { return (Brush)GetValue(DefaultTextBrushProperty); }
            set { SetValue(DefaultTextBrushProperty, value); }
        }
        public static readonly DependencyProperty DefaultTextBrushProperty =
            DependencyProperty.Register(
                "DefaultTextBrush",
                typeof(Brush),
                typeof(UnsecurePasswordBox),
                new PropertyMetadata(SystemColors.InactiveSelectionHighlightBrush)
                );

        /// <summary>
        /// Сам текст подсказки
        /// </summary>
        public string DefaultText
        {
            get { return (string)GetValue(DefaultTextProperty); }
            set { SetValue(DefaultTextProperty, value); }
        }
        public static readonly DependencyProperty DefaultTextProperty =
            DependencyProperty.Register(
                "DefaultText",
                typeof(string),
                typeof(UnsecurePasswordBox),
                new PropertyMetadata("Enter password...")
                );

        /// <summary>
        /// Свойство для текста ввода
        /// </summary>
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
                typeof(UnsecurePasswordBox),
                new FrameworkPropertyMetadata(string.Empty) {
                    BindsTwoWayByDefault = true,
                    CoerceValueCallback = (_, value) => value ?? string.Empty
                });

        // Вся разница с TextBox, что здесь пароль обновляется не через биндинг к свойству Password,
        // Которое запрещено для биндинга, а через событие обновления пароля
        private void PART_PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            Text = ((PasswordBox)sender).Password;

            if (string.IsNullOrWhiteSpace(Text)) PART_TextBlock.Visibility = Visibility.Visible;
            else PART_TextBlock.Visibility = Visibility.Hidden;
        }
    }
}
