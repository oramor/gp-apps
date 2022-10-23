using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace LibForm
{
    public class Form : ItemsControl
    {
        static Form()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(Form),
                new FrameworkPropertyMetadata(typeof(Form))
                );
        }

        public bool IsFormReadyToSend
        {
            get { return (bool)GetValue(IsFormReadyToSendProperty); }
            set { SetValue(IsFormReadyToSendProperty, value); }
        }

        public static readonly DependencyProperty IsFormReadyToSendProperty = DependencyProperty.Register(
            nameof(IsFormReadyToSend),
            typeof(bool),
            typeof(Form),
            new FrameworkPropertyMetadata(null) {
                BindsTwoWayByDefault = true,

            });
    }
}
