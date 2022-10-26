using System.Windows;
using System.Windows.Controls;

namespace LibForm
{
    internal class FieldErrorMessage : TextBlock
    {
        static FieldErrorMessage()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(FieldErrorMessage),
                new FrameworkPropertyMetadata(typeof(FieldErrorMessage))
                );
        }
    }
}
