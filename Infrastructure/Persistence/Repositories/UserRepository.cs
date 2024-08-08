using Domain.Base.ValueObjects;
using Domain.User.Entities;
using Domain.User.Repositories;
using Infrastructure.Persistence.Config;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class UserRepository(DatabaseContext context) : IUserRepository
{


    public Task<User> SaveAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Code Save(Code code)
    {
        throw new NotImplementedException();

    }

    public Task<User> FindByIdAsync(ID id)
    {
        throw new NotImplementedException();
    }

    public async Task<User?> FindByEmailAsync(string email)
    {
        return await context.Users
            .Where(user => user.Email == email)
            .Include(user => user.Codes)
            .FirstOrDefaultAsync();
    }

    public Task<bool> ExistByEmail(string email)
    {
        throw new NotImplementedException();
    }
}