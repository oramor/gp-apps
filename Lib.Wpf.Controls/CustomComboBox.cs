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
    }
}