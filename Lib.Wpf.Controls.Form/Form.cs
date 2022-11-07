namespace Lib.Wpf.Controls.Form
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

        public Form()
        {
            this.Loaded += new RoutedEventHandler(OnLoaded);
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            KeyGesture enterKeyGesture = new(Key.Enter);


            ICommand cmd = new SendFormCommand(DataContext as BaseFormContext);

            KeyBinding enterKeyGestureCmd = new(
                cmd,
                enterKeyGesture);

            this.InputBindings.Add(enterKeyGestureCmd);
        }

        #region IsLoading
        /// <summary>
        /// ���������, ��������� �� ����� � ��������� �������� ������ �� ������.
        /// �� ����� ���� ������� ������� ������ � ������� Form.xaml
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
        /// ��������� �������� �� ������������ �������� ��������� (���������)
        /// � ���������� ����������� �������� �����
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

        #region TopMessage
        /// <summary>
        /// ���������, ������� ����� ���������� �� ����� � ������ �� �������� ��������. ����������� ���
        /// (��������� �����) ������ ������������ � ��������������� ������� ��������� �� ������
        /// </summary>
        public string TopMessage
        {
            get { return (string)GetValue(TopMessageProperty); }
            set { SetValue(TopMessageProperty, value); }
        }

        public static readonly DependencyProperty TopMessageProperty = DependencyProperty.Register(
            nameof(TopMessage),
            typeof(string),
            typeof(Form),
            new FrameworkPropertyMetadata(string.Empty) {
                BindsTwoWayByDefault = true
            });
        #endregion

        #region TopErrorMessage
        /// <summary>
        /// �������� ����� ������, ������� �� ��������� � ����������� ����
        /// �� �����. ������ ������ ��������, ��� ���� �� ����� �������
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
        /// ���������� ����� � ������, �� ������� ������� ������ ������������ �� ������
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

        #region SendCommand
        /// <summary>
        /// �������� ������ �� �������, �� ������� ������ ������������ �� ������. ����������� ������
        /// </summary>
        public ICommand SendCommand
        {
            get { return (ICommand)GetValue(SendCommandProperty); }
            set { SetValue(SendCommandProperty, value); }
        }

        public static readonly DependencyProperty SendCommandProperty = DependencyProperty.Register(
            nameof(SendCommand),
            typeof(ICommand),
            typeof(Form),
            new PropertyMetadata(null));
        #endregion
    }
}
