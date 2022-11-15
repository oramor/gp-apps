using System.Windows;
using System.Windows.Controls;

namespace Lib.Wpf.Controls
{
    public class CustomGroupBox : GroupBox
    {
        static CustomGroupBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(CustomGroupBox),
                new FrameworkPropertyMetadata(typeof(CustomGroupBox))
                );
        }
    }
}