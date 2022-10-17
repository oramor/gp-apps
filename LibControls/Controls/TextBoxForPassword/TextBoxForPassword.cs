using System.Windows;

namespace LibControls
{
    public class TextBoxForPassword : TextBoxWithPlaceholder
    {
        static TextBoxForPassword()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(TextBoxForPassword),
                new FrameworkPropertyMetadata(typeof(TextBoxForPassword))
            );
        }
    }
}
