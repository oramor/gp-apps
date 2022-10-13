using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace LibControls
{
    /// <summary>Логика взаимодействия для TextBoxWithPlaceholder.xaml</summary>
    public partial class TextBoxWithPlaceholder : UserControl
    {
        public TextBoxWithPlaceholder()
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
            DependencyProperty.Register("DefaultTextBrush", typeof(Brush), typeof(TextBoxWithPlaceholder), new PropertyMetadata(SystemColors.InactiveSelectionHighlightBrush));

        /// <summary>
        /// Сам текст подсказки
        /// </summary>
        public string DefaultText
        {
            get { return (string)GetValue(DefaultTextProperty); }
            set { SetValue(DefaultTextProperty, value); }
        }
        public static readonly DependencyProperty DefaultTextProperty =
            DependencyProperty.Register("DefaultText", typeof(string), typeof(TextBoxWithPlaceholder), new PropertyMetadata("Enter text..."));

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
            DependencyProperty.Register("Text", typeof(string), typeof(TextBoxWithPlaceholder), new PropertyMetadata(null));

        /// <summary>
        /// Обработчик события изменения текста, устанавливающий
        /// видимость/невидимость текста подсказки
        /// </summary>
        private void PART_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Text)) PART_TextBlock.Visibility = Visibility.Visible;
            else PART_TextBlock.Visibility = Visibility.Hidden;
        }
    }
}