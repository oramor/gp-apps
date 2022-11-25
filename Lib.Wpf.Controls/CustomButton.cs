using System.Windows;
using System.Windows.Controls;

namespace Lib.Wpf.Controls
{
    public class CustomButton : Button
    {
        static CustomButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(CustomButton),
                new FrameworkPropertyMetadata(typeof(CustomButton))
                );
        }
    }
}
