using Domain.Base.ValueObjects;
using Domain.User.ObjectValue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Authentication
{
    public class Principal : IPrincipal
    {
        public string Email { get; private set; }
        public Id Id{ get; private set; }


        private readonly List<Role> _roles; 

        public IIdentity? Identity => throw new NotImplementedException();

        public bool IsInRole(string role)
        {
            return _roles.Any(r => r.Name == role);
        }
    }
}
