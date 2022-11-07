using System.Collections.Generic;

namespace Lib.Wpf.Controls.Form
{
    public interface IServerHandlingForm
    {
        List<IFormFieldInfo> FormFields { get; }
    }
}
