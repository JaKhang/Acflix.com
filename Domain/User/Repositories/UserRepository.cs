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
        Task<Entities.User> SaveAsync(Entities.User user);

        Code Save(Code code);

        Task<Entities.User> FindByIdAsync(Id id);

        Task<Entities.User?> FindByEmailAsync(string email);

        Task<bool> ExistByEmail(string email);
    }
}
