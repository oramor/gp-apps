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

        /// <summary>
        /// Принимает значение из одноименного свойства вьюмодели (контекста)
        /// и определяет возможность отправки формы
        /// </summary>
        public bool IsFormReadyToSend
        {
            get { return (bool)GetValue(IsFormReadyToSendProperty); }
            set { SetValue(IsFormReadyToSendProperty, value); }
        }

        public static readonly DependencyProperty IsFormReadyToSendProperty = DependencyProperty.Register(
            nameof(IsFormReadyToSend),
            typeof(bool),
            typeof(Form),
            new FrameworkPropertyMetadata(false) {
                BindsTwoWayByDefault = true
            });

        /// <summary>
        /// Содержит текст ошибки, которая не привязана к конкретному полю
        /// на форме. Пустая строка означает, что блок не будет показан
        /// </summary>
        public string TopErrorMessage
        {
            get { return (string)GetValue(TopErrorMessageProperty); }
            set { SetValue(TopErrorMessageProperty, value); }
        }

        public static readonly DependencyProperty TopErrorMessageProperty = DependencyProperty.Register(
            nameof(TopErrorMessage),
            typeof(string),
            typeof(Form),
            new FrameworkPropertyMetadata(string.Empty) {
                BindsTwoWayByDefault = true
            });
    }
}
