using System.Windows;
using System.Windows.Controls;

namespace LibForm
{
    public class Form : Control
    {
        static Form()
        {
            {
                DefaultStyleKeyProperty.OverrideMetadata(
                    typeof(Form),
                    new FrameworkPropertyMetadata(typeof(Form))
                    );
            }
        }
    }
}
