using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Services.Print
{
    public static class DriverAdapterFactory
    {
        private static readonly IDriverAdapter _tscLib = new DriverAdapter() {
            Key = DriverAdapterEnum.TscLib
        };

        public static IDriverAdapter TscLib => _tscLib;
    }
}
