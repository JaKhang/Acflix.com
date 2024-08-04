using Domain.User.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.User.Repositories
{
    public interface UserRepository
    {
        Entities.User Save(Entities.User user);
        Token Save(Token token);

    }
}
