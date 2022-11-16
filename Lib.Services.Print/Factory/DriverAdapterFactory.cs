using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Services.Print
{
    public static class DriverAdapterFactory
    {
        public static IDriverAdapter TscLib => new DriverAdapter() {
            Key = DriverAdapterEnum.TscLib
        };
    }
}
