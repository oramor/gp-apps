using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibForm
{
    public interface IFormFieldInfo
    {
        string Name { get; set; }
        string Value { get; set; }
    }

    public interface IFormFieldDTO : IFormFieldInfo
    {
        string? ErrorMessage { get; set; }
    }
}
