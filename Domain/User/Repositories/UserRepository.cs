using Domain.User.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Base.ValueObjects;

namespace Domain.User.Repositories
{
    public interface IUserRepository
    {
        Entities.User Save(Entities.User user);

        Token Save(Token token);

        Task<Entities.User> FindByIdAsync(ID id);


    }
}
