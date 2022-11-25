using Lib.Wpf.Core;
using System.ComponentModel;
using System.Windows.Media.Effects;

namespace Lib.Wpf.Controls.Form
{
    public abstract class BaseModalFormContext : BaseFormContext
    {
        private IEntityPoolContext _parentContext;

        public BaseModalFormContext(IEntityPoolContext parentContext)
        {
            _parentContext = parentContext;
            ShowModalForm();
        }

        public void ShowModalForm()
        {
            _parentContext.FormWindow.Owner = _parentContext.ParentWindow;
            _parentContext.FormWindow.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
            _parentContext.FormWindow.DataContext = this;
            _parentContext.FormWindow.Owner.Effect = new BlurEffect {
                Radius = 1,
                KernelType = KernelType.Box
            };
            _parentContext.FormWindow.Closing += OnWindowClosing;
            _parentContext.FormWindow.ShowDialog();
        }

        public void OnWindowClosing(object sender, CancelEventArgs e)
        {
            _parentContext.FormWindow.Owner.Effect = null;
            _parentContext.FormWindow = null; // TODO!!!
        }

        #region HandleSuccess

        public override void HandleSuccess(SuccessFormDto dto)
        {
            _parentContext.FormWindow.Close();
        }

        #endregion
    }
}
