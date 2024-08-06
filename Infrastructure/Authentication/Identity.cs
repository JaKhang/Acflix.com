using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Authentication;
public class Identity : IIdentity
{
    public string? AuthenticationType => throw new NotImplementedException();

    public bool IsAuthenticated => throw new NotImplementedException();

    public string? Name => throw new NotImplementedException();
}

