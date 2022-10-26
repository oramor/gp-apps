using System;
using System.Collections.Generic;

namespace LibForm
{
    public interface IServerHandlingForm
    {
        List<IFormFieldInfo> FormFields { get; }
    }
}
