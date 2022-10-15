using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace LibControls
{
    public class CTextBoxWithPlaceholder : TextBox
    {
        static CTextBoxWithPlaceholder()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(CTextBoxWithPlaceholder),
                new FrameworkPropertyMetadata(typeof(CTextBoxWithPlaceholder))
                );
        }

        /// <summary>
        /// ����� ������ ���������.
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
                typeof(CTextBoxWithPlaceholder),
                new PropertyMetadata(SystemColors.InactiveSelectionHighlightBrush));

        /// <summary>
        /// ��� ����� ���������.
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
                typeof(CTextBoxWithPlaceholder),
                new PropertyMetadata("Enter text..."));

        /// <summary>
        /// ��������� ���� ������.
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
                typeof(CTextBoxWithPlaceholder),
                new PropertyMetadata(true)
                );

        /// <summary><see cref="DependencyProperty"/> ��� �������� <see cref="IsEmpty"/>.</summary>
        public static readonly DependencyProperty IsEmptyProperty = IsEmptyPropertyKey.DependencyProperty;

        /// <summary>
        /// ��������������� ������ ����������� ��� ��������� ������, ���������������
        /// ������ ��� ��� ��������� ����.
        /// </summary>
        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            base.OnTextChanged(e);

            IsEmpty = string.IsNullOrWhiteSpace(Text);
        }
    }
}
