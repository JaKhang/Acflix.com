using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.User.Entities;

namespace Infrastructure.Authentication
{
    public interface IJwtProvider
    {
        string Generate(User user);
    }
}
