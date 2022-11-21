using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Wpf.Controls.Form
{
    public interface IBaseFormContext
    {
        void HandleError(ErrorFormDto dto);
        void HandleInvalid(InvalidFormDto dto);
        void HandleSuccess(SuccessFormDto dto);
        List<IFormFieldInfo> GetFormFields();
        string TopMessage { get; set; }
        string TopErrorMessage { get; set; }
        bool IsLoading { get; set; }
        bool IsFormReadyToSend { get; set; }
    }
}
