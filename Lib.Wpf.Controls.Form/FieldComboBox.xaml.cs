using System.Collections;
using System.Windows;
using System.Windows.Controls;

namespace Lib.Wpf.Controls.Form
{
    /// <summary>
    /// Interaction logic for FieldComboBox.xaml
    /// </summary>
    public partial class FieldComboBox : UserControl
    {
        public FieldComboBox()
        {
            InitializeComponent();
        }

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
                typeof(FieldComboBox),
                new FrameworkPropertyMetadata(string.Empty) {
                    //BindsTwoWayByDefault = true,
                    //CoerceValueCallback = (_, value) => value ?? string.Empty,
                    // Фиксирует, что текстовое свойство будет обнвляться при каждом изменении значения,
                    // а не при потере фокуса. Позволяет не указывать UpdateSourceTrigger в биндинге
                    //DefaultUpdateSourceTrigger = System.Windows.Data.UpdateSourceTrigger.PropertyChanged
                });

        #endregion

        #region ItemsSource

        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set {
                SetValue(ItemsSourceProperty, value);
            }
        }
        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register(
                "ItemsSource",
                typeof(IEnumerable),
                typeof(FieldComboBox),
                new FrameworkPropertyMetadata((IEnumerable)null) {
                    //BindsTwoWayByDefault = true,
                    //CoerceValueCallback = (_, value) => value ?? string.Empty,
                    // Фиксирует, что текстовое свойство будет обнвляться при каждом изменении значения,
                    // а не при потере фокуса. Позволяет не указывать UpdateSourceTrigger в биндинге
                    //DefaultUpdateSourceTrigger = System.Windows.Data.UpdateSourceTrigger.PropertyChanged
                });

        #endregion

        #region DisplayMemberPath

        public string DisplayMemberPath
        {
            get => (string)GetValue(DisplayMemberPathProperty);
            set => SetValue(DisplayMemberPathProperty, value);
        }

        public static readonly DependencyProperty DisplayMemberPathProperty =
        DependencyProperty.Register(
                "DisplayMemberPath",
                typeof(string),
                typeof(FieldComboBox),
                new FrameworkPropertyMetadata(string.Empty));

        #endregion

        #region SelectedItem

        public object SelectedItem
        {
            get => GetValue(SelectedItemProperty);
            set => SetValue(SelectedItemProperty, value);
        }

        public static readonly DependencyProperty SelectedItemProperty =
        DependencyProperty.Register(
                "SelectedItem",
                typeof(object),
                typeof(FieldComboBox),
                new FrameworkPropertyMetadata(
                        null,
                        FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        #endregion

        #region ErrorMessage

        public string ErrorMessage
        {
            get => (string)GetValue(ErrorMessageProperty);
            set => SetValue(ErrorMessageProperty, value);
        }

        public static readonly DependencyProperty ErrorMessageProperty =
            DependencyProperty.Register(
                "ErrorMessage",
                typeof(string),
                typeof(FieldComboBox),
                new FrameworkPropertyMetadata(String.Empty) {
                    BindsTwoWayByDefault = true,
                    CoerceValueCallback = (_, value) => value ?? string.Empty
                });

        #endregion
    }
}
