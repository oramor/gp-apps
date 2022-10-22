using System.Windows;
using System.Windows.Controls;

namespace LibForm
{
    public class Form : StackPanel
    {
        static Form()
        {

            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(Form),
                new FrameworkPropertyMetadata(typeof(Form))
                );

        }

        public Form()
        {
            UIElementCollection children = InternalChildren;

            var btn = new Button {
                Content = "Test"
            };

            children.Add(btn);
        }
    }
}
