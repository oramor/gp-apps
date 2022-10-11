using System.Windows;

namespace GuiTest.Windows.TestBindingWindow {
    /// <summary>
    /// Interaction logic for TestBindingWindowView.xaml
    /// </summary>
    public partial class TestBindingWindowView : Window {
        public TestBindingWindowView()
        {
            InitializeComponent();
            DataContext = new TestBindingWindowContext();
        }
    }
}
