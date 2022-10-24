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

        #region IsLoading

        /// <summary>
        /// Указывает, находится ли форма в состоянии отправки данных на сервер.
        /// От этого поля зависит контент кнопки в шаблоне Form.xaml
        /// </summary>
        public bool IsLoading
        {
            get { return (bool)GetValue(IsLoadingProperty); }
            set { SetValue(IsLoadingProperty, value); }
        }

        public static readonly DependencyProperty IsLoadingProperty = DependencyProperty.Register(
            nameof(IsLoading),
            typeof(bool),
            typeof(Form),
            new PropertyMetadata(false));

        #endregion

        #region IsFormReadyToSend
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

        #endregion

        #region TopErrorMessage

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
        #endregion

        #region SendButtonText

        /// <summary>
        /// Определяет текст в кнопке, по команде которой данные отправляются на сервер
        /// </summary>
        public string SendButtonText
        {
            get { return (string)GetValue(SendButtonTextProperty); }
            set { SetValue(SendButtonTextProperty, value); }
        }

        public static readonly DependencyProperty SendButtonTextProperty = DependencyProperty.Register(
            nameof(SendButtonText),
            typeof(string),
            typeof(Form),
            new PropertyMetadata("Send"));

        #endregion
    }
}
