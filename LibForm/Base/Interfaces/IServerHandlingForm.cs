using System;
using System.Collections.Generic;

namespace LibForm
{
    public interface IFormFieldInfo
    {
        string Name { get; }
        string Value { get; }
    }

    public interface IServerHandlingForm
    {
        List<IFormFieldInfo> FormFields { get; }
    }
}
