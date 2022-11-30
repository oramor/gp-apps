using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Core;
using Lib.Core.Interfaces;
using Lib.Models;
using Lib.Wpf.Core;

namespace Gui.BuyerDesktop.Contexts
{
    internal class SessionContext : ISessionContext<SubjectRoleId>
    {
        public bool IsAuth => SessionToken != string.Empty;

        public ICollection<SubjectRoleId> Roles => throw new NotImplementedException();

        public string SessionToken { get; set; } = string.Empty;

        public int SessionTokenDuration { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime LastLoginDT { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool CheckPermit(SubjectRoleId role)
        {
            throw new NotImplementedException();
        }

        public void Login(string sessionToken, ICollection<SubjectRoleId> roles)
        {
            throw new NotImplementedException();
        }

        public void Logout()
        {
            throw new NotImplementedException();
        }

        public void ShowForbiddenMessage()
        {
            throw new NotImplementedException();
        }

        public void ShowLoginForm()
        {
            throw new NotImplementedException();
        }

        private class ShowLoginFormCommand : BaseCommand
        {
            public override void Execute(object? parameter)
            {
                throw new NotImplementedException();
            }
        }

        private class LoginFormContext
        {

        }
    }
}
