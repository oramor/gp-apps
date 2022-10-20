using System.Windows;
using System.Windows.Controls;

namespace LibForm
{
    public class FieldErrorBlock : TextBlock
    {
        static FieldErrorBlock()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(FieldErrorBlock),
                new FrameworkPropertyMetadata(typeof(FieldErrorBlock))
                );
        }
    }
}
